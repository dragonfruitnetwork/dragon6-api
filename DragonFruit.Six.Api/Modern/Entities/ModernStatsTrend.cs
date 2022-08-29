// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Modern.Containers;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernStatsTrend
    {
        [JsonProperty("winLossRatio")]
        public ModernStatsTrendPointCollection Wl { get; set; }

        [JsonProperty("killDeathRatio")]
        public ModernStatsTrendPointCollection Kd { get; set; }

        [JsonProperty("headshotAccuracy")]
        public ModernStatsTrendPointCollection HeadshotAccuracy { get; set; }

        [JsonProperty("killsPerRound")]
        public ModernStatsTrendPointCollection KillsPerRound { get; set; }

        [JsonProperty("roundsWithAKill")]
        public ModernStatsTrendPointCollection RoundsWithAKill { get; set; }

        [JsonProperty("roundsWithMultiKill")]
        public ModernStatsTrendPointCollection RoundsWithMultiKill { get; set; }

        [JsonProperty("roundsWithOpeningKill")]
        public ModernStatsTrendPointCollection RoundsWithOpeningKill { get; set; }

        [JsonProperty("roundsWithOpeningDeath")]
        public ModernStatsTrendPointCollection RoundsWithOpeningDeath { get; set; }

        [JsonProperty("roundsWithKOST")]
        public ModernStatsTrendPointCollection RoundsWithKost { get; set; }

        [JsonProperty("roundsSurvived")]
        public ModernStatsTrendPointCollection RoundsSurvived { get; set; }

        [JsonProperty("ratioTimeAlivePerMatch")]
        public ModernStatsTrendPointCollection TimeAlivePerMatch { get; set; }

        [JsonProperty("distancePerRound")]
        public ModernStatsTrendPointCollection DistancePerRound { get; set; }
    }
}
