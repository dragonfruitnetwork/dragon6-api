using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Dragon6.API.Helpers;
using Newtonsoft.Json;

namespace Dragon6.API.Stats
{
    public class Operator
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string ImageURL { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public float KD { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public float WL { get; set; }

        public int Headshots { get; set; }
        public int Downs { get; set; }
        public int RoundsPlayed { get; set; }

        /// <summary>
        ///     Get a collection of all individual operator stats in a List (do not use OperatorIconIndex unless you know what it
        ///     is)
        /// </summary>
        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo player, string token,
            Dictionary<string, string> OperatorNameIndex = null, string OperatorIconIndex = null)
        {
            #region OperatorIconIndex Setup

            Dictionary<string, string> OperatorIconMap = new Dictionary<string, string>();
            bool UseMap = false;

            try
            {
                if (!string.IsNullOrEmpty(OperatorIconIndex) && File.Exists(OperatorIconIndex))
                {
                    OperatorIconMap =
                        JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(OperatorIconIndex));
                    UseMap = true;
                }
            }
            catch
            {
            }

            #endregion

            var request = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    d6WebRequest.FormStatsUrl(player,
                        "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"),
                    token));

            var operatorObj = OperatorNameIndex ??
                              d6WebRequest.GetWebObject<Dictionary<string, string>>(
                                  "https://dragon6-224813.firebaseapp.com/operatorinfo.json");
            var JSON = new JSONConverter(request["results"][player.GUID]);

            //form strings to get data
            var collection = new List<Operator>();

            foreach (var index in operatorObj.Keys.ToArray())
            {
                var stats = new Operator
                {
                    Name = operatorObj[index],
                    Index = index,
                    Kills = JSON.GetInt32(string.Format(Consts.Operator.Kills, index)),
                    Deaths = JSON.GetInt32(string.Format(Consts.Operator.Deaths, index)),
                    Wins = JSON.GetInt32(string.Format(Consts.Operator.Wins, index)),
                    Losses = JSON.GetInt32(string.Format(Consts.Operator.Losses, index)),
                    Headshots = JSON.GetInt32(string.Format(Consts.Operator.Headshots, index)),
                    Downs = JSON.GetInt32(string.Format(Consts.Operator.Downs, index)),
                    RoundsPlayed = JSON.GetInt32(string.Format(Consts.Operator.Rounds, index)),
                    KD = JSON.GetFloat(string.Format(Consts.Operator.Kills, index), 1) /
                         JSON.GetFloat(string.Format(Consts.Operator.Deaths, index), 1),
                    WL = JSON.GetFloat(string.Format(Consts.Operator.Wins, index), 1) /
                         JSON.GetFloat(string.Format(Consts.Operator.Losses, index), 1)
                };

                try
                {
                    if (UseMap)
                    {
                        stats.ImageURL = OperatorIconMap[index];
                    }
                }
                catch
                {
                }

                collection.Add(stats);
            }

            return collection;
        }
    }
}