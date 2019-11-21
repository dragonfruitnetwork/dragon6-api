// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Threading.Tasks;
using Dragon6.API.Helpers;
using DragonFruit.Common.Storage.File;

namespace Dragon6.API.Stats
{
    public class Operator
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public string ImageURL { get; set; }

        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public float KD { get; set; }

        public uint Wins { get; set; }
        public uint Losses { get; set; }
        public float WL { get; set; }

        public uint Headshots { get; set; }
        public uint Downs { get; set; }
        public uint RoundsPlayed { get; set; }

        /// <summary>
        ///     Get a collection of all individual operator stats in a List with the icon property filled
        /// </summary>
        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo player, string token,
            Dictionary<string, string> operatorNameIndex, string operatorIconIndex)
        {
            #region operatorIconIndex Setup

            var operatorIconMap = new Dictionary<string, string>();
            try
            {
                operatorIconMap = FileServices.ReadFile<Dictionary<string, string>>(operatorIconIndex);
            }
            catch
            {
                //cannot find the operator icon index - it's not the end of the world, just continue
            }

            #endregion

            var operatorIndex = operatorNameIndex ??
                                d6WebRequest.GetWebObject<Dictionary<string, string>>(Endpoints.OperatorIndex);

            var request = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    d6WebRequest.FormStatsUrl(player,
                        "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"),
                    token));


            return await Task.Run(() => request.AlignOperators(player.Guid, operatorIndex, operatorIconMap))
                .ConfigureAwait(false);
        }
    }
}