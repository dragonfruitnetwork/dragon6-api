using System.Collections.Generic;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests.Base;
using DragonFruit.Six.Api.Strings;

namespace DragonFruit.Six.Api.Requests
{
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
