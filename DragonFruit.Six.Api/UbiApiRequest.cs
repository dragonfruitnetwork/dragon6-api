// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Data.Requests;

#nullable enable

namespace DragonFruit.Six.Api
{
    /// <summary>
    /// Represents a Ubisoft API request that requires authentication.
    /// Supports header injection via a <see cref="Dragon6Client"/>
    /// </summary>
    public abstract class UbiApiRequest : ApiRequest, IAsyncRequestExecutingCallback
    {
        protected override bool RequireAuth => true;

        async ValueTask IAsyncRequestExecutingCallback.OnRequestExecutingAsync(ApiClient client)
        {
            // all ubisoft api requests need authentication
            // the Dragon6Client caches auth tokens and allows the headers to be injected
            if (client is Dragon6Client d6Client)
            {
                var token = await d6Client.RequestToken().ConfigureAwait(false);
                token.Inject(this);
            }
        }
    }
}
