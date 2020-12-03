// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Developer.Auth
{
    public class DeveloperSessionRequest : DeveloperApiRequest
    {
        public override string Path => $"{BaseEndpoint}/api/oauth";

        protected override Methods Method => Methods.Post;
        protected override BodyType BodyType => BodyType.Encoded;
        protected override bool RequireAuth => false;

        public DeveloperSessionRequest(uint appId, string secret)
        {
            AppId = appId;
            Secret = secret;
        }

        [FormParameter("client_id")]
        private uint AppId { get; set; }

        [FormParameter("client_secret")]
        private string Secret { get; set; }

        [FormParameter("grant_type")]
        private string Grant => "client_credentials";
    }
}
