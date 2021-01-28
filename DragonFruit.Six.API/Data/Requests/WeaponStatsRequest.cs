// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Data.Requests.Base;
using DragonFruit.Six.Api.Data.Strings;

namespace DragonFruit.Six.Api.Data.Requests
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
            Weapon.Picked,

            Weapon.Kills,
            Weapon.Deaths,

            Weapon.Headshots,
            Weapon.Downs,
            Weapon.DownAssists,

            Weapon.ShotsFired,
            Weapon.ShotsHit
        };
    }
}
