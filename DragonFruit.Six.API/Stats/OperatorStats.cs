// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.File;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;

namespace DragonFruit.Six.API.Stats
{
    public class Operator
    {
        public string Guid { get; set; }

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

        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo account, string token, Dictionary<string, string> operatorNameIndex, string operatorIconIndex) => (await GetOperatorStats(new[] { account }, token, operatorNameIndex, operatorIconIndex)).First();

        public static async Task<IEnumerable<IEnumerable<Operator>>> GetOperatorStats(IEnumerable<AccountInfo> accounts, string token, Dictionary<string, string> operatorNameIndex, string operatorIconIndex)
        {
            var results = new List<IEnumerable<Operator>>();

            await foreach(var result in GetOperatorStatsAsync(accounts, token, operatorNameIndex, operatorIconIndex))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<IEnumerable<Operator>> GetOperatorStatsAsync(IEnumerable<AccountInfo> accounts, string token, Dictionary<string, string> operatorNameIndex, string operatorIconIndex)
        {
            #region Resource Setup

            var operatorIndex = operatorNameIndex ?? d6WebRequest.GetWebObject<Dictionary<string, string>>(Endpoints.OperatorMapping);
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

            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var ids = group.Select(x => x.Guid);
                var rawData = await Task.Run(() =>
                    d6WebRequest.GetWebObject(
                        d6WebRequest.FormStatsUrl(group.Key, ids, "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"), token));

                foreach (var x in ids)
                    yield return rawData.ToOperatorStats(x, operatorIndex, operatorIconMap);
            }
        }
    }
}
