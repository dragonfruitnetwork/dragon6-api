// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using DragonFruit.Six.API.Verification;
using Newtonsoft.Json;

namespace DragonFruit.Six.API
{
    public class AccountInfo
    {
        /// <summary>
        ///     The Player's Username (Formatted)
        /// </summary>
        [JsonProperty("name")]
        public string PlayerName { get; set; }

        /// <summary>
        ///     URL to Player's Avatar
        /// </summary>
        [JsonProperty("image")]
        public string Image => $"https://ubisoft-avatars.akamaized.net/{Guid}/default_256_256.png";

        /// <summary>
        ///     User Platform
        /// </summary>
        [JsonProperty("platform")]
        public References.Platforms Platform { get; set; }

        /// <summary>
        ///     User's GUID - used to get stats
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonIgnore]
        public Verification.Verification AccountStatus => Server.GetUser(Guid);

        /// <summary>
        /// Request user info in mass form by passing an array of queries
        /// </summary>
        public static async Task<IEnumerable<AccountInfo>> GetUser(References.Platforms platform, References.LookupMethod lookupMethod, IEnumerable<string> queries, string token)
        {
            //create the request uri
            var uri = $"{Endpoints.IdServer}?platformType={PlatformParser.PlatformIdentifierFor(platform)}&{LookupKeyFor(lookupMethod)}={string.Join(',', queries)}";

            return await Task.Run(() => d6WebRequest.GetWebObject(uri, token).ToAccounts());
        }

        /// <summary>
        /// Get a user's account info
        /// </summary>
        public static async Task<AccountInfo> GetUser(References.Platforms platform, References.LookupMethod lookupMethod, string query, string token) =>
            (await GetUser(platform, lookupMethod, new[] { query }, token)).First();

        /// <summary>
        /// Methods for looking up a user. Used in by <see cref="AccountInfo"/>
        /// </summary>
        private static string LookupKeyFor(References.LookupMethod method) => method switch
        {
            References.LookupMethod.Name => "nameOnPlatform",
            References.LookupMethod.Profile => "profileId",
            References.LookupMethod.PlatformId => "idOnPlatform",
            References.LookupMethod.User => "userId",
            _ => throw new ArgumentException("Method not found")
        };
    }
}
