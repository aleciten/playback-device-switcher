// Copyright (c) 2013 Alejandro Becher
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManicMonkey.CoreAudio;
using ManicMonkey.PlaybackDeviceSwitcher.Configuration;

namespace ManicMonkey.PlaybackDeviceSwitcher
{
    public static class ContextMenuManager
    {
        private static EndpointManager endpointManager;
        private static ToolStripItem[] commonMenuItems;
        private static volatile string changingEndpoint;

        public static void Init()
        {
            endpointManager = new EndpointManager();

            endpointManager.EndpointAdded += new EventHandler<EndpointEventArgs>(endpointManager_EndpointAdded);
            endpointManager.EndpointRemoved += new EventHandler<EndpointEventArgs>(endpointManager_EndpointRemoved);
            endpointManager.EndpointStateChanged += new EventHandler<EndpointStateChangedEventArgs>(endpointManager_EndpointStateChanged);
            endpointManager.DefaultEndpointChanged += new EventHandler<DefaultEndpointChangedEventArgs>(endpointManager_DefaultEndpointChanged);
            
            commonMenuItems = new ToolStripItem[]
            {
                new ToolStripSeparator(),
                new ToolStripMenuItem("Settings", null, delegate { new SettingsForm().ShowDialog(); }),                
                new ToolStripMenuItem("About", null, delegate { new AboutForm().ShowDialog(); }),
                new ToolStripSeparator(),
                new ToolStripMenuItem("Close", null, delegate { Application.Exit(); })
            };
            
            RebuildContextMenu();
        }

        public static void UpdateSelectedEndpoint(string endpointId)
        {
            var endpoint = endpointManager.GetEndpointById(endpointId);

            if (!endpointId.Equals(changingEndpoint))
                NotifyIcon.Instance.ShowBalloonTip(10, "Default audio endpoint changed", endpoint.FullName, ToolTipIcon.Info);

            NotifyIcon.Instance.Text = endpoint.FullName;
            
            changingEndpoint = endpointId;
        }

        private static void MenuAction(ToolStripMenuItem menuItem)
        {
            var endpointId = menuItem.Tag as string;
            if (endpointId == null) return;

            changingEndpoint = endpointId;
            EndpointManager.SetDefaultEndpoint(endpointId);
        }

        public static void RebuildContextMenu()
        {
            var endpoints = endpointManager.GetEndpoints(DataFlow.Render, DeviceState.Active);
            var groups = from endpoint in endpoints orderby endpoint.Name group endpoint by endpoint.DeviceName;
            
            var defaultEndpoint = endpointManager.GetDefaultEndpoint(DataFlow.Render, Role.Multimedia);

            NotifyIcon.InvokeIfRequired(() =>
            {
                NotifyIcon.ContextMenu.Items.Clear();

                foreach (var group in groups.OrderBy(x => x.Key))
                {
                    foreach (var endpoint in group)
                    {
                        var endpointId = endpoint.EndpointId;
                        var menuItemName = endpoint.FullName;
                        var deviceSettings = ConfigManager.GetEndpointSettings(endpointId);

                        if (deviceSettings != null)
                        {
                            if (deviceSettings.Hidden) continue;
                            menuItemName = String.IsNullOrEmpty(deviceSettings.Alias)
                                                ? menuItemName
                                                : deviceSettings.Alias;
                        }

                        var menuItem = new ToolStripMenuItem(menuItemName);
                        menuItem.Tag = endpointId;
                        menuItem.Checked = endpointId.Equals(defaultEndpoint.EndpointId);
                        menuItem.Click += delegate { MenuAction(menuItem); };

                        if (menuItem.Checked) NotifyIcon.Instance.Text = endpoint.FullName;
                        NotifyIcon.ContextMenu.Items.Add(menuItem);
                    }
                }

                NotifyIcon.ContextMenu.Items.AddRange(commonMenuItems);
            });
        }

        static void endpointManager_EndpointStateChanged(object sender, EndpointStateChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("AudioEndpointStateChanged: " + e.ToString());
            RebuildContextMenu();
        }

        static void endpointManager_DefaultEndpointChanged(object sender, DefaultEndpointChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DefaultAudioEndpointChanged: " + e.ToString());
            if (e.DataFlow != DataFlow.Render) return;

            ContextMenuManager.RebuildContextMenu();
            ContextMenuManager.UpdateSelectedEndpoint(e.EndpointId);
        }

        static void endpointManager_EndpointRemoved(object sender, EndpointEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("AudioEndpointRemoved: " + e.ToString());
            RebuildContextMenu();
        }

        static void endpointManager_EndpointAdded(object sender, EndpointEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("AudioEndpointAdded: " + e.ToString());
            RebuildContextMenu();
        }
    }
}
