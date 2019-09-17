using Dragon6.API.Helpers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dragon6.API.Stats
{
    public class Weapon
    {
        /// <summary>
        /// Name of weapon class in english
        /// </summary>
        public string WeaponClass { get; set; }
        public int WeaponClassID { get; set; }
        public int Kills { get; set; }
        public int Headshots { get; set; }
        public long BulletsFired { get; set; }
        public long BulletsHit { get; set; }

        public static async Task<IEnumerable<Weapon>> GetWeaponStats(AccountInfo UserInfo, string token)
        {
            var request = await Http.Preset.GetClient(token).GetAsync(Http.Preset.FormStatsURL(UserInfo, "weapontypepvp_kills,weapontypepvp_headshot,weapontypepvp_bulletfired,weapontypepvp_bullethit"));
            if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");
            }

            var JSON = new JSONConverter((JObject)JObject.Parse(await request.Content.ReadAsStringAsync())["results"][UserInfo.GUID]);
            var Collection = new List<Weapon>();
            foreach (int index in References.WeaponClasses.Keys)
            {
                Collection.Add(new Weapon
                {
                    WeaponClass = References.WeaponClasses[index],
                    WeaponClassID = index,
                    Kills = JSON.GetInt32(string.Format(Consts.Weapon.Kills, index)),
                    Headshots = JSON.GetInt32(string.Format(Consts.Weapon.Headshots, index)),
                    BulletsFired = JSON.GetInt32(string.Format(Consts.Weapon.ShotsFired, index)),
                    BulletsHit = JSON.GetInt32(string.Format(Consts.Weapon.ShotsHit, index)),
                });
            }

            return Collection;
        }
    }
}
