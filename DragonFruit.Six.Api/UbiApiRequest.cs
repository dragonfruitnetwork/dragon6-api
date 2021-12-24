// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;

#nullable enable

namespace DragonFruit.Six.Api
{
    /// <summary>
    /// Represents a Ubisoft API request that requires authentication.
    /// Supports header injection via a <see cref="Dragon6Client"/>
    /// </summary>
    public abstract class UbiApiRequest : ApiRequest
    {
        protected override bool RequireAuth => true;

        protected override void OnRequestExecuting(ApiClient client)
        {
            // all ubisoft api requests need authentication
            // the Dragon6Client caches auth tokens and allows the headers to be injected
            (client as Dragon6Client)?.RequestAccessToken().Inject(this);
        }
    }
}
