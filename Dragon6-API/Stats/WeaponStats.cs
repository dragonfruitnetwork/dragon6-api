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

            var json = new JSONConverter(rawData["results"][userInfo.GUID]);
            var collection = new List<Weapon>();

            foreach (var index in References.WeaponClasses.Keys)
            {
                collection.Add(new Weapon
                {
                    WeaponClass = References.WeaponClasses[index],
                    WeaponClassID = index,
                    Kills = json.GetInt32(string.Format(Consts.Weapon.Kills, index)),
                    Headshots = json.GetInt32(string.Format(Consts.Weapon.Headshots, index)),
                    BulletsFired = json.GetInt32(string.Format(Consts.Weapon.ShotsFired, index)),
                    BulletsHit = json.GetInt32(string.Format(Consts.Weapon.ShotsHit, index))
                });
            }

            return collection;
        }
    }
}