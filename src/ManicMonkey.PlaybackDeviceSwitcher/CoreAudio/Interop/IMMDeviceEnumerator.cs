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
using System.Text;

namespace ManicMonkey.CoreAudio.Interop
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A95664D2-9614-4F35-A746-DE8DB63617E6")]
    internal interface IMMDeviceEnumerator
    {
        uint EnumAudioEndpoints(DataFlow dataFlow, DeviceState stateMask, [MarshalAs(UnmanagedType.Interface)] out IMMDeviceCollection deviceCollection);

        uint GetDefaultAudioEndpoint(DataFlow dataFlow, Role role, [MarshalAs(UnmanagedType.Interface)] out IMMDevice device);

        uint GetDevice(string deviceId, [MarshalAs(UnmanagedType.Interface)] out IMMDevice device);

        uint RegisterEndpointNotificationCallback(IMMNotificationClient notificationClient);

        uint UnregisterEndpointNotificationCallback(IMMNotificationClient notificationClient);
    }
}

//   MIDL_INTERFACE("A95664D2-9614-4F35-A746-DE8DB63617E6")
//   IMMDeviceEnumerator : public IUnknown
//   {
//   public:
//       virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE EnumAudioEndpoints(
//           /* [annotation][in] */
//           __in  EDataFlow dataFlow,
//           /* [annotation][in] */
//           __in  DWORD dwStateMask,
//           /* [annotation][out] */
//           __out  IMMDeviceCollection **ppDevices) = 0;

//       virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDefaultAudioEndpoint(
//           /* [annotation][in] */
//           __in  EDataFlow dataFlow,
//           /* [annotation][in] */
//           __in  ERole role,
//           /* [annotation][out] */
//           __out  IMMDevice **ppEndpoint) = 0;

//       virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDevice(
//           /* [annotation][in] */
//           __in  LPCWSTR pwstrId,
//           /* [annotation][out] */
//           __out  IMMDevice **ppDevice) = 0;

//       virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE RegisterEndpointNotificationCallback(
//           /* [annotation][in] */
//           __in  IMMNotificationClient *pClient) = 0;

//       virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE UnregisterEndpointNotificationCallback(
//           /* [annotation][in] */
//           __in  IMMNotificationClient *pClient) = 0;

//   };

//DEVICE_STATE_ACTIVE
//0x00000001
//The audio endpoint device is active. That is, the audio adapter that connects to the endpoint device is present and enabled. In addition, if the endpoint device plugs into a jack on the adapter, then the endpoint device is plugged in.

//DEVICE_STATE_DISABLED
//0x00000002
//The audio endpoint device is disabled. The user has disabled the device in the Windows multimedia control panel, Mmsys.cpl. For more information, see Remarks.

//DEVICE_STATE_NOTPRESENT
//0x00000004
//The audio endpoint device is not present because the audio adapter that connects to the endpoint device has been removed from the system, or the user has disabled the adapter device in Device Manager.

//DEVICE_STATE_UNPLUGGED
//0x00000008
//The audio endpoint device is unplugged. The audio adapter that contains the jack for the endpoint device is present and enabled, but the endpoint device is not plugged into the jack. Only a device with jack-presence detection can be in this state. For more information about jack-presence detection, see Audio Endpoint Devices.

//DEVICE_STATEMASK_ALL
//0x0000000F 