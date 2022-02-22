// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

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
        public uint Kills { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("headshotAccuracy")]
        public float HeadshotAccuracy { get; set; }

        [JsonProperty("roundsWon")]
        public uint Wins { get; set; }

        [JsonProperty("roundsLost")]
        public uint Losses { get; set; }

        [JsonProperty("roundsPlayed")]
        public uint RoundsPlayed { get; set; }

        [JsonProperty("roundsWithAKill")]
        public float RoundsWithSingleKill { get; set; }

        [JsonProperty("roundsWithAMultiKill")]
        public float RoundsWithMultipleKills { get; set; }

        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);
    }
}
