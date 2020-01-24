// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.File;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Stats
{
    public class Operator
    {
        [JsonProperty("profile")]
        public string Guid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("icon")]
        public string ImageURL { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("kdr")]
        public float KD { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("wlr")]
        public float WL { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("downs")]
        public uint Downs { get; set; }

        [JsonProperty("rounds")]
        public uint RoundsPlayed { get; set; }

        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo account, string token, Dictionary<string, string> operatorNameIndex) =>
            (await GetOperatorStats(new[] { account }, token, operatorNameIndex, null).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo account, string token, Dictionary<string, string> operatorNameIndex, string operatorIconIndex) =>
            (await GetOperatorStats(new[] { account }, token, operatorNameIndex, operatorIconIndex).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<IEnumerable<Operator>>> GetOperatorStats(IEnumerable<AccountInfo> accounts, string token, Dictionary<string, string> operatorNameIndex) =>
            await GetOperatorStats(accounts, token, operatorNameIndex, null).ConfigureAwait(false);

        public static async Task<IEnumerable<IEnumerable<Operator>>> GetOperatorStats(IEnumerable<AccountInfo> accounts, string token, Dictionary<string, string> operatorNameIndex,
                                                                                      string operatorIconIndex)
        {
            var results = new List<IEnumerable<Operator>>();

            await foreach (var result in GetOperatorStatsAsync(accounts, token, operatorNameIndex, operatorIconIndex))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<IEnumerable<Operator>> GetOperatorStatsAsync(IEnumerable<AccountInfo> accounts, string token, Dictionary<string, string> operatorNameIndex,
                                                                                          string operatorIconIndex)
        {
            #region Resource Setup

            var operatorIndex = operatorNameIndex ?? d6WebRequest.GetWebObject<Dictionary<string, string>>(Endpoints.OperatorMapping);
            Dictionary<string, string> operatorIconMap = null;

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
                        d6WebRequest.FormStatsUrl(group.Key, ids,
                            "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon"),
                        token));

                foreach (var x in ids)
                    yield return rawData.ToOperatorStats(x, operatorIndex, operatorIconMap);
            }
        }
    }
}
