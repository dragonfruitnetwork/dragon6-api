// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class WeaponStatsRequest : BasicStatsRequest
    {
        public WeaponStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        public WeaponStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            "weapontypepvp_kills",
            "weapontypepvp_headshot",
            "weapontypepvp_bulletfired",
            "weapontypepvp_bullethit"
        };
    }
}
