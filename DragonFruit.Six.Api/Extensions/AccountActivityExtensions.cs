// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Extensions
{
    public static class AccountActivityExtensions
    {
        /// <summary>
        /// Get the <see cref="AccountActivity"/> for a specific <see cref="AccountInfo"/>
        /// </summary>
        public static AccountActivity GetAccountActivity<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetAccountActivity(client, account.Yield(), token).For(account);
        }

        /// <summary>
        /// Get the <see cref="AccountActivity"/> for a collection of <see cref="AccountInfo"/>s
        /// </summary>
        public static ILookup<string, AccountActivity> GetAccountActivity<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            var data = client.Perform<JObject>(new AccountActivityRequest(accounts), token);
            return data.DeserializeAccountLoginInfo();
        }

        /// <summary>
        /// Get the <see cref="AccountActivity"/> for a specific <see cref="AccountInfo"/> (as an asynchronous operation)
        /// </summary>
        public static Task<AccountActivity> GetAccountActivityAsync<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetAccountActivityAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the <see cref="AccountActivity"/> for a collection of <see cref="AccountInfo"/>s (as an asynchronous operation)
        /// </summary>
        public static Task<ILookup<string, AccountActivity>> GetAccountActivityAsync<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return client.PerformAsync<JObject>(new AccountActivityRequest(accounts), token).ContinueWith(t => t.Result.DeserializeAccountLoginInfo(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
