// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Accounts.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Accounts
{
    public static class UbisoftAccountExtensions
    {
        /// <summary>
        /// Retrieves the public information for a Ubisoft Account
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="query">The account identifier</param>
        /// <param name="platform">The account's platform</param>
        /// <param name="identifierType">The type of identifier</param>
        /// <returns>The <see cref="UbisoftAccount"/> information, or null if not found</returns>
        public static Task<UbisoftAccount> GetAccountAsync(this Dragon6Client client, string query, Platform platform, IdentifierType identifierType)
        {
            var request = new UbisoftAccountRequest(query, platform, identifierType);
            return client.PerformAsync<JObject>(request).ContinueWith(t => t.Result.DeserializeUbisoftAccounts().SingleOrDefault(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Retrieves the public information for multiple Ubisoft Accounts
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="queries">The account identifiers to use</param>
        /// <param name="platform">The platform the identifiers are for</param>
        /// <param name="identifierType">The type of identifier the <see cref="queries"/> represent</param>
        /// <returns>The <see cref="UbisoftAccount"/> information for discovered accounts</returns>
        public static Task<IEnumerable<UbisoftAccount>> GetAccountsAsync(this Dragon6Client client, IEnumerable<string> queries, Platform platform, IdentifierType identifierType)
        {
            var request = new UbisoftAccountRequest(queries, platform, identifierType);
            return client.PerformAsync<JObject>(request).ContinueWith(t => t.Result.DeserializeUbisoftAccounts(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the current clearance level and XP of the provided <see cref="UbisoftAccount"/>
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get level stats for</param>
        /// <param name="token">Optional cancellation token</param>
        /// <returns><see cref="AccountLevel"/> containing the values for the user's level and xp</returns>
        public static Task<AccountLevel> GetAccountLevelAsync(this Dragon6Client client, UbisoftAccount account, CancellationToken token = default)
        {
            return client.PerformAsync<AccountLevel>(new AccountLevelRequest(account), token);
        }
    }
}
