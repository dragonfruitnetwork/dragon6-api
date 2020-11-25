// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class ClassicWeaponStatsRequest : ClassicStatsRequestBase
    {
        public ClassicWeaponStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        public ClassicWeaponStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            ClassicWeapon.Picked,

            ClassicWeapon.Kills,
            ClassicWeapon.Deaths,

            ClassicWeapon.Headshots,
            ClassicWeapon.Downs,
            ClassicWeapon.DownAssists,

            ClassicWeapon.ShotsFired,
            ClassicWeapon.ShotsHit
        };
    }
}
