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
    public static class GeneralStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="GeneralStats"/> (non-seasonal) for an <see cref="AccountInfo"/>
        /// </summary>
        public static GeneralStats GetStats<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetStats(client, account.Yield(), token).For(account);
        }

        /// <summary>
        /// Get the <see cref="GeneralStats"/> (non-seasonal) for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static ILookup<string, GeneralStats> GetStats<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return accounts.GroupBy(x => x.Platform)
                           .Select(x => client.Perform<JObject>(new StatsRequest(x)))
                           .Aggregate(Merge)
                           .DeserializeGeneralStats();
        }

        /// <summary>
        /// Get the <see cref="GeneralStats"/> (non-seasonal) for an <see cref="AccountInfo"/>
        /// </summary>
        public static Task<GeneralStats> GetStatsAsync<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetStatsAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the <see cref="GeneralStats"/> (non-seasonal) for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static Task<ILookup<string, GeneralStats>> GetStatsAsync<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            var requests = accounts.GroupBy(x => x.Platform).Select(x => client.PerformAsync<JObject>(new StatsRequest(x), token));
            return Task.WhenAll(requests).ContinueWith(t => t.Result.Aggregate(Merge).DeserializeGeneralStats(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        internal static JObject Merge(JObject a, JObject b)
        {
            a.Merge(b);
            return a;
        }
    }
}
