// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.Api.Requests.Base;
using DragonFruit.Six.Api.Tokens;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Exceptions;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api
{
    public abstract class Dragon6Client : ApiClient
    {
        private readonly object _lock = new();
        public static readonly CultureInfo Culture = new("en-US", false);

        #region Constructors

        protected Dragon6Client(TokenBase token)
            : this()
        {
            Token = token;
        }

        protected Dragon6Client(string userAgent)
            : this()
        {
            UserAgent = userAgent;
        }

        protected Dragon6Client(string userAgent, string appId)
            : this(userAgent)
        {
            AppId = appId;
        }

        protected Dragon6Client()
        {
            Serializer = new ApiJsonSerializer(Culture);
            AppId = UbisoftService.RainbowSix.AppId();

            if (string.IsNullOrEmpty(UserAgent))
            {
                UserAgent = "Dragon6 API";
            }
        }

        #endregion

        private TokenBase Token { get; set; }

        /// <summary>
        /// The Ubi-AppId header to be supplied to each request. Defaults to <see cref="UbisoftService.RainbowSix"/> in <see cref="UbisoftIdentifiers.Websites"/>
        /// </summary>
        public string AppId
        {
            get => Headers["Ubi-AppId"];
            set => Headers["Ubi-AppId"] = value;
        }

        /// <summary>
        /// Method for getting a new <see cref="TokenBase"/>
        /// </summary>
        protected abstract TokenBase GetToken();

        public T Perform<T>(UbiApiRequest requestData, CancellationToken token = default) where T : class
        {
            lock (_lock)
            {
                if (Token is null || Token.Expired)
                {
                    // todo throw something if this is majorly expired or null
                    Token = GetToken();
                    ApplyToken(Token);
                }
            }

            return base.Perform<T>(requestData, token);
        }

        /// <summary>
        /// Method for setting a new token
        /// </summary>
        protected virtual void ApplyToken(TokenBase currentToken)
        {
            Authorization = $"ubi_v1 t={Token.Token}";
        }

        /// <summary>
        /// Handles the response before trying to deserialize it. If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override T ValidateAndProcess<T>(HttpResponseMessage response, HttpRequestMessage request) => response.StatusCode switch
        {
            HttpStatusCode.Unauthorized => throw new InvalidTokenException(Token),

            HttpStatusCode.BadRequest => throw new ArgumentException("Request was poorly formed. Check the properties passed and try again"),

            HttpStatusCode.Forbidden => throw new UbisoftErrorException(),
            HttpStatusCode.BadGateway => throw new UbisoftErrorException(),

            _ => base.ValidateAndProcess<T>(response, request)
        };

        /// <summary>
        /// <see cref="Perform{T}"/> method that bypasses all auth checks
        /// </summary>
        protected internal T DirectPerform<T>(ApiRequest request, CancellationToken token = default) where T : class => base.Perform<T>(request, token);
    }
}
