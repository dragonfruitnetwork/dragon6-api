// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;

namespace DragonFruit.Six.Api.Requests
{
    public sealed class WeaponTrainingStatsRequest : BasicStatsRequest
    {
        public WeaponTrainingStatsRequest(UbisoftAccount account)
            : base(account)
        {
        }

        public WeaponTrainingStatsRequest(IEnumerable<UbisoftAccount> accounts)
            : base(accounts)
        {
        }
    }
}
