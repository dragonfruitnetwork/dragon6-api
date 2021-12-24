// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Accounts.Requests;
using DragonFruit.Six.Api.Utils;
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
        /// Retrieves the play statistics for a <see cref="UbisoftAccount"/>
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get play stats for</param>
        /// <returns>The <see cref="UbisoftAccountActivity"/> for the account, or <c>null</c> if the user does not own the game</returns>
        public static Task<UbisoftAccountActivity> GetAccountActivityAsync(this Dragon6Client client, UbisoftAccount account)
        {
            var request = new UbisoftAccountActivityRequest(account);
            return client.PerformAsync<JObject>(request).ContinueWith(t => t.Result.DeserializeUbisoftAccountActivity().For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Retrieves the play statistics for multiple <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get play stats for</param>
        /// <returns>A <see cref="UbisoftAccountActivity"/> for each account that owns the game</returns>
        public static Task<IReadOnlyDictionary<string, UbisoftAccountActivity>> GetAccountActivityAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts)
        {
            var request = new UbisoftAccountActivityRequest(accounts);
            return client.PerformAsync<JObject>(request).ContinueWith(t => t.Result.DeserializeUbisoftAccountActivity());
        }

        /// <summary>
        /// Get the current device location based on a IP Geolocation lookup
        /// </summary>
        public static Task<Geolocation> GeolocateAsync(this ApiClient client) => client.PerformAsync<Geolocation>(new UbisoftGeolocationRequest());
    }
}
