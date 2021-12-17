// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;

namespace DragonFruit.Six.Api.Requests
{
    public abstract class DeveloperApiRequest : ApiRequest
    {
        protected const string BaseEndpoint = "https://dragon6.dragonfruit.network/api/v2";

        protected override bool RequireAuth => true;

        protected override void OnRequestExecuting(ApiClient client)
        {
            (client as Dragon6DeveloperClient)?.ValidateAccess(this);
        }
    }
}
