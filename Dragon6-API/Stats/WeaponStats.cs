using System.Collections.Generic;
using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class Weapon
    {
        /// <summary>
        ///     Name of weapon class in english
        /// </summary>
        public string WeaponClass { get; set; }

        public int WeaponClassID { get; set; }
        public int Kills { get; set; }
        public int Headshots { get; set; }
        public long BulletsFired { get; set; }
        public long BulletsHit { get; set; }

        public static async Task<IEnumerable<Weapon>> GetWeaponStats(AccountInfo userInfo, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(
                    d6WebRequest.FormStatsUrl(userInfo,
                        "weapontypepvp_kills,weapontypepvp_headshot,weapontypepvp_bulletfired,weapontypepvp_bullethit"),
                    token));

            return await Task.Run(() => rawData.AlignWeapons(userInfo.GUID)).ConfigureAwait(false);
        }
    }
}