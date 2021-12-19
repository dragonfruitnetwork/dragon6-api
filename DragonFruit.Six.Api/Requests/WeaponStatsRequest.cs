// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Requests
{
    public sealed class WeaponStatsRequest : BasicStatsRequest
    {
        public WeaponStatsRequest(UbisoftAccount account)
            : base(account)
        {
        }

        public WeaponStatsRequest(IEnumerable<UbisoftAccount> accounts)
            : base(accounts)
        {
        }
    }
}
