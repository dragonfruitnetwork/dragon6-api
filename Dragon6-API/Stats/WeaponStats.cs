// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class Weapon
    {
        /// <summary>
        ///     Class Name
        /// </summary>
        public string WeaponClass { get; set; }

        public byte WeaponClassID { get; set; }

        public uint Kills { get; set; }
        public uint Headshots { get; set; }

        public uint BulletsFired { get; set; }
        public uint BulletsHit { get; set; }

        public static async Task<IEnumerable<Weapon>> GetWeaponStats(AccountInfo userInfo, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    d6WebRequest.FormStatsUrl(userInfo,
                        "weapontypepvp_kills,weapontypepvp_headshot,weapontypepvp_bulletfired,weapontypepvp_bullethit"),
                    token));

            return await Task.Run(() => rawData.AlignWeapons(userInfo.Guid)).ConfigureAwait(false);
        }
    }
}