// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Modern.Utils;
using DragonFruit.Six.Api.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonPathSerializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class ModernStatsBase
    {
        private float? _roundWl, _matchWl, _kd;
        private TimeSpan? _timePlayed, _timeAlivePerMatch, _timeDeadPerMatch;

        [JsonProperty("statsDetail")]
        public string Name { get; set; }

        [CanBeNull]
        [JsonProperty("seasonNumber")]
        public string SeasonNumber { get; set; }

        [CanBeNull]
        [JsonProperty("seasonYear")]
        public string SeasonYear { get; set; }

        #region Match Stats

        [JsonProperty("matchesWon")]
        public int MatchesWon { get; set; }

        [JsonProperty("matchesLost")]
        public int MatchesLost { get; set; }

        [JsonProperty("matchesPlayed")]
        public int MatchesPlayed { get; set; }

        public float MatchWl => _matchWl ??= RatioUtils.RatioOf(MatchesWon, MatchesLost);

        #endregion

        #region Round Stats

        [JsonProperty("roundsPlayed")]
        public int RoundsPlayed { get; set; }

        [JsonProperty("roundsWon")]
        public int RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public int RoundsLost { get; set; }

        public float RoundWl => _roundWl ??= RatioUtils.RatioOf(RoundsWon, RoundsLost);

        #endregion

        #region Kill/Deaths

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("death")]
        public int Deaths { get; set; }

        [JsonProperty("headshots")]
        public int Headshots { get; set; }

        [JsonProperty("meleeKills")]
        public int Knifes { get; set; }

        [JsonProperty("teamKills")]
        public int TeamKills { get; set; }

        [JsonProperty("openingKills")]
        public int OpeningKills { get; set; }

        [JsonProperty("openingDeaths")]
        public int OpeningDeaths { get; set; }

        [JsonProperty("trades")]
        public int Trades { get; set; }

        [JsonProperty("revives")]
        public int Revives { get; set; }

        [JsonProperty("openingKillTrades")]
        public int OpeningKillTrades { get; set; }

        [JsonProperty("openingDeathTrades")]
        public int OpeningDeathTrades { get; set; }

        #endregion

        #region Distance Stats

        [JsonProperty("distanceTravelled")]
        public float DistanceTravelled { get; set; }

        [JsonProperty("distancePerRound")]
        public float DistanceTravelledPerRound { get; set; }

        #endregion

        #region Time Played

        [JsonProperty("timeAlivePerMatch")]
        public float SecondsAlivePerMatch { get; set; }

        [JsonProperty("timeDeadPerMatch")]
        public float SecondsDeadPerMatch { get; set; }

        [JsonProperty("minutesPlayed")]
        public float MinutesPlayed { get; set; }

        public TimeSpan TimeAlivePerMatch => _timeAlivePerMatch ??= TimeSpan.FromSeconds(SecondsAlivePerMatch);
        public TimeSpan TimeDeadPerMatch => _timeDeadPerMatch ??= TimeSpan.FromSeconds(SecondsDeadPerMatch);
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromMinutes(MinutesPlayed);

        #endregion

        #region Ratios

        [JsonProperty("headshotAccuracy")]
        [JsonPath("headshotAccuracy.value")]
        public float HeadshotAccuracy { get; set; }

        [JsonProperty("killsPerRound")]
        [JsonPath("killsPerRound.value")]
        public float KillsPerRound { get; set; }

        [JsonProperty("roundsWithAKill")]
        [JsonPath("roundsWithAKill.value")]
        public float RoundsWithSingleKill { get; set; }

        [JsonProperty("roundsWithMultiKill")]
        [JsonPath("roundsWithMultiKill.value")]
        public float RoundsWithMultipleKills { get; set; }

        [JsonProperty("roundsWithOpeningKill")]
        [JsonPath("roundsWithOpeningKill.value")]
        public float RoundsWithFirstKill { get; set; }

        [JsonProperty("roundsWithOpeningDeath")]
        [JsonPath("roundsWithOpeningDeath.value")]
        public float RoundsWithFirstDeath { get; set; }

        [JsonProperty("roundsSurvived")]
        [JsonPath("roundsSurvived.value")]
        public float RoundsSurvived { get; set; }

        [JsonProperty("roundsWithAnAce")]
        [JsonPath("roundsWithAnAce.value")]
        public float RoundsAced { get; set; }

        [JsonProperty("roundsWithClutch")]
        [JsonPath("roundsWithClutch.value")]
        public float RoundsClutched { get; set; }

        /// <summary>
        /// Rounds with a kill, objective completion, survive or trade kills
        /// </summary>
        [JsonProperty("roundsWithKOST")]
        [JsonPath("roundsWithKOST.value")]
        public float RoundsWithKillObjectiveSurvivalOrTrade { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);

        #endregion
    }
}
