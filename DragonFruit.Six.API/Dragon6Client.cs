// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net;
using System.Net.Http;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.API.Data.Requests;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Exceptions;
using DragonFruit.Six.API.Helpers;

namespace DragonFruit.Six.API
{
    public abstract class Dragon6Client : ApiClient
    {
        private readonly object _lock = new object();

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
            Serializer = new ApiJsonSerializer(References.Culture);
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

        public T Perform<T>(UbiApiRequest requestData) where T : class
        {
            lock (_lock)
            {
                if (Token?.Expired ?? true)
                {
                    Token = GetToken();
                    Authorization = $"Ubi_v1 t={Token.Token}";
                }
            }

            return base.Perform<T>(requestData);
        }

        /// <summary>
        /// Handles the response before trying to deserialize it. If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override T ValidateAndProcess<T>(HttpResponseMessage response, HttpRequestMessage request) =>
            response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => throw new InvalidTokenException(Token),
                HttpStatusCode.Forbidden => throw new UbisoftErrorException(),
                _ => base.ValidateAndProcess<T>(response, request)
            };

        internal T BypassingPerform<T>(TokenRequest request) where T : class => base.Perform<T>(request);
    }
}
