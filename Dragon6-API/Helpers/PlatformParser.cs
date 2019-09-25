using System;

namespace Dragon6.API.Helpers
{
    public class PlatformParser
    {
        /// <summary>
        /// Convert Platform ID -> API Enum
        /// </summary>
        public static References.Platforms GetPlatform(string platformid) => (References.Platforms)Enum.Parse(typeof(References.Platforms), platformid); 
    }
}
