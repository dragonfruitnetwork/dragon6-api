// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.File;
using DragonFruit.Common.Storage.Shared;
using DragonFruit.Common.Storage.Web;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Stats
{
    public class Operator
    {
        /// <summary>
        /// User Profile ID
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Operator name (from datasheet/dictionary)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Operator Identifier (from datasheet/dictionary)
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Operator Icon (from datasheet)
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game (from datasheet)
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender (from datasheet)
        /// </summary>
        public OperatorType Type { get; set; }

        /// <summary>
        /// The string sent to ubi for their gadget action (from datasheet)
        /// </summary>
        public string OperatorActionId { get; set; }

        /// <summary>
        /// String used to collect the stats from ubi
        /// </summary>
        internal string OperatorActionResultId => $"{OperatorActionId}:infinite";

        public string Action { get; set; }

        public uint ActionCount { get; set; }

        public uint Kills { get; set; }

        public uint Deaths { get; set; }

        public float KD { get; set; }

        public uint Wins { get; set; }

        public uint Losses { get; set; }

        public float WL { get; set; }

        public uint Headshots { get; set; }

        public uint Downs { get; set; }

        public TimeSpan Duration { get; set; }

        public uint RoundsPlayed { get; set; }

        /// <summary>
        /// Nicer way to format a timespan.
        /// </summary>
        public string DurationString => $"{Math.Floor(Duration.TotalHours)}H {Duration.Minutes}M";

        /// <summary>
        /// Number of hours played
        /// </summary>
        public double HoursPlayed => Math.Floor(Duration.TotalHours);

        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo account, IEnumerable<Operator> data, string token) =>
            (await GetOperatorStats(new[] { account }, data, token).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<Operator>> GetOperatorStats(AccountInfo account, Dictionary<string, string> operatorNameIndex, string token) =>
            (await GetOperatorStats(new[] { account }, operatorNameIndex, token).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<IEnumerable<Operator>>> GetOperatorStats(IEnumerable<AccountInfo> accounts, Dictionary<string, string> operatorNameIndex, string token)
        {
            var data = operatorNameIndex.Select(x => new Operator
            {
                Name = x.Value,
                Index = x.Key
            });

            return await GetOperatorStats(accounts, data, token).ConfigureAwait(false);
        }

        public static async Task<IEnumerable<IEnumerable<Operator>>> GetOperatorStats(IEnumerable<AccountInfo> accounts, IEnumerable<Operator> data, string token)
        {
            var results = new List<IEnumerable<Operator>>();

            await foreach (var result in GetOperatorStatsAsync(accounts, data, token))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<IEnumerable<Operator>> GetOperatorStatsAsync(IEnumerable<AccountInfo> accounts, IEnumerable<Operator> data, string token)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            var baseKeys =
                "operatorpvp_kills,operatorpvp_headshot,operatorpvp_dbno,operatorpvp_death,operatorpvp_roundlost,operatorpvp_roundplayed,operatorpvp_roundwlratio,operatorpvp_roundwon,operatorpvp_timeplayed"
                    .Split(',');
            var operatorKeys = data.Where(x => !string.IsNullOrEmpty(x.OperatorActionId)).Select(x => x.OperatorActionId);

            foreach (var group in filteredGroups)
            {
                var ids = group.Select(x => x.Guid);
                var uri = d6WebRequest.FormStatsUrl(group.Key, ids, string.Join(',', operatorKeys.Concat(baseKeys)));

                var rawData = await Task.Run(() => d6WebRequest.GetWebObject(uri, token));

                foreach (var x in ids)
                    yield return rawData.ToOperatorStats(x, data);
            }
        }

        public static IEnumerable<Operator> GetOperators(string file)
        {
            var data = Uri.TryCreate(file, UriKind.Absolute, out _) ? WebServices.StreamObject<JArray>(file) : FileServices.ReadFile<JArray>(file);

            foreach (var jToken in data)
            {
                var element = (JObject)jToken;
                yield return new Operator
                {
                    ImageURL = element.GetString("img"),
                    Name = element.GetString("name"),
                    Organisation = element.GetString("org"),
                    Index = element.GetString("index"),
                    Subtitle = element.GetString("sub"),
                    Type = (OperatorType)element.GetInt("type"),
                    OperatorActionId = element.GetString("actn"),
                    Action = element.GetString("phrase"),
                };
            }
        }
    }
}
