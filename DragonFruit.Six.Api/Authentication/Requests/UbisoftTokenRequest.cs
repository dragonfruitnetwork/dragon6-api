// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Net.Http;
using System.Text;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Authentication.Requests
{
    public sealed class UbisoftTokenRequest : ApiRequest
    {
        public override string Path => Endpoints.IdServer + "/sessions";

        protected override Methods Method => Methods.Post;
        protected override BodyType BodyType => BodyType.Custom;
        protected override bool RequireAuth => true;

        // tokens need an empty request body in UTF8, with app/json type...
        protected override HttpContent BodyContent => new StringContent(string.Empty, Encoding.UTF8, "application/json");

        public UbisoftTokenRequest(UbisoftService service, string authentication)
        {
            this.WithHeader(UbisoftIdentifiers.UbiAppIdHeader, service.AppId());
            this.WithAuthHeader($"Basic {authentication}");
        }
    }
}
