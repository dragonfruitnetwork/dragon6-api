// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Parameters;

namespace DragonFruit.Six.Api.Services.Developer
{
    internal class DragonFruitClientCredentialsRequest : ApiRequest
    {
        public override string Path => "https://id.dragonfruit.network/connect/token";

        [FormParameter("client_id")]
        public string ClientId { get; set; }

        [FormParameter("client_secret")]
        public string ClientSecret { get; set; }

        [FormParameter("grant_type")]
        private string GrantType => "client_credentials";

        [FormParameter("scopes")]
        public string Scopes { get; set; }
    }
}
