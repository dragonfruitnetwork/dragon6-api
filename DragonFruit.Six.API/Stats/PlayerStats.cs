// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;

namespace DragonFruit.Six.API.Stats
{
    public class GeneralStats
    {
        public static async Task<GeneralStats> GetStats(AccountInfo account, string token) => (await GetStats(new[] { account }, token).ConfigureAwait(false)).First();

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
                        d6WebRequest.FormStatsUrl(group.Key, ids,
                            "rankedpvp_death,rankedpvp_kdratio,rankedpvp_kills,rankedpvp_matchlost,rankedpvp_matchplayed,rankedpvp_matchwlratio,rankedpvp_matchwon,rankedpvp_timeplayed,casualpvp_death,casualpvp_kdratio,casualpvp_kills,casualpvp_matchlost,casualpvp_matchplayed,casualpvp_matchwlratio,casualpvp_matchwon,casualpvp_timeplayed,generalpvp_barricadedeployed,generalpvp_dbno,generalpvp_death,generalpvp_headshot,generalpvp_killassists,generalpvp_kills,generalpvp_matchlost,generalpvp_matchwlratio,generalpvp_matchwon,generalpvp_meleekills,generalpvp_reinforcementdeploy,generalpvp_revive,generalpvp_suicide,generalpvp_timeplayed,generalpvp_revive,generalpve_kills,generalpve_death,generalpve_matchwon,generalpve_matchlost,custompvp_timeplayed,plantbombpvp_bestscore,rescuehostagepvp_bestscore,secureareapvp_bestscore,casualpvp_timeplayed,rankedpvp_timeplayed,generalpve_timeplayed,generalpvp_bulletfired,generalpvp_penetrationkills,generalpvp_bullethit"),
                        token));

                foreach (var id in ids)
                    yield return rawData.ToGeneralStats(id);
            }
        }

        #region Vars

        public string Guid { get; set; }

        public uint Wins { get; set; }

        public uint Losses { get; set; }

        public uint Kills { get; set; }

        public uint Deaths { get; set; }

        public float WL { get; set; }

        public uint MatchesPlayed => CasualMatchesPlayed + RankedMatchesPlayed + TrainingMatchesPlayed;

        public uint CasualKills { get; set; }

        public uint CasualDeaths { get; set; }

        public float CasualKd { get; set; }

        public uint CasualWins { get; set; }

        public uint CasualLosses { get; set; }

        public float CasualWl { get; set; }

        public uint CasualMatchesPlayed { get; set; }

        public uint Barricades { get; set; }

        public uint Reinforcements { get; set; }

        public uint Downs { get; set; }

        public uint Revives { get; set; }

        public uint Suicides { get; set; }

        public uint Headshots { get; set; }

        public uint Penetrations { get; set; }

        public uint Knifes { get; set; }

        public uint Assists { get; set; }

        public long ShotsFired { get; set; }

        public long ShotsConnected { get; set; }

        public uint TrainingKills { get; set; }

        public uint TrainingDeaths { get; set; }

        public float TrainingKd { get; set; }

        public uint TrainingWins { get; set; }

        public uint TrainingLosses { get; set; }

        public float TrainingWl { get; set; }

        public uint TrainingMatchesPlayed => TrainingLosses + TrainingWins;

        public uint HiScoreBomb { get; set; }

        public uint HiScoreSecure { get; set; }

        public uint HiScoreHostage { get; set; }

        public TimeSpan TimePlayedTraining { get; set; }

        public TimeSpan TimePlayedCasual { get; set; }

        public TimeSpan TimePlayedRanked { get; set; }

        public TimeSpan TimePlayedGeneral { get; set; }

        public TimeSpan TimePlayedCustom { get; set; }

        public uint RankedWins { get; set; }

        public uint RankedLosses { get; set; }

        public float RankedWl { get; set; }

        public uint RankedMatchesPlayed { get; set; }

        public uint RankedKills { get; set; }

        public uint RankedDeaths { get; set; }

        public float RankedKd { get; set; }

        #endregion
    }
}
