// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Data.Deserializers;
using DragonFruit.Six.Api.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Data.Extensions
{
    public static class AccountActivityExtensions
    {
        /// <summary>
        /// Get the <see cref="AccountActivity"/> for a specific <see cref="AccountInfo"/>
        /// </summary>
        public static AccountActivity GetLoginInfo<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
            => GetLoginInfo(client, new[] { account }, token).First();

        /// <summary>
        /// Get the <see cref="AccountActivity"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static IEnumerable<AccountActivity> GetLoginInfo<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            var data = client.Perform<JObject>(new AccountActivityRequest(accounts), token);
            return data.DeserializeAccountLoginInfo();
        }
    }
}
