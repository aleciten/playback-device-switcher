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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(ComInterfaceId.IPropertyStore)]
    internal interface IPropertyStore
    {
        [return: MarshalAs(UnmanagedType.U4)]
        uint GetCount();

        [return: MarshalAs(UnmanagedType.Struct)]
        PropertyKey GetAt(int prop);

        [return: MarshalAs(UnmanagedType.Struct)]
        PropVariant GetValue(ref PropertyKey key);

        void SetValue(ref PropertyKey key, ref PropVariant propvar);
    }

    //MIDL_INTERFACE("886d8eeb-8cf2-4446-8d02-cdba1dbdcf99")
    //IPropertyStore : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetCount(
    //        /* [out] */ __RPC__out DWORD *cProps) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetAt(
    //        /* [in] */ DWORD iProp,
    //        /* [out] */ __RPC__out PROPERTYKEY *pkey) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetValue(
    //        /* [in] */ __RPC__in REFPROPERTYKEY key,
    //        /* [out] */ __RPC__out PROPVARIANT *pv) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetValue(
    //        /* [in] */ __RPC__in REFPROPERTYKEY key,
    //        /* [in] */ __RPC__in REFPROPVARIANT propvar) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Commit( void) = 0;

    //};
}