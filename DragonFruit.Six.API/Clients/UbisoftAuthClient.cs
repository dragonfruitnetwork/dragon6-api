// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Text;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Serializers;
using DragonFruit.Six.API.Data.Requests;
using DragonFruit.Six.API.Data.Tokens;

namespace DragonFruit.Six.API.Clients
{
    public class UbisoftAuthClient : ApiClient
    {
        private readonly TokenRequest _tokenRequest = new TokenRequest();

        public UbisoftAuthClient(string b64Login, string appid = null, string ua = "Dragon6")
        {
            UserAgent = ua;
            Authorization = $"Basic {b64Login}";

            CustomHeaders.Add(new KeyValuePair<string, string>("Ubi-AppId", appid ?? References.AppId));

            Serializer = new ApiJsonSerializer(References.Culture);
        }

        public UbisoftAuthClient(string username, string password, string appid = null, string ua = "Dragon6")
            : this(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")), appid, ua)
        {
        }

        public UbisoftToken GetToken() => Perform<UbisoftToken>(_tokenRequest);
    }
}
