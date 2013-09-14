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
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Forms = System.Windows.Forms;

namespace ManicMonkey.PlaybackDeviceSwitcher
{
    public static class NotifyIcon
    {
        public static Forms.NotifyIcon Instance { get; private set; }
        public static ContextMenuStrip ContextMenu { get; private set; }

        static NotifyIcon()
        {
            ContextMenu = new ContextMenuStrip();
        }

        public static void InvokeIfRequired(Action action)
        {
            if (ContextMenu.InvokeRequired) ContextMenu.Invoke(action);
            else action();
        }

        public static void ClearChecked()
        {
            ContextMenu.Items.OfType<ToolStripMenuItem>().ToList().ForEach(item => item.Checked = false);
        }
        
        public static void Init()
        {
            if (Instance != null) return;

            Instance = new Forms.NotifyIcon
            {
                Icon = Properties.Resources.Card,
                Visible = true,
                ContextMenuStrip = ContextMenu
            };

            Application.ApplicationExit += delegate { if (Instance != null) Instance.Dispose(); };
        }
    }
}
