// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Exceptions;

namespace DragonFruit.Six.API.Clients
{
    public abstract class Dragon6Client : ApiClient
    {
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
            : this()
        {
            UserAgent = userAgent;
        }

        protected Dragon6Client()
        {
            Serializer = new ApiJsonSerializer(References.Culture);

            if (string.IsNullOrEmpty(UserAgent))
            {
                UserAgent = "Dragon6";
            }
        }

        private TokenBase Token { get; set; }

        public virtual string AppId { get; set; } = References.AppId;

        /// <summary>
        /// Method for getting a new <see cref="TokenBase"/>
        /// </summary>
        protected abstract TokenBase GetToken();

        /// <summary>
        /// Modified <see cref="ClientHash"/> hash with the <see cref="AppId"/> added
        /// </summary>
        protected override string ClientHash => $"{base.ClientHash}.{AppId.ItemHashCode()}";

        /// <summary>
        /// Adds the Ubi-AppId header to the request
        /// </summary>
        protected override void SetupClient(HttpClient client)
        {
            //add ubi appid
            client.DefaultRequestHeaders.Add("Ubi-AppId", AppId);
        }

        public T Perform<T>(UbiApiRequest requestData) where T : class
        {
            //override appid if they aren't the same
            if (requestData.AppId != null)
                AppId = requestData.AppId;

            return Perform<T>((ApiRequest)requestData);
        }

        public override T Perform<T>(ApiRequest requestData) where T : class
        {
            if (Token == null)
            {
                UpdateTokenHeader();
            }

            if (Token.Expired)
            {
                UpdateTokenHeader();
            }

            return base.Perform<T>(requestData);
        }

        /// <summary>
        /// Handles the response before trying to deserialize it. If a recognized error code has been returned, an appropriate exception will be thrown.
        /// </summary>
        protected override T ValidateAndProcess<T>(Task<HttpResponseMessage> response) =>
            response.Result.StatusCode switch
            {
                HttpStatusCode.Unauthorized => throw new InvalidTokenException(Token),
                HttpStatusCode.Forbidden => throw new UbisoftErrorException(),
                _ => base.ValidateAndProcess<T>(response)
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
