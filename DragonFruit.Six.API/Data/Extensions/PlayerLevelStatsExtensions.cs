// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class PlayerLevelStatsExtensions
    {
        public static PlayerLevelStats GetLevel(this Dragon6Client client, AccountInfo account) =>
            GetLevel(client, new[] { account }).First();

        public static IEnumerable<PlayerLevelStats> GetLevel(this Dragon6Client client, IEnumerable<AccountInfo> accounts)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new PlayerLevelStatsRequest(group);
                var data = client.Perform<JObject>(request);

                foreach (var result in data.DeserializePlayerLevelStats())
                {
                    yield return result;
                }
            }
        }
    }
}
