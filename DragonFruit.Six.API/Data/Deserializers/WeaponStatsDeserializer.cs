// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Strings;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class WeaponStatsDeserializer
    {
        public static IEnumerable<WeaponStats> DeserializeWeaponStatsFor(this JObject jObject, string guid)
        {
            var json = (JObject)jObject[Misc.Results][guid];

            foreach (var index in References.WeaponClasses.Keys)
            {
                yield return new WeaponStats
                {
                    Guid = guid,

                    ClassName = References.WeaponClasses[index],
                    ClassID = index,
                    Kills = json.GetUInt(string.Format(Weapon.Kills, index)),
                    Headshots = json.GetUInt(string.Format(Weapon.Headshots, index)),
                    ShotsFired = json.GetUInt(string.Format(Weapon.ShotsFired, index)),
                    ShotsLanded = json.GetUInt(string.Format(Weapon.ShotsHit, index))
                };
            }
        }
    }
}
