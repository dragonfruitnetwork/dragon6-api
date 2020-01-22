// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.API.Helpers
{
    public class PlatformParser
    {
        /// <summary>
        ///     Convert Platform ID -> API Enum
        /// </summary>
        public static References.Platforms GetPlatform(string platformId) => (References.Platforms)Enum.Parse(typeof(References.Platforms), platformId);

        /// <summary>
        /// Ubisoft string to <see cref="References.Platforms"/> (reverses <see cref="PlatformIdentifierFor"/>)
        /// </summary>
        public static References.Platforms PlatformEnumFor(string platformName) => platformName switch
        {
            "uplay" => References.Platforms.PC,
            "psn" => References.Platforms.PSN,
            "xbl" => References.Platforms.XB1,
            _ => throw new ArgumentException("Cannot find the specified platform")
        };

        /// <summary>
        /// <see cref="References.Platforms"/> Identifier to Ubisoft string (reverses <see cref="PlatformEnumFor"/>)
        /// </summary>
        public static string PlatformIdentifierFor(References.Platforms platform) => platform switch
        {
            References.Platforms.PSN => "psn",
            References.Platforms.XB1 => "xbl",
            References.Platforms.PC => "uplay",
            _ => throw new ArgumentException("Platform Not Found")
        };
    }
}
