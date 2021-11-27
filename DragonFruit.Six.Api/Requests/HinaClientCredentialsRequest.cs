// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.Api.Requests
{
    internal class HinaClientCredentialsRequest : ApiRequest
    {
        public override string Path => "https://id.dragonfruit.network/connect/token";

        protected override Methods Method => Methods.Post;

        [FormParameter("client_id")]
        public string ClientId { get; set; }

        [FormParameter("client_secret")]
        public string ClientSecret { get; set; }

        [FormParameter("scope")]
        public string Scopes { get; set; }

        [FormParameter("grant_type")]
        protected string GrantType => "client_credentials";
    }
}
