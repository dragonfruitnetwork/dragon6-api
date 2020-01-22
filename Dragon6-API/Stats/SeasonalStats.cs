// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Stats
{
    public class Season
    {
        public string Guid { get; set; }

        [JsonProperty("season")]
        public byte SeasonId { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("abandons")]
        public uint Abandons { get; set; }

        [JsonProperty("max_rank")]
        public uint MaxRank { get; set; }

        [JsonProperty("rank")]
        public uint Rank { get; set; }

        [JsonProperty("mmr")]
        public double MMR { get; set; }

        [JsonProperty("max_mmr")]
        public double MaxMMR { get; set; }

        public static async Task<Season> GetSeason(AccountInfo account, string region, string token) => (await GetSeason(new[] { account }, region, token, -1)).First();

        public static async Task<IEnumerable<Season>> GetSeason(IEnumerable<AccountInfo> accounts, string region, string token) => await GetSeason(accounts, region, token, -1);

        public static async Task<Season> GetSeason(AccountInfo account, string region, string token, int seasonNumber) => (await GetSeason(new[] { account }, region, token, seasonNumber)).First();

        public static async Task<IEnumerable<Season>> GetSeason(IEnumerable<AccountInfo> accounts, string region, string token, int seasonNumber)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);
            var results = new List<Season>();

            foreach (var group in filteredGroups)
            {
                var ids = group.Select(a => a.Guid);
                var rawData = await Task.Run(() => d6WebRequest.GetWebObject($"{Endpoints.RankedStats[group.Key]}?board_id=pvp_ranked&profile_ids={string.Join(',', ids)}&region_id={region.ToLowerInvariant()}&season_id={seasonNumber}", token));

                results.AddRange(ids.Select(id => rawData.ToSeason(id)));
            }

            return results;
        }
    }
}
