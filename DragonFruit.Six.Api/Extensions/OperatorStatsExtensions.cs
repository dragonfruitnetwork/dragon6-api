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

namespace DragonFruit.Six.Api.Extensions
{
    public static class OperatorStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static IEnumerable<OperatorStats> GetOperatorStats<T>(this T client, AccountInfo account, IEnumerable<OperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetOperatorStats(client, account.Yield(), operators, training, token).AllFor(account);
        }

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static ILookup<string, OperatorStats> GetOperatorStats<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training, operators);
            return PlatformStatsExtensions.GetPlatformStats(client, accounts, token, j => j.DeserializeOperatorStats(operators), requestFactory);
        }

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an <see cref="AccountInfo"/>
        /// </summary>
        public static Task<IEnumerable<OperatorStats>> GetOperatorStatsAsync<T>(this T client, AccountInfo account, IEnumerable<OperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetOperatorStatsAsync(client, account.Yield(), operators, training, token).ContinueWith(t => t.Result.AllFor(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the <see cref="OperatorStats"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public static Task<ILookup<string, OperatorStats>> GetOperatorStatsAsync<T>(this T client, IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training, operators);
            return PlatformStatsExtensions.GetPlatformStatsAsync(client, accounts, token, j => j.DeserializeOperatorStats(operators), requestFactory);
        }

        private static Func<IEnumerable<AccountInfo>, OperatorStatsRequest> RequestFactory(bool training, IEnumerable<OperatorStats> operators)
        {
            return training ? x => new OperatorTrainingStatsRequest(x, operators) : x => new OperatorStatsRequest(x, operators);
        }
    }
}
