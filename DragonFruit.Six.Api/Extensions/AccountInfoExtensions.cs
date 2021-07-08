// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Extensions
{
    public static class AccountInfoExtensions
    {
        /// <summary>
        /// Get a user's account info by name
        /// </summary>
        public static AccountInfo GetUserByName<T>(this T client, string name, Platform platform) where T : Dragon6Client
            => client.GetUser(platform, LookupMethod.Name, name);

        /// <summary>
        /// Get a user's account info by userId
        /// </summary>
        public static AccountInfo GetUserByUbisoftId<T>(this T client, string userId, Platform platform) where T : Dragon6Client
            => client.GetUser(platform, LookupMethod.UserId, userId);

        /// <summary>
        /// Get a user's account info (in order to get stats)
        /// </summary>
        public static AccountInfo GetUser<T>(this T client, Platform platform, LookupMethod lookupMethod, string query, CancellationToken token = default) where T : Dragon6Client
            => GetUsers(client, platform, lookupMethod, query.Yield(), token).FirstOrDefault();

        /// <summary>
        /// Get multiple users' account info through a mass query search
        /// </summary>
        public static IEnumerable<AccountInfo> GetUsers<T>(this T client, Platform platform, LookupMethod lookupMethod, IEnumerable<string> queries, CancellationToken token = default)
            where T : Dragon6Client
        {
            var request = new AccountInfoRequest(platform, lookupMethod, queries);
            return client.Perform<JObject>(request, token).DeserializeAccountInfo();
        }
    }
}
