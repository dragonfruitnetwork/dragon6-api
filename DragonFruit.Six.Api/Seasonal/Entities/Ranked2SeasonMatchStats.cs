// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Ranked2SeasonMatchStats
    {
        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("abandons")]
        public int Abandons { get; set; }

        public float WL => RatioUtils.RatioOf(Wins, Losses + Abandons);
    }
}
