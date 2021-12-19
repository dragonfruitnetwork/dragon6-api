// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

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
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api
{
    public abstract class Dragon6Client : ApiClient<ApiJsonSerializer>
    {
        private ClientAccessToken _access;
        private readonly object _accessSync = new();
        
        public static readonly CultureInfo Culture = new("en-US", false);

        protected Dragon6Client(string userAgent = null, UbisoftService app = UbisoftService.RainbowSix)
        {
            AppId = app.AppId();
            UserAgent = userAgent ?? "Dragon6-API";
            Serializer.Configure<ApiJsonSerializer>(o => o.Serializer.Culture = Culture);
        }

        private IUbisoftToken Token { get; set; }

        /// <summary>
        /// The Ubi-AppId header to be supplied to each request. Defaults to <see cref="UbisoftService.RainbowSix"/>
        /// </summary>
        public string AppId
        {
            get => Headers[UbisoftIdentifiers.UbiAppIdHeader];
            set => Headers[UbisoftIdentifiers.UbiAppIdHeader] = value;
        }

        /// <summary>
        /// Defines the procedure for retrieving a <see cref="UbisoftToken"/> for the client to use.
        /// </summary>
        /// <remarks>
        /// It is recommended to store the token to a file and try to retrieve from there before resorting to the online systems, as accounts can be blocked due to rate-limits
        /// </remarks>
        protected abstract IUbisoftToken GetToken();

        /// <summary>
        /// Handles the response before trying to deserialize it.
        /// If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override Task<T> ValidateAndProcess<T>(HttpResponseMessage response) => response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => throw new InvalidTokenException(Token),

            HttpStatusCode.BadRequest => throw new ArgumentException("Request was poorly formed. Check the properties passed and try again"),

            HttpStatusCode.Forbidden => throw new UbisoftErrorException(),
            HttpStatusCode.BadGateway => throw new UbisoftErrorException(),

            _ => base.ValidateAndProcess<T>(response)
        };

        protected internal ClientAccessToken RequestAccessToken()
        {
            if (_access?.Expired is false)
            {
                return _access;
            }

            lock (_accessSync)
            {
                // check again in case of a backlog of requests
                if (_access?.Expired is not false)
                {
                    _access = new ClientAccessToken(GetToken());
                }

                return _access;
            }
        }
    }
}
