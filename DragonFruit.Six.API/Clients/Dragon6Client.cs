// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.API.Data.Tokens;

namespace DragonFruit.Six.API.Clients
{
    public abstract class Dragon6Client : ApiClient
    {
        protected Dragon6Client(TokenBase token)
            : this()
        {
            _token = token;
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
            _appId = appId;
        }

        protected Dragon6Client()
        {
            Serializer = new ApiJsonSerializer(References.Culture);
            CustomHeaders.Add(new KeyValuePair<string, string>("Ubi-AppId", _appId));

            if (string.IsNullOrEmpty(UserAgent))
            {
                UserAgent = "Dragon6";
            }
        }

        private readonly string _appId = References.AppId;
        private TokenBase _token;

        /// <summary>
        /// Method for getting a new <see cref="TokenBase"/>
        /// </summary>
        protected abstract TokenBase GetToken();

        private void UpdateTokenHeader()
        {
            _token = GetToken();
            Authorization = $"Ubi_v1 t={_token.Token}";
        }

        public override T Perform<T>(ApiRequest requestData)
        {
            if (_token == null)
            {
                UpdateTokenHeader();
            }

            if (_token.Expired)
            {
                UpdateTokenHeader();
            }

            return base.Perform<T>(requestData);
        }
    }
}
