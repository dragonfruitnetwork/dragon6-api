// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Requests
{
    public sealed class StatsRequest : BasicStatsRequest
    {
        /// <summary>
        /// Initialises a request for all the stats in <see cref="Stats"/> for the provided <see cref="UbisoftAccount"/>
        /// </summary>
        public StatsRequest(UbisoftAccount account)
            : base(account)
        {
        }

        /// <summary>
        /// Requests all the stats in <see cref="Stats"/> for the provided array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public StatsRequest(IEnumerable<UbisoftAccount> accounts)
            : base(accounts)
        {
        }
    }
}
