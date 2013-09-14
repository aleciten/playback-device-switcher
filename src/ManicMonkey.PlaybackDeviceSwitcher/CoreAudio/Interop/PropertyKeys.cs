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

namespace ManicMonkey.CoreAudio.Interop
{
    internal static class PropertyKeys
    {
        public static PropertyKey PKEY_Device_DeviceDesc            = new PropertyKey(Guid.Parse("a45c254e-df1c-4efd-8020-67d146a850e0"), 2);
        public static PropertyKey PKEY_DeviceInterface_FriendlyName = new PropertyKey(Guid.Parse("026e516e-b814-414b-83cd-856d6fef4822"), 2);
        public static PropertyKey PKEY_Device_FriendlyName          = new PropertyKey(Guid.Parse("a45c254e-df1c-4efd-8020-67d146a850e0"), 14);
    }
}