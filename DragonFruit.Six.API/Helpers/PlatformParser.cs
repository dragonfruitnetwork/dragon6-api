// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Helpers
{
    public static class PlatformParser
    {
        /// <summary>
        /// Convert Platform ID -> API Enum
        /// </summary>
        public static Platform GetPlatform(string platformId) => (Platform)Enum.Parse(typeof(Platform), platformId);

        /// <summary>
        /// Ubisoft string to <see cref="Platform"/> (reverses <see cref="PlatformIdentifierFor"/>)
        /// </summary>
        public static Platform PlatformEnumFor(string platformName) => platformName switch
        {
            "uplay" => Platform.PC,
            "psn" => Platform.PSN,
            "xbl" => Platform.XB1,
            _ => throw new ArgumentException("Cannot find the specified platform")
        };

        /// <summary>
        /// <see cref="Platform"/> Identifier to Ubisoft string (reverses <see cref="PlatformEnumFor"/>)
        /// </summary>
        public static string PlatformIdentifierFor(Platform platform) => platform switch
        {
            Platform.PSN => "psn",
            Platform.XB1 => "xbl",
            Platform.PC => "uplay",
            _ => throw new ArgumentException("Platform Not Found")
        };
    }
}
