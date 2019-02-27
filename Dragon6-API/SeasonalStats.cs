using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    public class SeasonalStats
    {
        public int Season { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Abandons { get; set; }
        public int Max_Rank { get; set; }
        public int Rank { get; set; }
        public int MMR { get; set; }

        /// <summary>
        /// Get Stats for a specific season (-1 is current)
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="SeasonNumber"></param>
        /// <param name="Region"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<SeasonalStats> GetSeason(AccountInfo Player, int SeasonNumber, string Region,string token)
        {
            var client = new HttpClient();
            var uuid = Player.GUID;

            var uri = "";
            switch (Player.Platform)
            {
                case References.Platforms.PC:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players?board_id=pvp_ranked";
                    break;
                case References.Platforms.PSN:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players?board_id=pvp_ranked";
                    break;
                case References.Platforms.XB1:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players?board_id=pvp_ranked";
                    break;
                default:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players?board_id=pvp_ranked";
                    break;
            }

            var constructor = $"&profile_ids={uuid}&region_id={Region.ToLower()}&season_id={SeasonNumber}";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var content = await client.GetAsync(uri + constructor);

            if (content.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var response = await Task.Run(async () =>
                JObject.Parse(await content.Content.ReadAsStringAsync()));

            return new SeasonalStats
            {
                Season = SeasonNumber,
                Rank = (int) response["players"][uuid]["rank"],
                Max_Rank = (int) response["players"][uuid]["max_rank"],
                Wins = (int) response["players"][uuid]["wins"],
                Losses = (int) response["players"][uuid]["losses"],
                Abandons = (int) response["players"][uuid]["abandons"],
                MMR = (int) response["players"][uuid]["mmr"]
            };
        }

    }
}
