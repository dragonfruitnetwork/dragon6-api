// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class ClassicWeaponStatsDeserializer
    {
        public static IEnumerable<ClassicWeaponStats> DeserializeClassicWeaponStatsFor(this JObject jObject, string guid)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var index in Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>())
            {
                var numericIndex = (int)index;

                yield return new ClassicWeaponStats
                {
                    Guid = guid,
                    Class = index,
                    TimesChosen = json.GetUInt(ClassicWeapon.Picked.ToIndexedStatsKey(numericIndex)),

                    Kills = json.GetUInt(ClassicWeapon.Kills.ToIndexedStatsKey(numericIndex)),
                    Deaths = json.GetUInt(ClassicWeapon.Deaths.ToIndexedStatsKey(numericIndex)),

                    Headshots = json.GetUInt(ClassicWeapon.Headshots.ToIndexedStatsKey(numericIndex)),
                    Downs = json.GetUInt(ClassicWeapon.Downs.ToIndexedStatsKey(numericIndex)),
                    DownAssists = json.GetUInt(ClassicWeapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                    ShotsFired = json.GetUInt(ClassicWeapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                    ShotsLanded = json.GetUInt(ClassicWeapon.ShotsHit.ToIndexedStatsKey(numericIndex))
                };
            }
        }
    }
}
