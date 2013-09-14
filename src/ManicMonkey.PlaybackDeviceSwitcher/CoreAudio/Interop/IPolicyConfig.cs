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
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace ManicMonkey.CoreAudio.Interop
{
    /// <summary>
    /// Unpublished COM interface IPolicyConfig
    /// </summary>
    /// <remarks>
    /// May change in future versions of Windows
    /// At this point: Vista, Seven
    /// </remarks>
    
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("F8679F50-850A-41CF-9C72-430F290290C8")]
    internal interface IPolicyConfig
    {
        int GetMixFormat(string deviceId, IntPtr ppFormat);

        int GetDeviceFormat(string deviceId, bool bDefault, IntPtr ppFormat);

        int ResetDeviceFormat(string deviceId);

        int SetDeviceFormat(string deviceId, IntPtr pEndpointFormat, IntPtr MixFormat);

        int GetProcessingPeriod(string deviceId, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

        int SetProcessingPeriod(string deviceId, IntPtr pmftPeriod);

        int GetShareMode(string deviceId, IntPtr pMode);

        int SetShareMode(string deviceId, IntPtr mode);

        int GetPropertyValue(string deviceId, bool bFxStore, IntPtr key, IntPtr pv);

        int SetPropertyValue(string deviceId, bool bFxStore, IntPtr key, IntPtr pv);

        int SetDefaultEndpoint(string deviceId, Role role);

        int SetEndpointVisibility(string deviceId, bool bVisible);
    }
}