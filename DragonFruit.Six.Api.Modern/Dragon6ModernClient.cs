// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Tokens;

namespace DragonFruit.Six.Api.Modern
{
    /// <summary>
    /// A type of <see cref="Dragon6Client"/> with the additions needed to get modern stats
    /// </summary>
    public abstract class ModernDragon6Client : Dragon6Client
    {
        private const string UbiSessionId = "Ubi-SessionId";

        /// <summary>
        /// Guid generated per-session for using Ubisoft's modern stats
        /// </summary>
        public string SessionId
        {
            get => Headers[UbiSessionId];
            private set => Headers[UbiSessionId] = value;
        }

        protected override void ApplyToken(TokenBase currentToken)
        {
            base.ApplyToken(currentToken);

            SessionId = currentToken.SessionId ?? Guid.NewGuid().ToString();
            Headers["Expiration"] = currentToken.Expiry.UtcDateTime.ToString("O");
        }

        protected override Task<T> ValidateAndProcess<T>(HttpResponseMessage response) => response.StatusCode switch
        {
            HttpStatusCode.NoContent => default,

            _ => base.ValidateAndProcess<T>(response)
        };
    }
}
