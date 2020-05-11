// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.Developer.Clients
{
    public class Dragon6ServiceClient : ApiClient
    {
        /// <summary>
        /// A <see cref="ApiClient"/> with a forced User-Agent Header
        /// </summary>
        public Dragon6ServiceClient(string userAgent)
        {
            UserAgent = userAgent;
        }
    }
}
