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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManicMonkey.CoreAudio;
using ManicMonkey.PlaybackDeviceSwitcher.Configuration;

namespace ManicMonkey.PlaybackDeviceSwitcher
{ 
    public partial class SettingsForm : Form
    {
        private EndpointManager endpointManager;
        private List<EndpointGridRow> activeEndpoints;

        private class EndpointGridRow
        {
            public EndpointGridRow() { }

            public string Id { get; set; }
            public string Name { get; set; }
            public string Alias { get; set; }
            public bool Hidden { get; set; }
        }

        public SettingsForm()
        {
            InitializeComponent();
            endpointManager = new EndpointManager();
            
            activeEndpointsGrid.AutoGenerateColumns = false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ConfigManager.ReloadConfig();
            RefreshGrids();
        }

        private void RefreshGrids()
        {
            var allEndpoints = endpointManager.GetEndpoints(DataFlow.Render, DeviceState.Active).OrderBy(x => x.Name);
            activeEndpoints = new List<EndpointGridRow>();

            foreach (var ep in allEndpoints)
            {
                var epConfig = ConfigManager.GetEndpointSettings(ep.EndpointId);

                activeEndpoints.Add(new EndpointGridRow
                {
                    Id = ep.EndpointId,
                    Name = ep.FullName,
                    Alias = epConfig != null ? epConfig.Alias : ep.FullName,
                    Hidden = epConfig != null ? epConfig.Hidden : false
                });
            }

            activeEndpointsGrid.DataSource = activeEndpoints;
        }      
        
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            activeEndpoints                
                .Select(ep => new DeviceSettings 
                {
                    DeviceId = ep.Id,
                    Alias = ep.Alias,
                    Hidden = ep.Hidden
                })
                .ToList()
                .ForEach(ConfigManager.SetEndpointSettings);

            ConfigManager.SaveConfig();
            ContextMenuManager.RebuildContextMenu();

            Close();
        }

        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            ConfigManager.ClearSettings();
            RefreshGrids();
        }
    }
}
