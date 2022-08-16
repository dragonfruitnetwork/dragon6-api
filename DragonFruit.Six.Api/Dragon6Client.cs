// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Authentication.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Exceptions;
using DragonFruit.Six.Api.Legacy.Utils;
using Nito.AsyncEx;

namespace DragonFruit.Six.Api
{
    public abstract class Dragon6Client : ApiClient<ApiJsonSerializer>
    {
        private ClientTokenInjector _access;
        private readonly AsyncLock _accessSync = new();

        protected Dragon6Client(string userAgent = null, UbisoftService app = UbisoftService.RainbowSix)
        {
            SetUbiAppId(app);
            UserAgent = userAgent ?? "Dragon6-API";
            Serializer.Configure<ApiJsonSerializer>(o => o.Serializer.Culture = CultureInfo.InvariantCulture);
        }

        static Dragon6Client()
        {
            LegacyStatsMapping.InitialiseStatsBuckets();
        }

        /// <summary>
        /// Defines the procedure for retrieving a <see cref="UbisoftToken"/> for the client to use.
        /// </summary>
        /// <param name="sessionId">The last recorded session id. This should be used to check if a new session should be created from the server</param>
        /// <remarks>
        /// It is recommended to store the token to a file and try to retrieve from there before resorting to the online systems, as accounts can be blocked due to rate-limits
        /// </remarks>
        protected abstract Task<IUbisoftToken> GetToken(string sessionId);

        /// <summary>
        /// Updates the Ubi-AppId header to be supplied to each request.
        /// Defaults to <see cref="UbisoftService.RainbowSix"/>
        /// </summary>
        public void SetUbiAppId(UbisoftService service) => Headers[UbisoftIdentifiers.UbiAppIdHeader] = service.AppId();

        /// <summary>
        /// Handles the response before trying to deserialize it.
        /// If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override Task<T> ValidateAndProcess<T>(HttpResponseMessage response) => response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => Task.FromException<T>(new InvalidTokenException(_access.Token)),

            HttpStatusCode.BadRequest => Task.FromException<T>(new ArgumentException("Request was poorly formed. Check the properties passed and try again")),

            HttpStatusCode.Forbidden => Task.FromException<T>(new UbisoftErrorException()),
            HttpStatusCode.BadGateway => Task.FromException<T>(new UbisoftErrorException()),

            HttpStatusCode.NoContent => Task.FromResult<T>(default),

            _ => base.ValidateAndProcess<T>(response)
        };

        protected internal async ValueTask<ClientTokenInjector> RequestToken()
        {
            if (_access?.Expired is false)
            {
                return _access;
            }

            using (await _accessSync.LockAsync().ConfigureAwait(false))
            {
                // check again in case of a backlog
                if (_access?.Expired is not false)
                {
                    var token = await GetToken(_access?.Token.SessionId).ConfigureAwait(false);
                    _access = new ClientTokenInjector(token);
                }

                return _access;
            }
        }
    }
}
