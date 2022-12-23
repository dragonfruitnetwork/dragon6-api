// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Concurrent;
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

namespace DragonFruit.Six.Api
{
    public abstract class Dragon6Client : ApiClient<ApiJsonSerializer>
    {
        private readonly ConcurrentDictionary<UbisoftService, ClientTokenAccessor> _access = new();

        protected Dragon6Client(string userAgent = null)
        {
            UserAgent = userAgent ?? "Dragon6-API";
            Serializer.Configure<ApiJsonSerializer>(o => o.Serializer.Culture = CultureInfo.InvariantCulture);
        }

        static Dragon6Client()
        {
            LegacyStatsMapping.InitialiseStatsBuckets();
        }

        /// <summary>
        /// The default <see cref="UbisoftService"/> to use in requests. Some APIs may override this and require a specific service to be used.
        /// </summary>
        public UbisoftService DefaultService { get; set; } = UbisoftService.RainbowSix;

        /// <summary>
        /// Defines the procedure for retrieving a <see cref="UbisoftToken"/> for the client to use.
        /// </summary>
        /// <param name="service">The service to fetch a token for</param>
        /// <param name="sessionId">The last recorded session id. This should be used to check if a new session should be created from the server</param>
        /// <remarks>
        /// It is recommended to store the token to a file and try to retrieve from there before resorting to the online systems, as accounts can be blocked due to rate-limits
        /// </remarks>
        protected abstract Task<IUbisoftToken> GetToken(UbisoftService service, string sessionId);

        /// <summary>
        /// Handles the response before trying to deserialize it.
        /// If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override async Task<T> ValidateAndProcess<T>(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.InternalServerError:
                    var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    throw new UbisoftErrorException(response.StatusCode, error);

                case HttpStatusCode.Unauthorized:
                    throw new InvalidTokenException(response.RequestMessage.Headers.Authorization.ToString());

                case HttpStatusCode.BadRequest:
                    throw new ArgumentException("Request was poorly formed. Check the properties passed and try again");

                case HttpStatusCode.NoContent:
                    return default;

                default:
                    return await base.ValidateAndProcess<T>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets a <see cref="ClientTokenAccessor"/> for the requested <see cref="UbisoftService"/>
        /// </summary>
        protected internal ClientTokenAccessor GetServiceAccessToken(UbisoftService service) => _access.GetOrAdd(service, s => new ClientTokenAccessor(s, GetToken));
    }
}
