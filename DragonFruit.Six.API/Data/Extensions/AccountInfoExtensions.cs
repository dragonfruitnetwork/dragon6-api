// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class AccountInfoExtensions
    {
        /// <summary>
        /// Get a user's account info (in order to get stats)
        /// </summary>
        public static AccountInfo GetUser(this Dragon6Client client, Platform platform, LookupMethod lookupMethod, string query) =>
            GetUsers(client, platform, lookupMethod, new[] { query }).First();

        /// <summary>
        /// Get multiple users' account info through a mass query search
        /// </summary>
        public static IEnumerable<AccountInfo> GetUsers(this Dragon6Client client, Platform platform, LookupMethod lookupMethod, IEnumerable<string> queries)
        {
            var request = new AccountInfoRequest(platform, lookupMethod, queries);
            return client.Perform<JObject>(request).DeserializeAccountInfo();
        }
    }
}
