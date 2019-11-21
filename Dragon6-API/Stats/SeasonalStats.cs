// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class Season
    {
        public byte SeasonId { get; set; }
        public uint Wins { get; set; }
        public uint Losses { get; set; }
        public uint Abandons { get; set; }
        public uint Max_Rank { get; set; }
        public uint Rank { get; set; }
        public uint MMR { get; set; }

        /// <summary>
        ///     Get Stats for the current season
        /// </summary>
        public static async Task<Season> GetSeason(AccountInfo player, string region, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    $"{Endpoints.RankedStats[player.Platform]}?board_id=pvp_ranked&profile_ids={player.Guid}&region_id={region.ToLowerInvariant()}&season_id=-1",
                    token));

            return await Task.Run(() => rawData.AlignSeason(player.Guid)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get Stats for a specific season
        /// </summary>
        public static async Task<Season> GetSeason(AccountInfo player, string region, string token, int seasonNumber)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    $"{Endpoints.RankedStats[player.Platform]}?board_id=pvp_ranked&profile_ids={player.Guid}&region_id={region.ToLowerInvariant()}&season_id={seasonNumber}",
                    token));

            return await Task.Run(() => rawData.AlignSeason(player.Guid)).ConfigureAwait(false);
        }
    }
}