// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    public class ClientAccessToken
    {
        private readonly IUbisoftToken _token;
        private readonly DateTime _tokenExpiryOffset;

        internal ClientAccessToken(IUbisoftToken token)
        {
            _token = token;
            _tokenExpiryOffset = new DateTime(Math.Max(_token.Expiry.Ticks - 3000000000, 0), DateTimeKind.Utc);
        }

        internal bool Expired => _tokenExpiryOffset < DateTime.UtcNow;

        /// <summary>
        /// Injects Ubisoft authentication headers into the <see cref="ApiRequest"/> provided
        /// </summary>
        public void Inject(ApiRequest request)
        {
            request.WithAuthHeader($"ubi_v1 t={_token.Token}");
            request.WithHeader(UbisoftIdentifiers.UbiSessionIdHeader, _token.SessionId);
        }
    }
}
