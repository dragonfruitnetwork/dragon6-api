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
        private readonly DateTimeOffset _tokenExpiryOffset;

        internal ClientAccessToken(IUbisoftToken token)
        {
            _token = token;
            _tokenExpiryOffset = new DateTimeOffset(Math.Max(_token.Expiry.UtcTicks - 3000000000, 0), TimeSpan.Zero);
        }

        internal bool Expired => _tokenExpiryOffset < DateTimeOffset.Now;

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
