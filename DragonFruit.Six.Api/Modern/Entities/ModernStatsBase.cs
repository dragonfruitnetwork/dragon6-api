// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
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

        #region Match Stats

        [JsonProperty("matchesWon")]
        public uint MatchesWon { get; set; }

        [JsonProperty("matchesLost")]
        public uint MatchesLost { get; set; }

        [JsonProperty("matchesPlayed")]
        public uint MatchesPlayed { get; set; }

        public float MatchWl => _matchWl ??= RatioUtils.RatioOf(MatchesWon, MatchesLost);

        #endregion

        #region Round Stats

        [JsonProperty("roundsPlayed")]
        public uint RoundsPlayed { get; set; }

        [JsonProperty("roundsWon")]
        public uint RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public uint RoundsLost { get; set; }

        public float RoundWl => _roundWl ??= RatioUtils.RatioOf(RoundsWon, RoundsLost);

        #endregion

        #region Kill/Deaths

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

        [JsonProperty("headshotAccuracy.value")]
        public float HeadshotAccuracy { get; set; }

        [JsonProperty("killsPerRound.value")]
        public float KillsPerRound { get; set; }

        [JsonProperty("roundsWithAKill.value")]
        public float RoundsWithSingleKill { get; set; }

        [JsonProperty("roundsWithMultiKill.value")]
        public float RoundsWithMultipleKills { get; set; }

        [JsonProperty("roundsWithOpeningKill.value")]
        public float RoundsWithFirstKill { get; set; }

        [JsonProperty("roundsWithOpeningDeath.value")]
        public float RoundsWithFirstDeath { get; set; }

        [JsonProperty("roundsSurvived.value")]
        public float RoundsSurvived { get; set; }

        [JsonProperty("roundsWithAnAce.value")]
        public float RoundsAced { get; set; }

        [JsonProperty("roundsWithClutch.value")]
        public float RoundsClutched { get; set; }

        /// <summary>
        /// Rounds with a kill, objective completion, survive or trade kills
        /// </summary>
        [JsonProperty("roundsWithKOST.value")]
        public float RoundsWithKillObjectiveSurvivalOrTrade { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);

        #endregion
    }
}
