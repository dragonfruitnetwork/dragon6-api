// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Threading.Tasks;
using DragonFruit.Data;

namespace DragonFruit.Six.Api.Services.Status
{
    public static class UbisoftServerStatusExtensions
    {
        /// <summary>
        /// Gets the current status of the Rainbow Six Servers
        /// </summary>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        /// <returns>A collection of <see cref="UbisoftServerStatus"/>, one for each platform</returns>
        public static Task<IEnumerable<UbisoftServerStatus>> GetServerStatusAsync(this ApiClient client)
        {
            return client.PerformAsync<IEnumerable<UbisoftServerStatus>>(new UbisoftServerStatusRequest());
        }
    }
}
