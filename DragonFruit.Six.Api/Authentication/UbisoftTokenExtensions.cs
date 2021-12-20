﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Authentication.Entities;
using DragonFruit.Six.Api.Authentication.Requests;

namespace DragonFruit.Six.Api.Authentication
{
    public static class UbisoftTokenExtensions
    {
        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistant storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="loginString">The base64 encoded string in the format username:password</param>
        /// <param name="token">Optional cancellation token</param>
        public static UbisoftToken GetUbiToken(this ApiClient client, string loginString, CancellationToken token = default)
        {
            return client.Perform<UbisoftToken>(UbisoftTokenRequest.FromEncodedCredentials(loginString), token);
        }

        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistant storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="loginString">The base64 encoded string in the format username:password</param>
        /// <param name="token">Optional cancellation token</param>
        public static Task<UbisoftToken> GetUbiTokenAsync(this ApiClient client, string loginString, CancellationToken token = default)
        {
            return client.PerformAsync<UbisoftToken>(UbisoftTokenRequest.FromEncodedCredentials(loginString), token);
        }

        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistant storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        /// <param name="token">Optional cancellation token</param>
        public static UbisoftToken GetUbiToken(this ApiClient client, string username, string password, CancellationToken token = default)
        {
            return client.Perform<UbisoftToken>(UbisoftTokenRequest.FromUsername(username, password), token);
        }

        /// <summary>
        /// Gets a session token for the user credentials provided.
        /// </summary>
        /// <remarks>
        /// You should store this in some form of persistant storage, as requesting these
        /// too many times will result in a cooldown which is reset every time you try to access the resource
        /// during said cooldown
        /// </remarks>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="username">The username to use</param>
        /// <param name="password">The password to use</param>
        /// <param name="token">Optional cancellation token</param>
        public static Task<UbisoftToken> GetUbiTokenAsync(this ApiClient client, string username, string password, CancellationToken token = default)
        {
            return client.PerformAsync<UbisoftToken>(UbisoftTokenRequest.FromUsername(username, password), token);
        }
    }
}