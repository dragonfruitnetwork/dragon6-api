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
    public static class PlayerLevelStatsExtensions
    {
        /// <summary>
        /// Get the level, level progression and alpha pack chances for an <see cref="AccountInfo"/>
        /// </summary>
        public static PlayerLevelStats GetLevel<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
            => GetLevel(client, new[] { account }, token).First();

        /// <summary>
        /// Get the level, level progression and alpha pack chances for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static IEnumerable<PlayerLevelStats> GetLevel<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new PlayerLevelStatsRequest(group);
                var data = client.Perform<JObject>(request, token);

                foreach (var result in data.DeserializePlayerLevelStats())
                {
                    yield return result;
                }
            }
        }
    }
}
