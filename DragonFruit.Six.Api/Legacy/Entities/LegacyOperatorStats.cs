﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

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
        public uint Headshots { get; set; }

        /// <summary>
        /// Total operator downs (the player has downed)
        /// </summary>
        [JsonProperty("downs")]
        public uint Downs { get; set; }

        [JsonProperty("rounds")]
        public uint RoundsPlayed { get; set; }

        [JsonProperty("exp")]
        public uint Experience { get; set; }

        [JsonProperty("time")]
        protected internal uint Duration { get; set; }

        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);

        internal LegacyOperatorStats Clone() => (LegacyOperatorStats)MemberwiseClone();
    }
}