using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    public class OperatorStats
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string ImageURL { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public decimal KD { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal WL { get; set; }

        public int Headshots { get; set; }
        public int DBNO { get; set; }
        public int RoundsPlayed { get; set; }

        /// <summary>
        /// Get a collection of all individual operator stats in a List (do not use OperatorIconIndex unless you know what it is)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<OperatorStats>> GetOperatorStats(AccountInfo player, string token, string OperatorIconIndex = null)
        {
            Dictionary<string, string> OperatorIconMap = new Dictionary<string, string>();
            bool UseMap = false;

            try
            {
                if (!string.IsNullOrEmpty(OperatorIconIndex) && File.Exists(OperatorIconIndex))
                {
                    OperatorIconMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(OperatorIconIndex));
                    UseMap = true;
                }
            }
            catch { }

            var GUID = player.GUID;
            var client = new HttpClient();

            string uri;
            switch (player.Platform)
            {
                case References.Platforms.PSN:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics?populations=";
                    break;
                case References.Platforms.XB1:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics?populations=";
                    break;
                default:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics?populations=";
                    break;
            }

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization",
                "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var request = await client
                .GetAsync(uri + GUID +
                          "&statistics=operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon");

            if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var rawStats = await Task.Run(async () => JObject.Parse(await request.Content.ReadAsStringAsync()));
            var OperatorObj = await Task.Run(async () => JObject.Parse(await client
                .GetAsync("https://assets.dragon6.dragonfruit.network/operatorinfo.json")
                .Result.Content.ReadAsStringAsync()));
            var PlayerObj = (JObject)rawStats["results"][GUID];

            //form strings to get data
            var Collection = new List<OperatorStats>();

            foreach (var index in OperatorObj.ToObject<Dictionary<string, string>>().Keys.ToArray())
            {
                var WinsIdentifier = $"operatorpvp_roundwon:{index}:infinite";
                var LossIdentifier = $"operatorpvp_roundlost:{index}:infinite";
                var KillsIdentifier = $"operatorpvp_kills:{index}:infinite";
                var DeathsIdentifier = $"operatorpvp_death:{index}:infinite";
                var HeadshotsIdentifier = $"operatorpvp_headshot:{index}:infinite";
                var DBNOIdentifier = $"operatorpvp_dbno:{index}:infinite";
                var RoundsPlayedIdentifier = $"operatorpvp_roundplayed:{index}:infinite";

                var stats = new OperatorStats
                {
                    Name = (string)OperatorObj[index],
                    Index = index,
                    Kills = int.Parse((string)PlayerObj[KillsIdentifier] ?? "0"),
                    Deaths = int.Parse((string)PlayerObj[DeathsIdentifier] ?? "0"),
                    Wins = int.Parse((string)PlayerObj[WinsIdentifier] ?? "0"),
                    Losses = int.Parse((string)PlayerObj[LossIdentifier] ?? "0"),
                    Headshots = int.Parse((string)PlayerObj[HeadshotsIdentifier] ?? "0"),
                    DBNO = int.Parse((string)PlayerObj[DBNOIdentifier] ?? "0"),
                    RoundsPlayed = int.Parse((string)PlayerObj[RoundsPlayedIdentifier] ?? "0"),
                    KD = decimal.Round(decimal.Parse((string)PlayerObj[KillsIdentifier] ?? "1") /
                                       decimal.Parse((string)PlayerObj[DeathsIdentifier] ?? "1"), 2),
                    WL = decimal.Round(decimal.Parse((string)PlayerObj[WinsIdentifier] ?? "1") /
                                       decimal.Parse((string)PlayerObj[LossIdentifier] ?? "1"), 2)
                };

                try
                {
                    if (UseMap)
                    {
                        stats.ImageURL = OperatorIconMap[index];
                    }
                }
                catch { }

                PlayerObj.Remove(WinsIdentifier);
                PlayerObj.Remove(LossIdentifier);
                PlayerObj.Remove(KillsIdentifier);
                PlayerObj.Remove(DeathsIdentifier);
                PlayerObj.Remove(HeadshotsIdentifier);
                PlayerObj.Remove(DBNOIdentifier);
                PlayerObj.Remove(RoundsPlayedIdentifier);
                Collection.Add(stats);
            }

            return Collection;
        }

    }
}
