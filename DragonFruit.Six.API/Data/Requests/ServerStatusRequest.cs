// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Data.Requests
{
    public class ServerStatusRequest : ApiRequest
    {
        public override string Path => "https://game-status-api.ubisoft.com/v1/instances";

        public ServerStatusRequest()
        {
            AppIds = Endpoints.GameIds.Values;
        }

        public ServerStatusRequest(IEnumerable<string> appIds)
        {
            AppIds = appIds;
        }

        private IEnumerable<string> AppIds { get; set; }

        [QueryParameter("appIds")]
        private string CompiledAppIds => string.Join(',', AppIds);
    }
}
