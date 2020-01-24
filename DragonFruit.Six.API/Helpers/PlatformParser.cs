// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.API.Helpers
{
    public static class PlatformParser
    {
        /// <summary>
        /// Convert Platform ID -> API Enum
        /// </summary>
        public static Platforms GetPlatform(string platformId) => (Platforms)Enum.Parse(typeof(Platforms), platformId);

        /// <summary>
        /// Ubisoft string to <see cref="Platforms"/> (reverses <see cref="PlatformIdentifierFor"/>)
        /// </summary>
        public static Platforms PlatformEnumFor(string platformName) => platformName switch
        {
            "uplay" => Platforms.PC,
            "psn" => Platforms.PSN,
            "xbl" => Platforms.XB1,
            _ => throw new ArgumentException("Cannot find the specified platform")
        };

        /// <summary>
        /// <see cref="Platforms"/> Identifier to Ubisoft string (reverses <see cref="PlatformEnumFor"/>)
        /// </summary>
        public static string PlatformIdentifierFor(Platforms platform) => platform switch
        {
            Platforms.PSN => "psn",
            Platforms.XB1 => "xbl",
            Platforms.PC => "uplay",
            _ => throw new ArgumentException("Platform Not Found")
        };
    }
}
