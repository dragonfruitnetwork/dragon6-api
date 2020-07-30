// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net;
using System.Net.Http;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Extensions;
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

            if (string.IsNullOrEmpty(UserAgent))
            {
                UserAgent = "Dragon6 API";
            }
        }

        #endregion

        private TokenBase Token { get; set; }

        public virtual string AppId { get; set; } = UbisoftIdentifiers.Websites[UbisoftService.RainbowSix];

        /// <summary>
        /// Method for getting a new <see cref="TokenBase"/>
        /// </summary>
        protected abstract TokenBase GetToken();

        /// <summary>
        /// Modified <see cref="ClientHash"/> hash with the <see cref="AppId"/> added
        /// </summary>
        protected override string ClientHash => $"{base.ClientHash}.{AppId.ItemHashCode()}";

        /// <summary>
        /// Adds the Ubi-AppId header to the client
        /// </summary>
        protected override void SetupClient(HttpClient client)
        {
            //add ubi appid
            client.DefaultRequestHeaders.Add("Ubi-AppId", AppId);
        }

        public T Perform<T>(UbiApiRequest requestData) where T : class
        {
            //override appid if the request has one
            if (requestData.AppId != null)
            {
                requestData.Headers.Value.Add("Ubi-AppId", requestData.AppId);
            }

            return Perform<T>((ApiRequest)requestData);
        }

        public override T Perform<T>(ApiRequest requestData) where T : class
        {
            if (Token?.Expired ?? true)
            {
                UpdateTokenHeader();
            }

            return base.Perform<T>(requestData);
        }

        internal UbisoftToken Perform(TokenRequest request) => base.Perform<UbisoftToken>(request);

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

        /// <summary>
        /// Procedure for updating a token header
        /// </summary>
        private void UpdateTokenHeader()
        {
            Token = GetToken();
            Authorization = $"Ubi_v1 t={Token.Token}";
        }
    }
}
