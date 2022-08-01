// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Authentication.Entities;
using Nito.AsyncEx;

namespace DragonFruit.Six.Api.Services.Developer
{
    public class Dragon6DeveloperClient : Dragon6Client
    {
        private DragonFruitClientCredentials _access;

        private readonly AsyncLock _accessSync = new();
        private readonly string _clientId, _clientSecret, _scopes;

        public Dragon6DeveloperClient(string clientId, string clientSecret, string scopes)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _scopes = scopes;
        }

        protected override async Task<IUbisoftToken> GetToken(string sessionId)
        {
            return await PerformAsync<Dragon6Token>(new Dragon6TokenRequest()).ConfigureAwait(false);
        }

        internal async ValueTask<DragonFruitClientCredentials> RequestDragonFruitAccessToken()
        {
            if (_access?.ExpiresUtc > DateTime.UtcNow)
            {
                return _access;
            }

            using (await _accessSync.LockAsync().ConfigureAwait(false))
            {
                if (_access is null || _access.ExpiresUtc <= DateTime.UtcNow)
                {
                    var request = new DragonFruitClientCredentialsRequest
                    {
                        ClientId = _clientId,
                        ClientSecret = _clientSecret,
                        Scopes = _scopes
                    };

                    _access = await PerformAsync<DragonFruitClientCredentials>(request).ConfigureAwait(false);
                }

                return _access;
            }
        }
    }
}
