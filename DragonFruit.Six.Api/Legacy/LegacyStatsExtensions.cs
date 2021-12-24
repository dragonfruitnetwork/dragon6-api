// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy.Entities;
using DragonFruit.Six.Api.Legacy.Requests;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Legacy
{
    public static class LegacyStatsExtensions
    {
        /// <summary>
        /// Gets the <see cref="LegacyStats"/> for the <see cref="UbisoftAccount"/> provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns>The <see cref="LegacyStats"/> for the <see cref="UbisoftAccount"/> provided, or <c>null</c> if the account was not returned by the server</returns>
        public static Task<LegacyStats> GetLegacyStatsAsync(this Dragon6Client client, UbisoftAccount account, CancellationToken token = default)
        {
            return GetLegacyStatsAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the <see cref="LegacyStats"/> for the <see cref="UbisoftAccount"/>s provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey,TValue}"/> mapping the user profile id to the corresponding <see cref="LegacyStats"/></returns>
        public static Task<IReadOnlyDictionary<string, LegacyStats>> GetLegacyStatsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default)
        {
            const LegacyStatTypes generalStats = LegacyStatTypes.All & ~(LegacyStatTypes.Operators | LegacyStatTypes.Weapons);
            return GetLegacyStatsAsync(client, accounts, a => new LegacyStatsRequest(a, generalStats), LegacyStatsDeserializer.DeserializeGeneralStats, token);
        }

        /// <summary>
        /// Gets the <see cref="LegacyOperatorStats"/> for the <see cref="UbisoftAccount"/> provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="LegacyOperatorStats"/> for the provided <see cref="UbisoftAccount"/></returns>
        public static Task<IEnumerable<LegacyOperatorStats>> GetLegacyOperatorStatsAsync(this Dragon6Client client, UbisoftAccount account, CancellationToken token = default)
        {
            return GetLegacyOperatorStatsAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the <see cref="LegacyOperatorStats"/> for the <see cref="UbisoftAccount"/>s provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="LegacyOperatorStats"/> for the provided <see cref="UbisoftAccount"/></returns>
        public static Task<ILookup<string, LegacyOperatorStats>> GetLegacyOperatorStatsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default)
        {
            return GetLegacyStatsAsync(client, accounts, a => new LegacyStatsRequest(a, LegacyStatTypes.Operators), LegacyStatsDeserializer.DeserializeOperatorStats, token);
        }

        /// <summary>
        /// Gets the <see cref="LegacyWeaponStats"/> for the <see cref="UbisoftAccount"/> provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="LegacyWeaponStats"/> for the provided <see cref="UbisoftAccount"/></returns>
        public static Task<IEnumerable<LegacyWeaponStats>> GetLegacyWeaponStatsAsync(this Dragon6Client client, UbisoftAccount account, CancellationToken token = default)
        {
            return GetLegacyWeaponStatsAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the <see cref="LegacyWeaponStats"/> for the <see cref="UbisoftAccount"/>s provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="ILookup{TKey,TElement}"/> of <see cref="LegacyWeaponStats"/> for the provided <see cref="UbisoftAccount"/></returns>
        public static Task<ILookup<string, LegacyWeaponStats>> GetLegacyWeaponStatsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default)
        {
            return GetLegacyStatsAsync(client, accounts, a => new LegacyStatsRequest(a, LegacyStatTypes.Weapons), LegacyStatsDeserializer.DeserializeWeaponStats, token);
        }

        /// <summary>
        /// Gets the <see cref="LegacyLevelStats"/> for the <see cref="UbisoftAccount"/> provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="LegacyWeaponStats"/> for the provided <see cref="UbisoftAccount"/>, or null if not found</returns>
        public static Task<LegacyLevelStats> GetLegacyLevelAsync(this Dragon6Client client, UbisoftAccount account, CancellationToken token = default)
        {
            return GetLegacyLevelAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the <see cref="LegacyLevelStats"/> for the <see cref="UbisoftAccount"/>s provided
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey,TValue}"/> of <see cref="LegacyWeaponStats"/> for the provided <see cref="UbisoftAccount"/></returns>
        public static Task<IReadOnlyDictionary<string, LegacyLevelStats>> GetLegacyLevelAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default)
        {
            return GetLegacyStatsAsync(client, accounts, a => new PlayerLevelStatsRequest(a), LegacyStatsDeserializer.DeserializePlayerLevelStats, token);
        }

        private static Task<T> GetLegacyStatsAsync<T>(ApiClient client, IEnumerable<UbisoftAccount> accounts, Func<IEnumerable<UbisoftAccount>, PlatformSpecificRequest> requestFactory, Func<JObject, T> postProcessor, CancellationToken token)
        {
            // LegacyStatsRequest is a PlatformSpecific request, so the accounts need to be split by platform
            var requests = accounts.GroupBy(x => x.Platform).Select(x =>
            {
                var platformRequest = requestFactory.Invoke(x);
                return client.PerformAsync<JObject>(platformRequest, token);
            });

            // let the consumer do the awaiting
            return Task.WhenAll(requests).ContinueWith(t =>
            {
                // merge all JObjects together
                var aggregatedJson = t.Result.Aggregate((a, b) =>
                {
                    a.Merge(b);

                    // Merge returns void, so return the first object
                    return a;
                });

                return postProcessor.Invoke(aggregatedJson);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
