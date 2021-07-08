// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Requests
{
    public sealed class StatsRequest : BasicStatsRequest
    {
        /// <summary>
        /// Initialises a request for all the stats in <see cref="Stats"/> for the provided <see cref="AccountInfo"/>
        /// </summary>
        public StatsRequest(AccountInfo account)
            : base(account)
        {
        }

        /// <summary>
        /// Requests all the stats in <see cref="Stats"/> for the provided array of <see cref="AccountInfo"/>s
        /// </summary>
        public StatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }
    }
}
