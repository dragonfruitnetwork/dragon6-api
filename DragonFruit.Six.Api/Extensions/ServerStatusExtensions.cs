// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Threading;
using DragonFruit.Common.Data;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests;

namespace DragonFruit.Six.Api.Extensions
{
    public static class ServerStatusExtensions
    {
        /// <summary>
        /// Get the current server status, as reported by Ubisoft's site (https://rainbow6.ubisoft.com/status/)
        /// </summary>
        public static IEnumerable<ServerStatusReport> GetServerStatus(this ApiClient client, CancellationToken token = default)
        {
            var request = new ServerStatusRequest();
            return client.Perform<IEnumerable<ServerStatusReport>>(request, token);
        }
    }
}
