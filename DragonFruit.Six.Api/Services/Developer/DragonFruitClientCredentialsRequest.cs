// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Parameters;

namespace DragonFruit.Six.Api.Services.Developer
{
    internal class DragonFruitClientCredentialsRequest : ApiRequest
    {
        public override string Path => "https://id.dragonfruit.network/connect/token";

        protected override Methods Method => Methods.Post;
        protected override BodyType BodyType => BodyType.Encoded;

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
