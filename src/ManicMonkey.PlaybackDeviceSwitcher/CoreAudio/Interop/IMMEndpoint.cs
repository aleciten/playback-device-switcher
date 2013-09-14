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
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(ComInterfaceId.IMMEndpoint)]
    internal interface IMMEndpoint
    {
        int GetDataFlow(out DataFlow dataflow);
    }

    //MIDL_INTERFACE("1BE09788-6894-4089-8586-9A2A6C265AC5")
    //IMMEndpoint : public IUnknown
    //{
    //public:
    //    virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE GetDataFlow( 
    //        /* [annotation][out] */ 
    //        __out  EDataFlow *pDataFlow) = 0;
        
    //};
}
