// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;

namespace DragonFruit.Six.Api.Legacy.Requests
{
    public class LegacyOperatorInfoRequest : ApiRequest
    {
        public override string Path => $"{Endpoints.AssetsEndpoint}/data/operators.json";
    }
}
