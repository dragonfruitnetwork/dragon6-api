// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    public class ModernSeasonStats : ModernStatsBase
    {
        [JsonProperty("seasonYear")]
        public string Year { get; set; }

        [JsonProperty("seasonNumber")]
        public string SeasonNumber { get; set; }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // override the default season as it will always be "summary"
            Name = $"{Year}{SeasonNumber}";
        }
    }
}
