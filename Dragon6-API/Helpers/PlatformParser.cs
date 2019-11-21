// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace Dragon6.API.Helpers
{
    public class PlatformParser
    {
        /// <summary>
        ///     Convert Platform ID -> API Enum
        /// </summary>
        public static References.Platforms GetPlatform(string platformid) =>
            (References.Platforms) Enum.Parse(typeof(References.Platforms), platformid);
    }
}