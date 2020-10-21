// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data
{
    public class OperatorStats
    {
        private float? _kd;
        private float? _wl;
        private TimeSpan? _timePlayed;

        /// <summary>
        /// User Profile ID
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Operator name (from datasheet/dictionary)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Operator Identifier (from datasheet/dictionary)
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Logical order (from datasheet/dictionary)
        /// </summary>
        public ushort Order { get; set; }

        /// <summary>
        /// Operator Icon (from datasheet)
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game (from datasheet)
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender (from datasheet)
        /// </summary>
        public OperatorType Type { get; set; }

        /// <summary>
        /// The string sent to ubi for their gadget action (from datasheet)
        /// </summary>
        public string OperatorActionId { get; set; }

        /// <summary>
        /// String used to collect the stats from ubi
        /// </summary>
        internal string OperatorActionResultId => $"{OperatorActionId}:infinite";

        /// <summary>
        /// Description of the operator's ability
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Number of times the operator has performed their ability
        /// </summary>
        public uint ActionCount { get; set; }

        /// <summary>
        /// Total operator headshots
        /// </summary>
        public uint Headshots { get; set; }

        /// <summary>
        /// Total operator downs (the player has downed)
        /// </summary>
        public uint Downs { get; set; }

        public uint Kills { get; set; }
        public uint Deaths { get; set; }

        public uint Wins { get; set; }
        public uint Losses { get; set; }

        public uint RoundsPlayed { get; set; }
        public uint Experience { get; set; }
        internal uint Duration { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);

        public int HoursPlayed => (int)TimePlayed.TotalHours;

        internal OperatorStats Clone() => (OperatorStats)MemberwiseClone();
    }
}
