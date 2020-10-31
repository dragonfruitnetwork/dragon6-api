// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class PlayerLevelStats
    {
        /// <summary>
        /// Profile Id
        /// </summary>
        [JsonProperty("profile")]
        public string Guid { get; set; }

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
