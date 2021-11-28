// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.Api.Tokens;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Exceptions;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api
{
    public abstract class Dragon6Client : ApiClient<ApiJsonSerializer>
    {
        private readonly object _lock = new();
        public static readonly CultureInfo Culture = new("en-US", false);

        protected Dragon6Client(string userAgent = null, UbisoftService app = UbisoftService.RainbowSix)
        {
            AppId = app.AppId();
            UserAgent = userAgent ?? "Dragon6-API";
            Serializer.Configure<ApiJsonSerializer>(o => o.Serializer.Culture = Culture);
        }

        private TokenBase Token { get; set; }

        /// <summary>
        /// The Ubi-AppId header to be supplied to each request. Defaults to <see cref="UbisoftService.RainbowSix"/> in <see cref="UbisoftIdentifiers.Websites"/>
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
        protected abstract TokenBase GetToken();

        /// <summary>
        /// Defines how a new token is applied to the client.
        /// </summary>
        protected virtual void ApplyToken(TokenBase token)
        {
            Authorization = $"ubi_v1 t={token.Token}";
        }

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

        internal void ValidateToken()
        {
            lock (_lock)
            {
                if (Token?.Expired != true)
                {
                    // todo throw something if this is majorly expired or null
                    Token = GetToken();

                    ApplyToken(Token);
                }
            }
        }
    }
}
