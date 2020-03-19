// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class TokenRequest : ApiRequest
    {
        public override string Path => Endpoints.IdServer + "/sessions";

        public override Methods Method => Methods.PostString;

        public override string AcceptedContent => "application/json";

        public override bool RequireAuth => true;

        [StringParameter]
        public string Content => string.Empty;
    }
}
