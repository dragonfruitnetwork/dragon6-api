// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class GeolocationRequest : UbiApiRequest
    {
        public override string Path => $"{Endpoints.BaseEndpoint}/v2/profiles/me/iplocation";

        protected override void OnRequestExecuting(ApiClient client)
        {
            if (client is not Dragon6Client)
            {
                // can run on anything but needs a ubi-appid header if we're not using dragon6 client
                this.WithHeader(UbisoftIdentifiers.UbiAppIdHeader, UbisoftService.NewStatsSite.AppId());
            }
        }
    }
}
