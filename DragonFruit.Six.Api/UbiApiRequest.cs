// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Data.Requests;
using DragonFruit.Six.Api.Enums;

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

        /// <summary>
        /// Optional override to request a specific token source
        /// </summary>
        protected virtual UbisoftService? RequiredTokenSource => null;

        async ValueTask IAsyncRequestExecutingCallback.OnRequestExecutingAsync(ApiClient client)
        {
            // all ubisoft api requests need authentication
            // the Dragon6Client caches auth tokens and allows the headers to be injected
            if (client is Dragon6Client d6Client)
            {
                var injector = await d6Client.GetServiceAccessToken(RequiredTokenSource ?? d6Client.DefaultService).GetInjector().ConfigureAwait(false);
                injector.Inject(this);
            }
        }
    }
}
