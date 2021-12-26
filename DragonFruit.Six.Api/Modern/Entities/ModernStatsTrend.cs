// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Modern.Containers;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernStatsTrend
    {
        [JsonProperty("statsPeriod")]
        public string[] StatsPeriods { get; set; }

        #region Matches/Rounds

        [JsonProperty("matchesPlayed")]
        public int[] MatchesPlayed { get; set; }

        [JsonProperty("roundsPlayed")]
        public int[] RoundsPlayed { get; set; }

        [JsonProperty("minutesPlayed")]
        public int[] MinutesPlayed { get; set; }

        [JsonProperty("matchesWon")]
        public int[] MatchesWon { get; set; }

        [JsonProperty("matchesLost")]
        public int[] MatchesLost { get; set; }

        [JsonProperty("roundsWon")]
        public int[] RoundsWon { get; set; }

        [JsonProperty("roundsLost")]
        public int[] RoundsLost { get; set; }

        #endregion

        #region Kills/Deaths

        [JsonProperty("kills")]
        public int[] Kills { get; set; }

        [JsonProperty("assists")]
        public int[] Assists { get; set; }

        [JsonProperty("death")]
        public int[] Deaths { get; set; }

        [JsonProperty("headshots")]
        public int[] Headshots { get; set; }

        [JsonProperty("meleeKills")]
        public int[] MeleeKills { get; set; }

        [JsonProperty("teamKills")]
        public int[] TeamKills { get; set; }

        [JsonProperty("openingKills")]
        public int[] OpeningKills { get; set; }

        [JsonProperty("openingDeaths")]
        public int[] OpeningDeaths { get; set; }

        [JsonProperty("trades")]
        public int[] Trades { get; set; }

        [JsonProperty("openingKillTrades")]
        public int[] OpeningKillTrades { get; set; }

        [JsonProperty("openingDeathTrades")]
        public int[] OpeningDeathTrades { get; set; }

        [JsonProperty("revives")]
        public int[] Revives { get; set; }

        #endregion

        #region Ratios

        [JsonProperty("winLossRatio")]
        public float[] Wl { get; set; }

        [JsonProperty("killDeathRatio")]
        public float[] Kd { get; set; }

        [JsonProperty("headshotAccuracy")]
        public float[] HeadshotAccuracy { get; set; }

        [JsonProperty("killsPerRound")]
        public float[] KillsPerRound { get; set; }

        #endregion

        #region Rounds (Extended Info)

        [JsonProperty("roundsWithAKill")]
        public float[] RoundsWithAKill { get; set; }

        [JsonProperty("roundsWithMultiKill")]
        public float[] RoundsWithMultiKill { get; set; }

        [JsonProperty("roundsWithOpeningKill")]
        public float[] RoundsWithOpeningKill { get; set; }

        [JsonProperty("roundsWithOpeningDeath")]
        public float[] RoundsWithOpeningDeath { get; set; }

        [JsonProperty("roundsWithKOST")]
        public float[] RoundsWithKost { get; set; }

        [JsonProperty("roundsSurvived")]
        public float[] RoundsSurvived { get; set; }

        [JsonProperty("roundsWithAnAce")]
        public float[] RoundsWithAnAce { get; set; }

        [JsonProperty("roundsWithClutch")]
        public int[] RoundsWithClutch { get; set; }

        #endregion

        #region Time/Distance

        [JsonProperty("timeAlivePerMatch")]
        public float[] TimeAlivePerMatch { get; set; }

        [JsonProperty("timeDeadPerMatch")]
        public float[] TimeDeadPerMatch { get; set; }

        [JsonProperty("distanceTravelled")]
        public int[] DistanceTravelled { get; set; }

        [JsonProperty("distancePerRound")]
        public float[] DistancePerRound { get; set; }

        #endregion

        public IEnumerable<ModernStatsTrendPeriod<T>> Collate<T>(IEnumerable<T> data)
        {
            return StatsPeriods.Zip(data, (period, values) => new ModernStatsTrendPeriod<T>(period, values));
        }
    }
}
