using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon6.API.Helpers
{
    public class PlatformParser
    {
        /// <summary>
        /// Convert Platform ID -> API Enum
        /// </summary>
        public static References.Platforms GetPlatform(string platformid) => platformid == "1" ? References.Platforms.PC : platformid == "2" ? References.Platforms.PSN : References.Platforms.XB1;
    }
}
