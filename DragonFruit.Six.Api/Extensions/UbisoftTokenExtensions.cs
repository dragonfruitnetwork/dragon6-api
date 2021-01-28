// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Text;
using System.Threading;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Tokens;

namespace DragonFruit.Six.Api.Extensions
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
        public static UbisoftToken GetUbiToken<T>(this T client, string loginString, CancellationToken token = default) where T : Dragon6Client
        {
            var request = new TokenRequest(loginString);
            return client.DirectPerform<UbisoftToken>(request, token);
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
        public static UbisoftToken GetUbiToken<T>(this T client, string username, string password, CancellationToken token = default) where T : Dragon6Client
        {
            var loginString = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            var request = new TokenRequest(loginString);

            return client.DirectPerform<UbisoftToken>(request, token);
        }
    }
}
