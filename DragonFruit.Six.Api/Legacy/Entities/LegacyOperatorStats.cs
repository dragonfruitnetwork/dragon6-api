// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    [DebuggerDisplay("ProfileId = {ProfileId}, Index = {OperatorId}")]
    public class LegacyOperatorStats : LegacyStatsBase
    {
        private TimeSpan? _timePlayed;

        [JsonProperty("profile_id")]
        internal string ProfileId { get; set; }

        /// <summary>
        /// Represents the internal Ubisoft identifier for the current operator
        /// </summary>
        [JsonProperty("index")]
        public string OperatorId { get; set; }

        /// <summary>
        /// Total operator headshots
        /// </summary>
        [JsonProperty("headshots")]
        public int Headshots { get; set; }

        /// <summary>
        /// Total operator downs (the player has downed)
        /// </summary>
        [JsonProperty("downs")]
        public int Downs { get; set; }

        [JsonProperty("rounds")]
        public int RoundsPlayed { get; set; }

        [JsonProperty("exp")]
        public int Experience { get; set; }

        [JsonProperty("time")]
        protected internal int Duration { get; set; }

        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);

        internal LegacyOperatorStats Clone() => (LegacyOperatorStats)MemberwiseClone();
    }
}
