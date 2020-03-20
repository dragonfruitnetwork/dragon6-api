// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class PlayerLevelStats
    {
        [JsonProperty("profile")]
        public string Guid { get; set; }

        [JsonProperty("xp")]
        public uint XP { get; set; }

        [JsonProperty("lootbox_probability")]
        public uint AlphaChances { get; set; }

        [JsonProperty("level")]
        public uint Level { get; set; }
    }
}
