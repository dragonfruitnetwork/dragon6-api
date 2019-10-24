using System.Collections.Generic;
using System.IO;
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
        ///     Get a collection of all individual operator stats in a List with the icon property filled
        /// </summary>
        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo player, string token,
            Dictionary<string, string> operatorNameIndex, string operatorIconIndex)
        {
            #region operatorIconIndex Setup

            Dictionary<string, string> operatorIconMap = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(operatorIconIndex) && File.Exists(operatorIconIndex))
            {
                try
                {
                    operatorIconMap =
                        JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(operatorIconIndex));
                }
                catch
                {
                    //cannot find the operator icon index - it's not the end of the world, just continue
                }
            }

            #endregion

            var operatorIndex = operatorNameIndex ??
                                d6WebRequest.GetWebObject<Dictionary<string, string>>(Endpoints.OperatorIndex);

            var request = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    d6WebRequest.FormStatsUrl(player,
                        "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"),
                    token));


            return await Task.Run(() => request.AlignOperators(player.GUID, operatorIndex, operatorIconMap))
                .ConfigureAwait(false);
        }
    }
}