// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Six.API.Data.Requests;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class ServerStatusExtensions
    {
        /// <summary>
        /// Get the current server status, as reported by Ubisoft's site (https://rainbow6.ubisoft.com/status/)
        /// </summary>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        public static IEnumerable<ServerStatusReport> GetServerStatus(this ApiClient client)
        {
            var request = new ServerStatusRequest();
            return client.Perform<IEnumerable<ServerStatusReport>>(request);
        }
    }
}
