// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Extensions
{
    public static class OperatorStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<OperatorStats> GetOperatorStats<T>(this T client, AccountInfo account, IEnumerable<OperatorStats> operators, CancellationToken token = default)
            where T : Dragon6Client
        {
            return GetOperatorStats(client, new[] { account }, operators, token)[account.Identifiers.Platform];
        }

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static ILookup<string, OperatorStats> GetOperatorStats<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators, CancellationToken token = default)
            where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);
            JObject data = null;

            foreach (var group in filteredGroups)
            {
                var request = new OperatorStatsRequest(group, operators);
                var platformResponse = client.Perform<JObject>(request, token);

                if (data == null)
                {
                    data = platformResponse;
                }
                else
                {
                    data.Merge(platformResponse);
                }
            }

            return data.DeserializeOperatorStats(operators);
        }

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<OperatorStats> GetOperatorTrainingStats<T>(this T client, AccountInfo account, IEnumerable<OperatorStats> operators, CancellationToken token = default)
            where T : Dragon6Client
            => GetOperatorTrainingStats(client, new[] { account }, operators, token).First();

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static IEnumerable<IEnumerable<OperatorStats>> GetOperatorTrainingStats<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators,
                                                                                  CancellationToken token = default) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new OperatorTrainingStatsRequest(group, operators);
                var data = client.Perform<JObject>(request, token);

                foreach (var id in request.AccountIds)
                {
                    yield return data.DeserializeOperatorTrainingStatsFor(id, operators);
                }
            }
        }
    }
}
