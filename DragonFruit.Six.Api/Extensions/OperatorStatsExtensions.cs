// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Legacy.Entities;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Extensions
{
    public static class OperatorStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="LegacyOperatorStats"/> for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static IEnumerable<LegacyOperatorStats> GetOperatorStats<T>(this T client, UbisoftAccount account, IEnumerable<LegacyOperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetOperatorStats(client, account.Yield(), operators, training, token).AllFor(account);
        }

        /// <summary>
        /// Get the <see cref="LegacyOperatorStats"/> for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static ILookup<string, LegacyOperatorStats> GetOperatorStats<T>(this T client, IEnumerable<UbisoftAccount> accounts, IEnumerable<LegacyOperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training, operators);
            return PlatformStatsExtensions.GetPlatformStats(client, accounts, token, j => j.DeserializeOperatorStats(operators), requestFactory);
        }

        /// <summary>
        /// Get the <see cref="LegacyOperatorStats"/> for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static Task<IEnumerable<LegacyOperatorStats>> GetOperatorStatsAsync<T>(this T client, UbisoftAccount account, IEnumerable<LegacyOperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            return GetOperatorStatsAsync(client, account.Yield(), operators, training, token).ContinueWith(t => t.Result.AllFor(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the <see cref="LegacyOperatorStats"/> for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static Task<ILookup<string, LegacyOperatorStats>> GetOperatorStatsAsync<T>(this T client, IEnumerable<UbisoftAccount> accounts, IEnumerable<LegacyOperatorStats> operators, bool training = false, CancellationToken token = default) where T : Dragon6Client
        {
            var requestFactory = RequestFactory(training, operators);
            return PlatformStatsExtensions.GetPlatformStatsAsync(client, accounts, token, j => j.DeserializeOperatorStats(operators), requestFactory);
        }

        private static Func<IEnumerable<UbisoftAccount>, OperatorStatsRequest> RequestFactory(bool training, IEnumerable<LegacyOperatorStats> operators)
        {
            return training ? x => new OperatorTrainingStatsRequest(x, operators) : x => new OperatorStatsRequest(x, operators);
        }
    }
}
