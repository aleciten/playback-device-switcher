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
using System.Configuration;

namespace ManicMonkey.PlaybackDeviceSwitcher.Configuration
{
    public sealed class DeviceSettingsCollection : ConfigurationElementCollection
    {
        public DeviceSettingsCollection()
        {
            var deviceSettings = (DeviceSettingsElement)CreateNewElement();
            Add(deviceSettings);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DeviceSettingsElement();
        }

        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((DeviceSettingsElement)element).DeviceId;
        }

        public DeviceSettingsElement this[int index]
        {
            get
            {
                return (DeviceSettingsElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }

        new public DeviceSettingsElement this[string DeviceId]
        {
            get
            {
                return (DeviceSettingsElement)BaseGet(DeviceId);
            }
        }

        public int IndexOf(DeviceSettingsElement deviceSettings)
        {
            return BaseIndexOf(deviceSettings);
        }

        public void Add(DeviceSettingsElement deviceSettings)
        {
            BaseAdd(deviceSettings);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(DeviceSettingsElement deviceSettings)
        {
            if (BaseIndexOf(deviceSettings) >= 0)
                BaseRemove(deviceSettings.DeviceId);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string deviceId)
        {
            BaseRemove(deviceId);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}