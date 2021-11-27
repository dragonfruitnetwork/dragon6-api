// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Tokens;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api
{
    public class Dragon6DeveloperClient : Dragon6Client
    {
        private string _accessToken;
        private DateTime? _accessExpires;

        private readonly object _lock = new();
        private readonly string _clientId, _clientSecret, _scope;

        public Dragon6DeveloperClient(string clientId, string clientSecret, string scope)
        {
            _scope = scope;

            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        internal void ValidateAccess(ApiRequest sourceRequest)
        {
            lock (_lock)
            {
                if ((_accessExpires ?? DateTime.MinValue) < DateTime.UtcNow)
                {
                    var request = new HinaClientCredentialsRequest
                    {
                        Scopes = _scope,
                        ClientId = _clientId,
                        ClientSecret = _clientSecret
                    };

                    _accessExpires = DateTime.UtcNow.AddHours(6);
                    _accessToken = Perform<JObject>(request)["access_token"]!.ToString();
                }
            }

            sourceRequest.WithAuthHeader($"Bearer {_accessToken}");
        }

        protected override TokenBase GetToken() => Perform<Dragon6Token>(new DeveloperTokenRequest());
    }
}
