// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Authentication.Entities;

namespace DragonFruit.Six.Api.Services.Developer
{
    public class Dragon6DeveloperClient : Dragon6Client
    {
        private readonly object _accessSync = new();
        private DragonFruitClientCredentials _access;
        private readonly string _clientId, _clientSecret, _scopes;

        public Dragon6DeveloperClient(string clientId, string clientSecret, string scopes)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scopes = scopes;
        }

        protected override IUbisoftToken GetToken() => Perform<Dragon6Token>(new Dragon6TokenRequest());

        internal DragonFruitClientCredentials RequestDragonFruitAccessToken()
        {
            if (_access?.ExpiresUtc > DateTime.UtcNow)
            {
                return _access;
            }

            lock (_accessSync)
            {
                if (_access is null || _access.ExpiresUtc <= DateTime.UtcNow)
                {
                    _access = Perform<DragonFruitClientCredentials>(new DragonFruitClientCredentialsRequest
                    {
                        ClientId = _clientId,
                        ClientSecret = _clientSecret,
                        Scopes = _scopes
                    });
                }

                return _access;
            }
        }
    }
}
