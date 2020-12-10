// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class ClassicOperatorStats : ClassicStatsBase
    {
        private TimeSpan? _timePlayed;

        /// <summary>
        /// User Profile ID
        /// </summary>
        [JsonProperty("id")]
        public string Guid { get; set; }

        /// <summary>
        /// Operator name (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Operator Identifier (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("index")]
        public string Index { get; set; }

        /// <summary>
        /// Logical order (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("ord")]
        public ushort Order { get; set; }

        /// <summary>
        /// Operator Icon (from datasheet)
        /// </summary>
        [JsonProperty("img")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        [JsonProperty("org")]
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game (from datasheet)
        /// </summary>
        [JsonProperty("sub")]
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender (from datasheet)
        /// </summary>
        [JsonProperty("type")]
        public OperatorType Type { get; set; }

        /// <summary>
        /// The string sent to ubi for their gadget action (from datasheet)
        /// </summary>
        [JsonProperty("actn")]
        public string OperatorActionId { get; set; }

        /// <summary>
        /// String used to collect the stats from ubi
        /// </summary>
        [JsonIgnore]
        internal string OperatorActionResultId => OperatorActionId.ToStatsKey();

        /// <summary>
        /// Description of the operator's ability
        /// </summary>
        [JsonProperty("phrase")]
        public string Action { get; set; }

        /// <summary>
        /// Number of times the operator has performed their ability
        /// </summary>
        [JsonProperty("action_completed")]
        public uint? ActionCount { get; set; }

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

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);

        internal ClassicOperatorStats Clone() => (ClassicOperatorStats)MemberwiseClone();
    }
}
