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

namespace Dragon6.API.Stats
{
    public class Operator
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
        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo player, string token, string OperatorIconIndex = null)
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

            var client = Http.Preset.GetClient(token);

            var request = await client
                .GetAsync(Http.Preset.FormStatsURL(player,"operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"));

            if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var OperatorObj = await Task.Run(async () => JObject.Parse(await client.GetAsync("https://dragon6-224813.firebaseapp.com/operatorinfo.json").Result.Content.ReadAsStringAsync()));
            var PlayerObj = (JObject)JObject.Parse(await request.Content.ReadAsStringAsync())["results"][player.GUID];

            //form strings to get data
            var Collection = new List<Operator>();

            foreach (var index in OperatorObj.ToObject<Dictionary<string, string>>().Keys.ToArray())
            {
                var WinsIdentifier = $"operatorpvp_roundwon:{index}:infinite";
                var LossIdentifier = $"operatorpvp_roundlost:{index}:infinite";
                var KillsIdentifier = $"operatorpvp_kills:{index}:infinite";
                var DeathsIdentifier = $"operatorpvp_death:{index}:infinite";
                var HeadshotsIdentifier = $"operatorpvp_headshot:{index}:infinite";
                var DBNOIdentifier = $"operatorpvp_dbno:{index}:infinite";
                var RoundsPlayedIdentifier = $"operatorpvp_roundplayed:{index}:infinite";

                var stats = new Operator
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

                Collection.Add(stats);
            }

            return Collection;
        }

    }
}
