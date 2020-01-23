// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Stats
{
    public class GeneralStats
    {
        public static async Task<GeneralStats> GetStats(AccountInfo account, string token) => (await GetStats(new[] { account }, token)).First();

        public static async Task<IEnumerable<GeneralStats>> GetStats(IEnumerable<AccountInfo> accounts, string token)
        {
            var results = new List<GeneralStats>();

            await foreach (var result in GetStatsAsync(accounts, token))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<GeneralStats> GetStatsAsync(IEnumerable<AccountInfo> accounts, string token)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var ids = group.Select(x => x.Guid);
                var rawData = await Task.Run(() =>
                    d6WebRequest.GetWebObject(
                        d6WebRequest.FormStatsUrl(group.Key, ids, "rankedpvp_death,rankedpvp_kdratio,rankedpvp_kills,rankedpvp_matchlost,rankedpvp_matchplayed,rankedpvp_matchwlratio,rankedpvp_matchwon,rankedpvp_timeplayed,casualpvp_death,casualpvp_kdratio,casualpvp_kills,casualpvp_matchlost,casualpvp_matchplayed,casualpvp_matchwlratio,casualpvp_matchwon,casualpvp_timeplayed,generalpvp_barricadedeployed,generalpvp_dbno,generalpvp_death,generalpvp_headshot,generalpvp_killassists,generalpvp_kills,generalpvp_matchlost,generalpvp_matchwlratio,generalpvp_matchwon,generalpvp_meleekills,generalpvp_reinforcementdeploy,generalpvp_revive,generalpvp_suicide,generalpvp_timeplayed,generalpvp_revive,generalpve_kills,generalpve_death,generalpve_matchwon,generalpve_matchlost,custompvp_timeplayed,plantbombpvp_bestscore,rescuehostagepvp_bestscore,secureareapvp_bestscore,casualpvp_timeplayed,rankedpvp_timeplayed,generalpve_timeplayed,generalpvp_bulletfired,generalpvp_penetrationkills,generalpvp_bullethit"), token));

                foreach (var id in ids)
                    yield return rawData.ToGeneralStats(id);
            }
        }

        #region Vars

        public string Guid { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("wlr")]
        public float WL { get; set; }

        [JsonProperty("matches")]
        public uint MatchesPlayed => CasualMatchesPlayed + RankedMatchesPlayed + HuntMatchesPlayed;

        [JsonProperty("casualkills")]
        public uint CasualKills { get; set; }

        [JsonProperty("casualdeaths")]
        public uint CasualDeaths { get; set; }

        [JsonProperty("casualkdr")]
        public float CasualKd { get; set; }

        [JsonProperty("casualwins")]
        public uint CasualWins { get; set; }

        [JsonProperty("casuallosses")]
        public uint CasualLosses { get; set; }

        [JsonProperty("casualwlr")]
        public float CasualWl { get; set; }

        [JsonProperty("casualmatches")]
        public uint CasualMatchesPlayed { get; set; }

        [JsonProperty("barricades")]
        public uint Barricades { get; set; }

        [JsonProperty("reinforcements")]
        public uint Reinforcements { get; set; }

        [JsonProperty("downs")]
        public uint Downs { get; set; }

        [JsonProperty("revives")]
        public uint Revives { get; set; }

        [JsonProperty("suicides")]
        public uint Suicides { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("penkills")]
        public uint Penetrations { get; set; }

        [JsonProperty("melee")]
        public uint Knifes { get; set; }

        [JsonProperty("assists")]
        public uint Assists { get; set; }

        [JsonProperty("totalshots")]
        public long ShotsFired { get; set; }

        [JsonProperty("landedshots")]
        public long ShotsConnected { get; set; }

        [JsonProperty("pvekills")]
        public uint HuntKills { get; set; }

        [JsonProperty("pvedeaths")]
        public uint HuntDeaths { get; set; }

        [JsonProperty("pvekdr")]
        public float HuntKd { get; set; }

        [JsonProperty("pvewins")]
        public uint HuntWins { get; set; }

        [JsonProperty("pvelosses")]
        public uint HuntLosses { get; set; }

        [JsonProperty("pvewlr")]
        public float HuntWl { get; set; }

        [JsonProperty("pvematches")]
        public uint HuntMatchesPlayed => HuntLosses + HuntWins;

        [JsonProperty("highscorebomb")]
        public uint HiScoreBomb { get; set; }

        [JsonProperty("highscoresecure")]
        public uint HiScoreSecure { get; set; }

        [JsonProperty("highscorehostage")]
        public uint HiScoreHostage { get; set; }

        [JsonProperty("pvetime")]
        public TimeSpan TimePlayedTHunt { get; set; }

        [JsonProperty("casualtime")]
        public TimeSpan TimePlayedCasual { get; set; }

        [JsonProperty("rankedtime")]
        public TimeSpan TimePlayedRanked { get; set; }

        [JsonProperty("overalltime")]
        public TimeSpan TimePlayedGeneral { get; set; }

        [JsonProperty("customgamestime")]
        public TimeSpan TimePlayedCustom { get; set; }

        [JsonProperty("rankedwins")]
        public uint RankedWins { get; set; }

        [JsonProperty("rankedlosses")]
        public uint RankedLosses { get; set; }

        [JsonProperty("rankedwlr")]
        public float RankedWl { get; set; }

        [JsonProperty("rankedmatches")]
        public uint RankedMatchesPlayed { get; set; }

        [JsonProperty("rankedkills")]
        public uint RankedKills { get; set; }

        [JsonProperty("rankeddeaths")]
        public uint RankedDeaths { get; set; }

        [JsonProperty("rankedkdr")]
        public float RankedKd { get; set; }

        #endregion
    }
}
