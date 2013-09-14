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
using System.Runtime.InteropServices;
using ManicMonkey.CoreAudio.Interop;

namespace ManicMonkey.CoreAudio
{
    public class Endpoint : IDisposable
    {
        private const string EndpointInvalidStateMessage = "The endpoint is in an invalid state for this operation";
        private bool disposed = false;

        private Guid internalChangeId = Guid.NewGuid();
        private IMMDevice comDevice;
        private IMMEndpoint comEndpoint;

        internal Endpoint(IMMDevice device)
        {
            this.comDevice = device;
            this.comEndpoint = device as IMMEndpoint;
        }

        ~Endpoint()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }

                this.comEndpoint = null;
                this.comDevice = null;
                
                disposed = true;
            }
        }

        internal static Endpoint Create(IMMDevice device)
        {
            var endpoint = new Endpoint(device);

            IPropertyStore propStore;
            Marshal.ThrowExceptionForHR(endpoint.comDevice.OpenPropertyStore(StorageAccessMode.Read, out propStore));

            PropVariant propVariant;

            propVariant = propStore.GetValue(PropertyKeys.PKEY_DeviceInterface_FriendlyName);
            endpoint.DeviceName = propVariant.GetValueAndDispose<string>();

            propVariant = propStore.GetValue(PropertyKeys.PKEY_Device_DeviceDesc);
            endpoint.Name = propVariant.GetValueAndDispose<string>();

            propVariant = propStore.GetValue(PropertyKeys.PKEY_Device_FriendlyName);
            endpoint.FullName = propVariant.GetValueAndDispose<string>();

            string endpointId;
            Marshal.ThrowExceptionForHR(endpoint.comDevice.GetId(out endpointId));
            endpoint.EndpointId = endpointId;

            return endpoint;
        }

        /// <summary>
        /// Gets the endpoint's unique identifier
        /// </summary>
        public string EndpointId { get; private set; }

        /// <summary>
        /// Gets the endpoint's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the device to which the endpoint is attached
        /// </summary>
        public string DeviceName { get; private set; }

        /// <summary>
        /// Gets the endpoint's qualified name (device name + endpoint name)
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Indicates whether the audio endpoint device is a rendering device or a capture device.
        /// </summary>
        public DataFlow DataFlow
        {
            get
            {
                DataFlow flow;
                Marshal.ThrowExceptionForHR(comEndpoint.GetDataFlow(out flow));
                return flow;
            }
        }

        /// <summary>
        /// Gets the current state of the device
        /// </summary>
        public DeviceState DeviceState
        {
            get
            {
                DeviceState state;
                Marshal.ThrowExceptionForHR(comDevice.GetState(out state));
                return state;
            }
        }
    }
}