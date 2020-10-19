// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class WeaponStatsDeserializer
    {
        public static IEnumerable<WeaponStats> DeserializeWeaponStatsFor(this JObject jObject, string guid)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var index in References.WeaponClasses.Keys)
            {
                yield return new WeaponStats
                {
                    Guid = guid,

                    ClassName = References.WeaponClasses[index],
                    ClassID = index,
                    Kills = json.GetUInt(Weapon.Kills.ToIndexedStatsKey(index)),
                    Headshots = json.GetUInt(Weapon.Headshots.ToIndexedStatsKey(index)),
                    ShotsFired = json.GetUInt(Weapon.ShotsFired.ToIndexedStatsKey(index)),
                    ShotsLanded = json.GetUInt(Weapon.ShotsHit.ToIndexedStatsKey(index))
                };
            }
        }
    }
}
