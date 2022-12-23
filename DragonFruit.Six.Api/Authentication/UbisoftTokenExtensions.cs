// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Authentication.Entities;
using DragonFruit.Six.Api.Authentication.Requests;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Authentication
{
    public static class UbisoftTokenExtensions
    {
        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistent storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="loginString">The base64 encoded string in the format username:password</param>
        /// <param name="service"><see cref="UbisoftService"/> to get the token for. If the <see cref="ApiClient{T}"/> is a <see cref="Dragon6Client"/>, this is optional</param>
        /// <param name="token">Optional cancellation token</param>
        public static async Task<UbisoftToken> GetUbiTokenAsync(this ApiClient client, string loginString, UbisoftService? service = null, CancellationToken token = default)
        {
            if (client is Dragon6Client d6Client)
            {
                service ??= d6Client.DefaultService;
            }

            if (!service.HasValue)
            {
                throw new ArgumentException($"{nameof(service)} must be non-null when used with a client that does not inherit from {nameof(Dragon6Client)}");
            }

            var ubisoftToken = await client.PerformAsync<UbisoftToken>(new UbisoftTokenRequest(service.Value, loginString), token).ConfigureAwait(false);
            ubisoftToken.AppId = service.Value.AppId();

            return ubisoftToken;
        }

        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistent storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        /// <param name="service"><see cref="UbisoftService"/> to get the token for. If the <see cref="ApiClient{T}"/> is a <see cref="Dragon6Client"/>, this is optional</param>
        /// <param name="token">Optional cancellation token</param>
        public static Task<UbisoftToken> GetUbiTokenAsync(this ApiClient client, string username, string password, UbisoftService? service = null, CancellationToken token = default)
        {
            var basicLogin = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            return GetUbiTokenAsync(client, basicLogin, service, token);
        }
    }
}
