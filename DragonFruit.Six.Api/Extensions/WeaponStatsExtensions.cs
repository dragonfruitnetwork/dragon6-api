// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
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
    public static class WeaponStatsExtensions
    {
        /// <summary>
        /// Get <see cref="WeaponStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<WeaponStats> GetWeaponStats<T>(this T client, AccountInfo account, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetWeaponStats(client, account.Yield(), training, token).AllFor(account);
        }

        /// <summary>
        /// Get <see cref="WeaponStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static ILookup<string, WeaponStats> GetWeaponStats<T>(this T client, IEnumerable<AccountInfo> accounts, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training);
            return accounts.GroupBy(x => x.Platform)
                           .Select(x => client.Perform<JObject>(requestFactory(x), token))
                           .Aggregate(GeneralStatsExtensions.Merge)
                           .DeserializeWeaponStats();
        }

        /// <summary>
        /// Get <see cref="WeaponStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static Task<IEnumerable<WeaponStats>> GetWeaponStatsAsync<T>(this T client, AccountInfo account, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetWeaponStatsAsync(client, account.Yield(), training, token).ContinueWith(t => t.Result.AllFor(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get <see cref="WeaponStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static Task<ILookup<string, WeaponStats>> GetWeaponStatsAsync<T>(this T client, IEnumerable<AccountInfo> accounts, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training);
            var requests = accounts.GroupBy(x => x.Platform).Select(x => client.PerformAsync<JObject>(requestFactory(x), token));
            return Task.WhenAll(requests).ContinueWith(t => t.Result.Aggregate(GeneralStatsExtensions.Merge).DeserializeWeaponStats(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private static Func<IEnumerable<AccountInfo>, BasicStatsRequest> RequestFactory(bool training)
        {
            return training ? x => new WeaponTrainingStatsRequest(x) : x => new WeaponStatsRequest(x);
        }
    }
}
