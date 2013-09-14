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
using ManicMonkey.CoreAudio.Interop;

namespace ManicMonkey.CoreAudio
{
    public class EndpointManager : IMMNotificationClient
    {
        private readonly IMMDeviceEnumerator deviceEnumerator;

        public event EventHandler<DefaultEndpointChangedEventArgs> DefaultEndpointChanged;        
        public event EventHandler<EndpointStateChangedEventArgs> EndpointStateChanged;
        public event EventHandler<EndpointEventArgs> EndpointRemoved;
        public event EventHandler<EndpointEventArgs> EndpointAdded;

        public EndpointManager()
        {
            deviceEnumerator = new MMDeviceEnumerator() as IMMDeviceEnumerator;
            deviceEnumerator.RegisterEndpointNotificationCallback(this);
        }

        ~EndpointManager()
        {
        }

        /// <summary>
        /// Gets the system's default audio endpoint for the specified data flow direction and role
        /// </summary>
        public Endpoint GetDefaultEndpoint(DataFlow flow, Role role)
        {
            IMMDevice device;
            deviceEnumerator.GetDefaultAudioEndpoint(flow, role, out device);
            
            return Endpoint.Create(device);
        }

        /// <summary>
        /// Gets the system's audio endpoints filtered by data flow direction and device state
        /// </summary>
        public EndpointCollection GetEndpoints(DataFlow dataFlow, DeviceState deviceState)
        {
            var endpoints = new EndpointCollection();

            IMMDeviceCollection collection;
            deviceEnumerator.EnumAudioEndpoints(dataFlow, deviceState, out collection);

            for (var i = 0; i < collection.GetCount(); i++)
            {
                var device = collection.Item(i);
                var endpoint = Endpoint.Create(device);

                endpoints.Add(endpoint);
            }

            return endpoints;
        }      
        
        public Endpoint GetEndpointById(string endpointId)
        {
            IMMDevice device;
            deviceEnumerator.GetDevice(endpointId, out device);

            return Endpoint.Create(device);
        }

        /// <summary>
        /// Sets the system's default audio endpoint for all roles (Console, Multimedia, Communications)
        /// </summary>
        /// <remarks>
        /// This is an unpublished API and therefore may not work on Windows versions later than 7.
        /// </remarks>
        public static void SetDefaultEndpoint(string endpointId)
        {
            var policyConfig = new PolicyConfig() as IPolicyConfig;
            
            policyConfig.SetDefaultEndpoint(endpointId, Role.Console);
            policyConfig.SetDefaultEndpoint(endpointId, Role.Multimedia);
            policyConfig.SetDefaultEndpoint(endpointId, Role.Communications);
        }

        /// <summary>
        /// Sets the system's default audio endpoint for a specific role.
        /// </summary>
        /// <remarks>
        /// This is an unpublished API and therefore may not work on Windows versions later than 7.
        /// </remarks>
        public static void SetDefaultEndpointForRole(string endpointId, Role role)
        {
            var policyConfig = new PolicyConfig() as IPolicyConfig;

            policyConfig.SetDefaultEndpoint(endpointId, role);
        }       

        #region Notification stuff
        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, int newState)
        {
            if (EndpointStateChanged != null)
                EndpointStateChanged(this, new EndpointStateChangedEventArgs(deviceId, newState));
        }

        void IMMNotificationClient.OnDeviceAdded(string deviceId)
        {
            if (EndpointAdded != null)
                EndpointAdded(this, new EndpointEventArgs(deviceId));            
        }

        void IMMNotificationClient.OnDeviceRemoved(string deviceId)
        {
            if (EndpointRemoved != null)
                EndpointRemoved(this, new EndpointEventArgs(deviceId));
        }

        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow dataFlow, Role role, string defaultDeviceId)
        {
            if (DefaultEndpointChanged != null)
                DefaultEndpointChanged(this, new DefaultEndpointChangedEventArgs(defaultDeviceId, dataFlow, role));
        }

        void IMMNotificationClient.OnPropertyValueChanged(string deviceId, PropertyKey propertyKey)
        {
            //notificationHandlers.ForEach(x => x.OnAudioEndpointAdded(GetEndpointById(deviceId)));
        }
        #endregion
    }
}
