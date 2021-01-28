// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests.Base;
using DragonFruit.Six.Api.Strings;

namespace DragonFruit.Six.Api.Requests
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

    public sealed class WeaponTrainingStatsRequest : BasicStatsRequest
    {
        public WeaponTrainingStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        public WeaponTrainingStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            Weapon.PickedTraining,

            Weapon.KillsTraining,
            Weapon.DeathsTraining,

            Weapon.HeadshotsTraining,
            Weapon.DownsTraining,
            Weapon.DownAssistsTraining,

            Weapon.ShotsFiredTraining,
            Weapon.ShotsHitTraining
        };
    }
}
