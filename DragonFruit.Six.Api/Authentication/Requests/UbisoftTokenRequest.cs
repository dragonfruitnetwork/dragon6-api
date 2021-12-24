// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Text;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;

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

        internal UbisoftTokenRequest()
        {
        }

        public static UbisoftTokenRequest FromEncodedCredentials(string basicAuth) => new UbisoftTokenRequest().WithAuthHeader($"Basic {basicAuth}");
        public static UbisoftTokenRequest FromUsername(string username, string password) => FromEncodedCredentials(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
    }
}
