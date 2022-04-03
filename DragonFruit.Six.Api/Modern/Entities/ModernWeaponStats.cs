// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    /// <summary>
    /// Object containing stats for a specific weapon
    /// </summary>
    /// <remarks>
    /// Wins/Losses are recorded per round
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernWeaponStats
    {
        private float? _wl;

        [JsonProperty("weaponName")]
        public string Name { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("headshots")]
        public int Headshots { get; set; }

        [JsonProperty("headshotAccuracy")]
        public float HeadshotAccuracy { get; set; }

        [JsonProperty("roundsWon")]
        public int Wins { get; set; }

        [JsonProperty("roundsLost")]
        public int Losses { get; set; }

        [JsonProperty("roundsPlayed")]
        public int RoundsPlayed { get; set; }

        [JsonProperty("roundsWithAKill")]
        public float RoundsWithSingleKill { get; set; }

        [JsonProperty("roundsWithAMultiKill")]
        public float RoundsWithMultipleKills { get; set; }

        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);
    }
}
