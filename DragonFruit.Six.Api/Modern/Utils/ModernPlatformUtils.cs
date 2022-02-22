// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Accounts.Enums;

namespace DragonFruit.Six.Api.Modern.Utils
{
    public static class ModernPlatformUtils
    {
        /// <summary>
        /// Converts a <see cref="Platform"/> enum to its modern string equivalent.
        /// </summary>
        public static string ModernName(this Platform platform) => platform switch
        {
            Platform.PC => "PC",
            Platform.PSN => "PSN",
            Platform.XB1 => "XONE",

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
