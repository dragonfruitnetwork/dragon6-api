// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Extensions;

namespace DragonFruit.Six.Api.Services.Developer
{
    public abstract class Dragon6DeveloperApiRequest : ApiRequest
    {
        protected override bool RequireAuth => true;

        protected override void OnRequestExecuting(ApiClient client)
        {
            if (client is Dragon6DeveloperClient devClient)
            {
                this.WithAuthHeader($"Bearer {devClient.RequestDragonFruitAccessToken().AccessToken}");
            }
        }
    }
}
