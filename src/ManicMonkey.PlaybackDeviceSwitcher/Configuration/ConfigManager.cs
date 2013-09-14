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
using System.Configuration;
using System.Linq;
using System.Text;

namespace ManicMonkey.PlaybackDeviceSwitcher.Configuration
{
    public static class ConfigManager
    {
        private static readonly Dictionary<string, DeviceSettings> deviceSettings;

        static ConfigManager()
        {
            try
            {
                deviceSettings = new Dictionary<string, DeviceSettings>();
                ReloadConfig();
            }
            catch (Exception) { }
        }

        public static void ReloadConfig()
        {
            deviceSettings.Clear();

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var dsSection = config.GetSection("deviceSwitcherConfig") as DeviceSwitcherConfigSection;

            if (dsSection != null)
            {                
                foreach (DeviceSettingsElement ds in dsSection.DeviceSettings)
                {
                    deviceSettings.Add(ds.DeviceId, new DeviceSettings
                                                        {
                                                            DeviceId = ds.DeviceId,
                                                            Alias = ds.Alias,
                                                            Hidden = ds.Hidden
                                                        });
                }
            }
        }

        public static void SaveConfig()
        {
            DeviceSwitcherConfigSection section = null;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            try
            {
                section = config.GetSection("deviceSwitcherConfig") as DeviceSwitcherConfigSection;               
            }
            catch (Exception) 
            {
                config.Sections.Remove("deviceSwitcherConfig");
            }

            if (section == null)
            {
                section = new DeviceSwitcherConfigSection();
                config.Sections.Add("deviceSwitcherConfig", section);
            }
            
            section.DeviceSettings.Clear();
            
            deviceSettings
                .Values                
                .Select(ep => new DeviceSettingsElement 
                { 
                    DeviceId = ep.DeviceId, 
                    Alias = ep.Alias,
                    Hidden = ep.Hidden
                })
                .ToList()
                .ForEach(section.DeviceSettings.Add);

            config.Save(ConfigurationSaveMode.Modified);
        }


        public static IEnumerator<DeviceSettings> AllSettings
        {
            get { return deviceSettings.Values.GetEnumerator(); }
        }

        public static void ClearSettings()
        {
            deviceSettings.Clear();
        }

        public static DeviceSettings GetEndpointSettings(string deviceId)
        {
            DeviceSettings settings;
            deviceSettings.TryGetValue(deviceId, out settings);

            return settings;
        }

        public static void SetEndpointSettings(DeviceSettings settings)
        {
            deviceSettings[settings.DeviceId] = settings;
        }
    }
}
