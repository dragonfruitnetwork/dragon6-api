// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Developer.Requests
{
    public class DeveloperSessionRequest : DeveloperApiRequest
    {
        public override string Path => "https://dragon6.dragonfruit.network/api/sessions/dev";

        public DeveloperSessionRequest(uint appId, string secret)
        {
            AppId = appId;
            Secret = secret;
        }

        [QueryParameter("app")]
        private uint AppId { get; set; }

        [QueryParameter("secret")]
        private string Secret { get; set; }
    }
}
