﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    public class ClientTokenInjector
    {
        private int? _maxUses;
        private readonly DateTime _tokenExpiryOffset;

        internal ClientTokenInjector(IUbisoftToken token, int? maxUses)
        {
            Token = token;

            _maxUses = maxUses;
            _tokenExpiryOffset = new DateTime(Math.Max(Token.Expiry.Ticks - 3000000000, 0), DateTimeKind.Utc);
        }

        internal IUbisoftToken Token { get; }

        internal bool Expired => _tokenExpiryOffset < DateTime.UtcNow || _maxUses <= 0;

        /// <summary>
        /// Injects Ubisoft authentication headers into the <see cref="ApiRequest"/> provided
        /// </summary>
        public void Inject(ApiRequest request)
        {
            if (_maxUses.HasValue)
            {
                _maxUses -= 1;
            }

            // all api requests need the ubi_v1 token
            // this must be lowercase for the modern api to work
            request.WithAuthHeader($"ubi_v1 t={Token.Token}");

            // modern api requests need both the session id and the expiration headers added
            request.WithHeader("Expiration", Token.Expiry.ToString("O"));
            request.WithHeader(UbisoftIdentifiers.UbiAppIdHeader, Token.AppId);
            request.WithHeader(UbisoftIdentifiers.UbiSessionIdHeader, Token.SessionId);
        }
    }
}
