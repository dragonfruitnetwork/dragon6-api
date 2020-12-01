// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class ClassicOperatorStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="ClassicOperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<ClassicOperatorStats> GetClassicOperatorStats<T>(this T client, AccountInfo account, IEnumerable<ClassicOperatorStats> operators, CancellationToken token = default) where T : Dragon6Client
            => GetClassicOperatorStats(client, new[] { account }, operators, token).First();

        /// <summary>
        /// Get the <see cref="ClassicOperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static IEnumerable<IEnumerable<ClassicOperatorStats>> GetClassicOperatorStats<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<ClassicOperatorStats> operators, CancellationToken token = default) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new ClassicOperatorStatsRequest(group, operators);
                var data = client.Perform<JObject>(request, token);

                foreach (var id in request.AccountIds)
                {
                    yield return data.DeserializeClassicOperatorStatsFor(id, operators);
                }
            }
        }
    }
}
