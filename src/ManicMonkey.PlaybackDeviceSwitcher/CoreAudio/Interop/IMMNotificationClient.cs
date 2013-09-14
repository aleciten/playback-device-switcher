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

using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ManicMonkey.CoreAudio.Interop
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(ComInterfaceId.IMMNotificationClient)]
    internal interface IMMNotificationClient
    {
        void OnDeviceStateChanged([MarshalAs(UnmanagedType.LPWStr)] string deviceId, int newState);
        
        void OnDeviceAdded([MarshalAs(UnmanagedType.LPWStr)] string deviceId);
        
        void OnDeviceRemoved([MarshalAs(UnmanagedType.LPWStr)] string deviceId);
        
        void OnDefaultDeviceChanged(DataFlow dataFlow, Role role, [MarshalAs(UnmanagedType.LPWStr)] string defaultDeviceId);
        
        void OnPropertyValueChanged([MarshalAs(UnmanagedType.LPWStr)] string deviceId, PropertyKey propertyKey);
    }

    //MIDL_INTERFACE("7991EEC9-7E89-4D85-8390-6C703CEC60C0")
    //IMMNotificationClient : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OnDeviceStateChanged( 
    //        /* [annotation][in] */ 
    //        __in  LPCWSTR pwstrDeviceId,
    //        /* [annotation][in] */ 
    //        __in  DWORD dwNewState) = 0;
        
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OnDeviceAdded( 
    //        /* [annotation][in] */ 
    //        __in  LPCWSTR pwstrDeviceId) = 0;
        
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OnDeviceRemoved( 
    //        /* [annotation][in] */ 
    //        __in  LPCWSTR pwstrDeviceId) = 0;
        
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OnDefaultDeviceChanged( 
    //        /* [annotation][in] */ 
    //        __in  EDataFlow flow,
    //        /* [annotation][in] */ 
    //        __in  ERole role,
    //        /* [annotation][in] */ 
    //        __in  LPCWSTR pwstrDefaultDeviceId) = 0;
        
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OnPropertyValueChanged( 
    //        /* [annotation][in] */ 
    //        __in  LPCWSTR pwstrDeviceId,
    //        /* [annotation][in] */ 
    //        __in  const PROPERTYKEY key) = 0;
        
    //};
}
