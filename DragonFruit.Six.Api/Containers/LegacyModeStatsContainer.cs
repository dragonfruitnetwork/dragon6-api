// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Containers
{
    public class LegacyBombModeStats : LegacyModeStatsContainer
    {
        // no bonus stats right now...
    }

    public class LegacyHostageModeStats : LegacyModeStatsContainer
    {
        /// <summary>
        /// The number of hostages the player has rescued
        /// </summary>
        [JsonProperty("rescues")]
        public uint Rescues { get; set; }

        /// <summary>
        /// Number of people killed while inside the room with the hostage
        /// </summary>
        [JsonProperty("defenses")]
        public uint Defenses { get; set; }
    }

    public class LegacySecureModeStats : LegacyModeStatsContainer
    {
        [JsonProperty("aggressions")]
        public uint Aggressions { get; set; }

        /// <summary>
        /// People killed securing the room
        /// </summary>
        [JsonProperty("defenses")]
        public uint Defenses { get; set; }

        /// <summary>
        /// Rooms successfully secured
        /// </summary>
        [JsonProperty("hacks")]
        public uint Captures { get; set; }
    }

    public abstract class LegacyModeStatsContainer : IHasWl
    {
        private float? _wl;
        private TimeSpan? _timePlayed;

        /// <summary>
        /// Total wins in mode
        /// </summary>
        [JsonProperty("wins")]
        public uint Wins { get; set; }

        /// <summary>
        /// Total losses in mode
        /// </summary>
        [JsonProperty("losses")]
        public uint Losses { get; set; }

        /// <summary>
        /// Sum of all matches played
        /// </summary>
        [JsonProperty("total_matches")]
        public uint MatchesPlayed { get; set; }

        /// <summary>
        /// Highest score achieved
        /// </summary>
        [JsonProperty("highscore")]
        public uint Highscore { get; set; }

        [JsonProperty("time")]
        protected internal uint Duration { get; set; }

        [JsonProperty("wl")]
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);
    }
}
