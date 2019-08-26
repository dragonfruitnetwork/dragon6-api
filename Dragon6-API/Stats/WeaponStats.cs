using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
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
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var PlayerObj = (JObject)JObject.Parse(await request.Content.ReadAsStringAsync())["results"][UserInfo.GUID];

            //form strings to get data
            var Collection = new List<Weapon>();
            foreach (int index in References.WeaponClasses.Keys)
            {
                var KillsIdentifier = $"weapontypepvp_kills:{index}:infinite";
                var HeadshotsIdentifier = $"weapontypepvp_headshot:{index}:infinite";
                var BulletFiredIdentifier = $"weapontypepvp_bulletfired:{index}:infinite";
                var BulletHitIdentifier = $"weapontypepvp_bullethit:{index}:infinite";

                var stats = new Weapon
                {
                    WeaponClass = (string)References.WeaponClasses[index],
                    WeaponClassID = index,
                    Kills = int.Parse((string)PlayerObj[KillsIdentifier] ?? "0"),
                    Headshots = int.Parse((string)PlayerObj[HeadshotsIdentifier] ?? "0"),
                    BulletsFired = long.Parse((string)PlayerObj[BulletFiredIdentifier] ?? "0"),
                    BulletsHit = long.Parse((string)PlayerObj[BulletHitIdentifier] ?? "0"),

                };

                Collection.Add(stats);
            }

            return Collection;

        }
    }
}
