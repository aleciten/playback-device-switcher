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
    [Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
    internal class MMDeviceEnumerator
    {
    }

    //-		{CLSID_MMDeviceEnumerator class}	_GUID
    //        Data1	0xbcde0395	unsigned int
    //        Data2	0xe52f	unsigned short
    //        Data3	0x467c	unsigned short
    //-		Data4	{Length=0x8}	unsigned char[]
    //        [0x0]	0x8e '?'	unsigned char
    //        [0x1]	0x3d '='	unsigned char
    //        [0x2]	0xc4 'Ä'	unsigned char
    //        [0x3]	0x57 'W'	unsigned char
    //        [0x4]	0x92 '?'	unsigned char
    //        [0x5]	0x91 '?'	unsigned char
    //        [0x6]	0x69 'i'	unsigned char
    //        [0x7]	0x2e '.'	unsigned char
}