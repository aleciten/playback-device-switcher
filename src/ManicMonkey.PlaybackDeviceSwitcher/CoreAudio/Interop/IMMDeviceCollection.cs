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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(ComInterfaceId.IMMDeviceCollection)]
    internal interface IMMDeviceCollection
    {
        [return: MarshalAs(UnmanagedType.U4)]
        int GetCount();

        [return: MarshalAs(UnmanagedType.Interface)]
        IMMDevice Item(int index);
    }

    //MIDL_INTERFACE("0BD7A1BE-7A1A-44DB-8397-CC5392387B5E")
    //IMMDeviceCollection : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetCount(
    //        /* [annotation][out] */
    //        __out  UINT *pcDevices) = 0;

    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Item(
    //        /* [annotation][in] */
    //        __in  UINT nDevice,
    //        /* [annotation][out] */
    //        __out  IMMDevice **ppDevice) = 0;

    //};
}