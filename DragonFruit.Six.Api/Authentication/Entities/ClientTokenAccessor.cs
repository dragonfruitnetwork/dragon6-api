// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Exceptions;
using Nito.AsyncEx;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    public class ClientTokenAccessor
    {
        private readonly int? _maxTokenUses;
        private readonly AsyncLock _accessSync;
        private readonly UbisoftService _service;
        private readonly Func<UbisoftService, string, Task<IUbisoftToken>> _fetchTokenDelegate;

        private ClientTokenInjector _currentToken;

        internal ClientTokenAccessor(UbisoftService service, int? maxTokenUses, Func<UbisoftService, string, Task<IUbisoftToken>> fetchTokenDelegate)
        {
            _accessSync = new AsyncLock();

            _service = service;
            _maxTokenUses = maxTokenUses;
            _fetchTokenDelegate = fetchTokenDelegate;
        }

        /// <summary>
        /// Gets a <see cref="ClientTokenInjector"/> containing a valid token that can be injected into http requests
        /// </summary>
        public async ValueTask<ClientTokenInjector> GetInjector()
        {
            if (_currentToken?.Expired == false)
            {
                return _currentToken;
            }

            using (await _accessSync.LockAsync().ConfigureAwait(false))
            {
                // check again in case of a backlog
                if (_currentToken?.Expired == false)
                {
                    return _currentToken;
                }

                for (int i = 0; i < 2; i++)
                {
                    var token = await _fetchTokenDelegate.Invoke(_service, _currentToken?.Token.SessionId).ConfigureAwait(false);
                    _currentToken = new ClientTokenInjector(token, _maxTokenUses);

                    if (!_currentToken.Expired)
                    {
                        return _currentToken;
                    }
                }

                throw new InvalidTokenException(_currentToken?.Token);
            }
        }

        /// <summary>
        /// Expires the current token, forcing it to be re-fetched
        /// </summary>
        public async Task ClearToken()
        {
            using (await _accessSync.LockAsync().ConfigureAwait(false))
            {
                _currentToken = null;
            }
        }

        /// <summary>
        /// Gets a valid <see cref="IUbisoftToken"/>
        /// </summary>
        public async ValueTask<IUbisoftToken> GetToken()
        {
            var injector = await GetInjector().ConfigureAwait(false);
            return injector.Token;
        }
    }
}
