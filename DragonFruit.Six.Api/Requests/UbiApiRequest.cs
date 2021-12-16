// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;

#nullable enable

namespace DragonFruit.Six.Api.Requests
{
    public abstract class UbiApiRequest : ApiRequest
    {
        protected override void OnRequestExecuting(ApiClient client)
        {
            // all UbiApiRequests require an auth header
            (client as Dragon6Client)?.ValidateToken();
        }
    }
}
