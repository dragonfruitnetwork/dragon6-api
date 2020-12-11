// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Data.Interfaces;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class ModernOperatorStats : IHasKd, IHasWl
    {
        private float? _kd, _wl;
        private TimeSpan? _timePlayed, _timeAlive, _timeDead;

        [JsonProperty("statsDetail")]
        public string Name { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        #region Kill Types

        [JsonProperty("assists")]
        public uint Assists { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("meleeKills")]
        public uint Knifes { get; set; }

        #endregion

        [JsonProperty("death")]
        public uint Deaths { get; set; }

        #region Death Types

        [JsonProperty("revives")]
        public uint Revives { get; set; }

        [JsonProperty("trades")]
        public uint Trades { get; set; }

        [JsonProperty("teamKills")]
        public uint TeamKills { get; set; }

        #endregion

        [JsonProperty("matchesWon")]
        public uint Wins { get; set; }

        [JsonProperty("matchesLost")]
        public uint Losses { get; set; }

        [JsonProperty("roundsWon")]
        public uint RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public uint RoundsLost { get; set; }

        [JsonProperty("minutesPlayed")]
        public uint MinutesPlayed { get; set; }

        [JsonProperty("distanceTravelled")]
        public float DistanceTravelled { get; set; }

        [JsonProperty("distancePerRound")]
        public float DistanceTravelledPerRound { get; set; }

        [JsonProperty("timeAlivePerMatch")]
        public float SecondsAlivePerMatch { get; set; }

        [JsonProperty("timeDeadPerMatch")]
        public float SecondsDeadPerMatch { get; set; }

        [JsonProperty("kd")]
        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);

        [JsonProperty("wl")]
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(MinutesPlayed);

        [JsonIgnore]
        public TimeSpan TimeAlivePerMatch => _timeAlive ??= TimeSpan.FromSeconds(SecondsAlivePerMatch);

        [JsonIgnore]
        public TimeSpan TimeDeadPerMatch => _timeDead ??= TimeSpan.FromSeconds(SecondsDeadPerMatch);
    }
}
