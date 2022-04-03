// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    public class LegacyBombModeStats : LegacyModeStats
    {
        // no bonus stats right now...
    }

    public class LegacyHostageModeStats : LegacyModeStats
    {
        /// <summary>
        /// The number of hostages the player has rescued
        /// </summary>
        [JsonProperty("rescues")]
        public int Rescues { get; set; }

        /// <summary>
        /// Number of people killed while inside the room with the hostage
        /// </summary>
        [JsonProperty("defenses")]
        public int Defenses { get; set; }
    }

    public class LegacySecureModeStats : LegacyModeStats
    {
        [JsonProperty("aggressions")]
        public int Aggressions { get; set; }

        /// <summary>
        /// People killed securing the room
        /// </summary>
        [JsonProperty("defenses")]
        public int Defenses { get; set; }

        /// <summary>
        /// Rooms successfully secured
        /// </summary>
        [JsonProperty("hacks")]
        public int Captures { get; set; }
    }

    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LegacyModeStats
    {
        private float? _wl;
        private TimeSpan? _timePlayed;

        /// <summary>
        /// Total wins in mode
        /// </summary>
        [JsonProperty("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// Total losses in mode
        /// </summary>
        [JsonProperty("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// Sum of all matches played
        /// </summary>
        [JsonProperty("total_matches")]
        public int MatchesPlayed { get; set; }

        /// <summary>
        /// Highest score achieved
        /// </summary>
        [JsonProperty("highscore")]
        public int Highscore { get; set; }

        [JsonProperty("time")]
        protected internal uint Duration { get; set; }

        [JsonProperty("wl")]
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);

        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);
    }
}
