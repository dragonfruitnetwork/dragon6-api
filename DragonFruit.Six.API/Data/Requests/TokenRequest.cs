// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net.Http;
using System.Text;
using DragonFruit.Common.Data;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class TokenRequest : UbiApiRequest
    {
        public override string Path => Endpoints.IdServer + "/sessions";

        public override Methods Method => Methods.Post;

        public override DataTypes DataType => DataTypes.Custom;

        //tokens need an empty request body in UTF8, with app/json type...
        public override HttpContent GetContent => new StringContent(string.Empty, Encoding.UTF8, "application/json");

        public override string AcceptedContent => "application/json";

        public override bool RequireAuth => true;
    }
}
