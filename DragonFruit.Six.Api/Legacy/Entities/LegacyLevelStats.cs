// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    public class LegacyLevelStats
    {
        [JsonProperty("profile_id")]
        internal string ProfileId { get; set; }

        /// <summary>
        /// Current level experience
        /// </summary>
        [JsonProperty("xp")]
        public uint Experience { get; set; }

        /// <summary>
        /// Chances of an alpha pack (* 10^-2)
        /// </summary>
        [JsonProperty("lootbox_probability")]
        public uint AlphaChances { get; set; }

        /// <summary>
        /// Current player level
        /// </summary>
        [JsonProperty("level")]
        public uint Level { get; set; }
    }
}
