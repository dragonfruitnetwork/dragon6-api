// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Data.Requests;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Services.Geolocation.Requests
{
    /// <summary>
    /// Creates a request to get the approximate location of the current user-agent
    /// </summary>
    /// <remarks>
    /// While this endpoint does not require authentication, a valid Ubi-AppId header will be attached
    /// </remarks>
    public class UbisoftSelfGeolocationRequest : ApiRequest, IRequestExecutingCallback
    {
        public override string Path => $"{Endpoints.BaseEndpoint}/v2/profiles/me/iplocation";

        void IRequestExecutingCallback.OnRequestExecuting(ApiClient client)
        {
            var service = client is Dragon6Client d6Client ? d6Client.DefaultService : UbisoftService.NewStatsSite;
            this.WithHeader(UbisoftIdentifiers.UbiAppIdHeader, service.AppId());
        }
    }
}
