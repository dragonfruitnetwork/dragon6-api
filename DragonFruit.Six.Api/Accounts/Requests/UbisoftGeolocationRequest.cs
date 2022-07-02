// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Data.Requests;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Accounts.Requests
{
    public class UbisoftGeolocationRequest : ApiRequest, IRequestExecutingCallback
    {
        public override string Path => $"{Endpoints.BaseEndpoint}/v2/profiles/me/iplocation";

        void IRequestExecutingCallback.OnRequestExecuting(ApiClient client)
        {
            if (client is not Dragon6Client)
            {
                // can run on anything but needs a ubi-appid header if we're not using dragon6 client
                this.WithHeader(UbisoftIdentifiers.UbiAppIdHeader, UbisoftService.NewStatsSite.AppId());
            }
        }
    }
}
