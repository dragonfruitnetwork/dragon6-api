// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.API.Data.Tokens;

namespace DragonFruit.Six.API.Clients
{
    public class Dragon6Client : ApiClient
    {
        public Dragon6Client(TokenBase token)
        {
            Token = token;
        }

        public Dragon6Client(string userAgent)
            : this()
        {
            UserAgent = userAgent;
        }

        public Dragon6Client(string userAgent, string appId)
            : this()
        {
            UserAgent = userAgent;
            AppId = appId;
        }

        public Dragon6Client()
        {
            Serializer = new ApiJsonSerializer(References.Culture);
            UserAgent = "Dragon6";
            CustomHeaders.Add(new KeyValuePair<string, string>("Ubi-AppId", AppId));
        }

        private string AppId { get; } = References.AppId;

        private TokenBase _token;

        public TokenBase Token
        {
            set
            {
                _token = value;
                Authorization = $"Ubi_v1 t={value.Token}";
            }
        }

        public override T Perform<T>(ApiRequest requestData)
        {
            if (_token.Expired)
                throw new Exception("Token is expired");

            return base.Perform<T>(requestData);
        }
    }
}
