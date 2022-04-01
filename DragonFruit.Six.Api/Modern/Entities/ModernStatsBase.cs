// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Utils;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(JsonPathConverter))]
    public abstract class ModernStatsBase
    {
        private float? _roundWl, _matchWl, _kd;
        private TimeSpan? _timePlayed, _timeAlivePerMatch, _timeDeadPerMatch;

        [JsonProperty("statsDetail")]
        public string Name { get; set; }

        [JsonProperty("matchesWon")]
        public uint MatchesWon { get; set; }

        [JsonProperty("matchesLost")]
        public uint MatchesLost { get; set; }

        [JsonProperty("matchesPlayed")]
        public uint MatchesPlayed { get; set; }

        [JsonProperty("roundsWon")]
        public uint RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public uint RoundsLost { get; set; }

        [JsonProperty("roundsPlayed")]
        public uint RoundsPlayed { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("assists")]
        public uint Assists { get; set; }

        [JsonProperty("death")]
        public uint Deaths { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("meleeKills")]
        public uint Knifes { get; set; }

        [JsonProperty("teamKills")]
        public uint TeamKills { get; set; }

        [JsonProperty("openingKills")]
        public uint OpeningKills { get; set; }

        [JsonProperty("openingDeaths")]
        public uint OpeningDeaths { get; set; }

        [JsonProperty("trades")]
        public uint Trades { get; set; }

        [JsonProperty("revives")]
        public uint Revives { get; set; }

        [JsonProperty("openingKillTrades")]
        public uint OpeningKillTrades { get; set; }

        [JsonProperty("openingDeathTrades")]
        public uint OpeningDeathTrades { get; set; }

        [JsonProperty("distanceTravelled")]
        public float DistanceTravelled { get; set; }

        [JsonProperty("distancePerRound")]
        public float DistanceTravelledPerRound { get; set; }

        [JsonProperty("timeAlivePerMatch")]
        public float SecondsAlivePerMatch { get; set; }

        [JsonProperty("timeDeadPerMatch")]
        public float SecondsDeadPerMatch { get; set; }

        [JsonProperty("minutesPlayed")]
        public float MinutesPlayed { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);
        public float MatchWl => _matchWl ??= RatioUtils.RatioOf(MatchesWon, MatchesLost);
        public float RoundWl => _roundWl ??= RatioUtils.RatioOf(RoundsWon, RoundsLost);

        public TimeSpan TimeAlivePerMatch => _timeAlivePerMatch ??= TimeSpan.FromSeconds(SecondsAlivePerMatch);
        public TimeSpan TimeDeadPerMatch => _timeDeadPerMatch ??= TimeSpan.FromSeconds(SecondsDeadPerMatch);
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromMinutes(MinutesPlayed);

        public RatioBackedStat HeadshotAccuracy { get; set; }
        public RatioBackedStat KillsPerRound { get; set; }
        public RatioBackedStat RoundsWithSingleKill { get; set; }
        public RatioBackedStat RoundsWithMultipleKills { get; set; }
        public RatioBackedStat RoundsWithFirstKill { get; set; }
        public RatioBackedStat RoundsWithFirstDeath { get; set; }
        public RatioBackedStat RoundsSurvived { get; set; }
        public RatioBackedStat RoundsAced { get; set; }
        public RatioBackedStat RoundsClutched { get; set; }

        /// <summary>
        /// Rounds with a kill, objective completion, survive or trade kills
        /// </summary>
        public RatioBackedStat RoundsWithKillObjectiveSurvivalOrTrade { get; set; }

        #region Ratio Backing Fields

        [JsonProperty("headshotAccuracy.value", Order = 1)]
        private float HeadshotAccuracyRatio
        {
            set => HeadshotAccuracy = new RatioBackedStat(Kills, value);
        }

        [JsonProperty("killsPerRound.value", Order = 1)]
        private float KillsPerRoundRatio
        {
            set => KillsPerRound = new RatioBackedStat(Kills, value);
        }

        [JsonProperty("roundsWithAKill.value", Order = 1)]
        private float RoundsWithSingleKillRatio
        {
            set => RoundsWithSingleKill = new RatioBackedStat(Kills, value);
        }

        [JsonProperty("roundsWithMultiKill.value", Order = 1)]
        private float RoundsWithMultipleKillsRatio
        {
            set => RoundsWithMultipleKills = new RatioBackedStat(Kills, value);
        }

        [JsonProperty("roundsWithOpeningKill.value", Order = 1)]
        private float RoundsWithFirstKillRatio
        {
            set => RoundsWithFirstKill = new RatioBackedStat(Kills, value);
        }

        [JsonProperty("roundsWithOpeningDeath.value", Order = 1)]
        private float RoundsWithFirstDeathRatio
        {
            set => RoundsWithFirstDeath = new RatioBackedStat(RoundsPlayed, value);
        }

        [JsonProperty("roundsSurvived.value", Order = 1)]
        private float RoundsSurvivedRatio
        {
            set => RoundsSurvived = new RatioBackedStat(RoundsPlayed, value);
        }

        [JsonProperty("roundsWithAnAce.value", Order = 1)]
        private float RoundsAcedRatio
        {
            set => RoundsAced = new RatioBackedStat(RoundsPlayed, value);
        }

        [JsonProperty("roundsWithClutch.value", Order = 1)]
        private float RoundsClutchedRatio
        {
            set => RoundsClutched = new RatioBackedStat(RoundsPlayed, value);
        }

        [JsonProperty("roundsWithKOST.value", Order = 1)]
        private float RoundsWithKillObjectiveSurvivalOrTradeRatio
        {
            set => RoundsWithKillObjectiveSurvivalOrTrade = new RatioBackedStat(RoundsPlayed, value);
        }

        #endregion
    }
}
