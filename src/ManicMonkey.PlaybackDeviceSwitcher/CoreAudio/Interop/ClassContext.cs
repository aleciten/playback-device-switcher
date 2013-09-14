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

namespace ManicMonkey.CoreAudio.Interop
{
    internal enum ClassContext : uint
    {
        CLSCTX_INPROC_SERVER            = 0x1,
        CLSCTX_INPROC_HANDLER           = 0x2,
        CLSCTX_LOCAL_SERVER             = 0x4,
        CLSCTX_INPROC_SERVER16          = 0x8,
        CLSCTX_REMOTE_SERVER            = 0x10,
        CLSCTX_INPROC_HANDLER16         = 0x20,
        CLSCTX_RESERVED1                = 0x40,
        CLSCTX_RESERVED2                = 0x80,
        CLSCTX_RESERVED3                = 0x100,
        CLSCTX_RESERVED4                = 0x200,
        CLSCTX_NO_CODE_DOWNLOAD         = 0x400,
        CLSCTX_RESERVED5                = 0x800,
        CLSCTX_NO_CUSTOM_MARSHAL        = 0x1000,
        CLSCTX_ENABLE_CODE_DOWNLOAD     = 0x2000,
        CLSCTX_NO_FAILURE_LOG           = 0x4000,
        CLSCTX_DISABLE_AAA              = 0x8000,
        CLSCTX_ENABLE_AAA               = 0x10000,
        CLSCTX_FROM_DEFAULT_CONTEXT     = 0x20000,
        CLSCTX_ACTIVATE_32_BIT_SERVER   = 0x40000,
        CLSCTX_ACTIVATE_64_BIT_SERVER   = 0x80000,
        CLSCTX_ENABLE_CLOAKING          = 0x100000,
        CLSCTX_PS_DLL                   = 0x80000000 
    }
}