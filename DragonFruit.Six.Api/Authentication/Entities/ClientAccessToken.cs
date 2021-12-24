// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    public class ClientAccessToken
    {
        internal readonly IUbisoftToken Token;
        private readonly DateTime _tokenExpiryOffset;

        internal ClientAccessToken(IUbisoftToken token)
        {
            Token = token;
            _tokenExpiryOffset = new DateTime(Math.Max(Token.Expiry.Ticks - 3000000000, 0), DateTimeKind.Utc);
        }

        internal bool Expired => _tokenExpiryOffset < DateTime.UtcNow;

        /// <summary>
        /// Injects Ubisoft authentication headers into the <see cref="ApiRequest"/> provided
        /// </summary>
        public void Inject(ApiRequest request)
        {
            request.WithAuthHeader($"ubi_v1 t={Token.Token}");
            request.WithHeader(UbisoftIdentifiers.UbiSessionIdHeader, Token.SessionId);
        }
    }
}
