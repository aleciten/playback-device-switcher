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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(ComInterfaceId.IMMDevice)]
    internal interface IMMDevice
    {
        int Activate(ref Guid interfaceId, ClassContext classContext, IntPtr activationParams, [MarshalAs(UnmanagedType.Interface)] out object requestedInterface);
        
        int OpenPropertyStore(StorageAccessMode storageAccessMode, [MarshalAs(UnmanagedType.Interface)] out IPropertyStore propertyStore);

        int GetId([MarshalAs(UnmanagedType.LPWStr)] out string deviceId);

        int GetState(out DeviceState deviceState);
    }

    //MIDL_INTERFACE("D666063F-1587-4E43-81F1-B948E807363F")
    //IMMDevice : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Activate(
    //        /* [annotation][in] */
    //        __in  REFIID iid,
    //        /* [annotation][in] */
    //        __in  DWORD dwClsCtx,
    //        /* [annotation][unique][in] */
    //        __in_opt  PROPVARIANT *pActivationParams,
    //        /* [annotation][iid_is][out] */
    //        __out  void **ppInterface) = 0;

    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE OpenPropertyStore(
    //        /* [annotation][in] */
    //        __in  DWORD stgmAccess,
    //        /* [annotation][out] */
    //        __out  IPropertyStore **ppProperties) = 0;

    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetId(
    //        /* [annotation][out] */
    //        __deref_out  LPWSTR *ppstrId) = 0;

    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetState(
    //        /* [annotation][out] */
    //        __out  DWORD *pdwState) = 0;

    //};
}