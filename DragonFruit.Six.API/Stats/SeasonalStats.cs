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
    [JsonProperty("guid")]
    public string Guid {
        get;
        set;
    }

    [JsonProperty("id")]
    public byte SeasonId {
        get;
        set;
    }

    [JsonProperty("wins")]
    public uint Wins {
        get;
        set;
    }

    [JsonProperty("losses")]
    public uint Losses {
        get;
        set;
    }

    [JsonProperty("abandons")]
    public uint Abandons {
        get;
        set;
    }

    [JsonProperty("maxrank")]
    public uint MaxRank {
        get;
        set;
    }

    [JsonProperty("rank")]
    public uint Rank {
        get;
        set;
    }

    [JsonProperty("mmr")]
    public double MMR {
        get;
        set;
    }

    [JsonProperty("maxmmr")]
    public double MaxMMR {
        get;
        set;
    }

    public static async Task<Season> GetSeason(AccountInfo account, string region, string token) => (await GetSeason(new[] { account }, region, token, -1).ConfigureAwait(false)).First();

    public static async Task<IEnumerable<Season>> GetSeason(IEnumerable<AccountInfo> accounts, string region, string token) => await GetSeason(accounts, region, token, -1).ConfigureAwait(false);

    public static async Task<Season> GetSeason(AccountInfo account, string region, string token, int seasonNumber) =>
    (await GetSeason(new[] { account }, region, token, seasonNumber).ConfigureAwait(false)).First();

    public static async Task<IEnumerable<Season>> GetSeason(IEnumerable<AccountInfo> accounts, string region, string token, int seasonNumber)
    {
        var results = new List<Season>();

        await foreach (var result in GetSeasonAsync(accounts, region, token, seasonNumber))
            results.Add(result);

        return results;
    }

    public static async IAsyncEnumerable<Season> GetSeasonAsync(IEnumerable<AccountInfo> accounts, string region, string token, int seasonNumber)
    {
        var filteredGroups = accounts.GroupBy(x => x.Platform);

        foreach (var group in filteredGroups)
        {
            var ids = group.Select(a => a.Guid);
            var rawData = await Task.Run(() =>
                                         d6WebRequest.GetWebObject(
                                             $"{Endpoints.RankedStats[group.Key]}?board_id=pvp_ranked&profile_ids={string.Join(',', ids)}&region_id={region.ToLowerInvariant()}&season_id={seasonNumber}", token));

            foreach (var id in ids)
                yield return rawData.ToSeason(id);
        }
    }
}
}
