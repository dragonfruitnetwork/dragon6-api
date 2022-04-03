// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernOperatorInfoRequest : ApiRequest
    {
        public override string Path => $"{Endpoints.AssetsEndpoint}/data/operators-v2.json";
    }
}
