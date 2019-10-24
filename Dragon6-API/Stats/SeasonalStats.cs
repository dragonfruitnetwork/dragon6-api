using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class Season
    {
        public int SeasonID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Abandons { get; set; }
        public int Max_Rank { get; set; }
        public int Rank { get; set; }
        public int MMR { get; set; }

        /// <summary>
        ///     Get Stats for the current season
        /// </summary>
        public static async Task<Season> GetSeason(AccountInfo player, string region, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    $"{Endpoints.RankedStats[player.Platform]}?board_id=pvp_ranked&profile_ids={player.GUID}&region_id={region.ToLowerInvariant()}&season_id=-1",
                    token));

            return await Task.Run(() => rawData.AlignSeason(player.GUID)).ConfigureAwait(false);
        }

        /// <summary>
        ///     Get Stats for a specific season
        /// </summary>
        public static async Task<Season> GetSeason(AccountInfo player, string region, string token, int seasonNumber)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    $"{Endpoints.RankedStats[player.Platform]}?board_id=pvp_ranked&profile_ids={player.GUID}&region_id={region.ToLowerInvariant()}&season_id={seasonNumber}",
                    token));

            return await Task.Run(() => rawData.AlignSeason(player.GUID)).ConfigureAwait(false);
        }
    }
}