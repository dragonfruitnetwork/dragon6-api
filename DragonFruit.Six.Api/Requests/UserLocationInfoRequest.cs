// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.Api.Requests
{
    public class UserLocationInfoRequest : ApiRequest
    {
        public override string Path => $"{Endpoints.BaseEndpoint}/v2/profiles/me/iplocation";
    }
}
