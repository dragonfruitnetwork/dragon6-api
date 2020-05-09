// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.Developer.Requests
{
    public class DeveloperSessionRequest : ApiRequest
    {
        public override string Path => "https://dragon6.dragonfruit.network/api/sessions/dev";

        public DeveloperSessionRequest(string key)
        {
            DeveloperKey = key;
        }

        [QueryParameter("k")]
        public string DeveloperKey { get; set; }
    }
}
