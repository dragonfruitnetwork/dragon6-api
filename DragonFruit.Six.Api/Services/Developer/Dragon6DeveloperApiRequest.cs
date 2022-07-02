// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Data.Extensions;
using DragonFruit.Data.Requests;

namespace DragonFruit.Six.Api.Services.Developer
{
    public abstract class Dragon6DeveloperApiRequest : ApiRequest, IAsyncRequestExecutingCallback
    {
        protected override bool RequireAuth => true;

        async ValueTask IAsyncRequestExecutingCallback.OnRequestExecutingAsync(ApiClient client)
        {
            // get access token if using a developer client
            if (client is Dragon6DeveloperClient devClient)
            {
                var token = await devClient.RequestDragonFruitAccessToken().ConfigureAwait(false);
                this.WithAuthHeader($"Bearer {token.AccessToken}");
            }
        }
    }
}
