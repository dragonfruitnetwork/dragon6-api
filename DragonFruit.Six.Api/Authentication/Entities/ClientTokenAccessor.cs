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
        private readonly AsyncLock _accessSync;
        private readonly UbisoftService _service;
        private readonly Func<UbisoftService, string, Task<IUbisoftToken>> _fetchTokenDelegate;

        private ClientTokenInjector _currentToken;

        internal ClientTokenAccessor(UbisoftService service, Func<UbisoftService, string, Task<IUbisoftToken>> fetchTokenDelegate)
        {
            _accessSync = new AsyncLock();

            _service = service;
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

                for (int i = 0; i < 3; i++)
                {
                    var token = await _fetchTokenDelegate.Invoke(_service, _currentToken?.Token.SessionId).ConfigureAwait(false);
                    _currentToken = new ClientTokenInjector(token);

                    if (!_currentToken.Expired)
                    {
                        return _currentToken;
                    }
                }

                throw new InvalidTokenException(_currentToken?.Token);
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
