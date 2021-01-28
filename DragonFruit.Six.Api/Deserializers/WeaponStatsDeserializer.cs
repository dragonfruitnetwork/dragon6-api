// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class WeaponStatsDeserializer
    {
        public static IEnumerable<WeaponStats> DeserializeWeaponStatsFor(this JObject jObject, string guid)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var index in Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>())
            {
                var numericIndex = (int)index;

                yield return new WeaponStats
                {
                    Guid = guid,
                    Class = index,
                    TimesChosen = json.GetUInt(Weapon.Picked.ToIndexedStatsKey(numericIndex)),

                    Kills = json.GetUInt(Weapon.Kills.ToIndexedStatsKey(numericIndex)),
                    Deaths = json.GetUInt(Weapon.Deaths.ToIndexedStatsKey(numericIndex)),

                    Headshots = json.GetUInt(Weapon.Headshots.ToIndexedStatsKey(numericIndex)),
                    Downs = json.GetUInt(Weapon.Downs.ToIndexedStatsKey(numericIndex)),
                    DownAssists = json.GetUInt(Weapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                    ShotsFired = json.GetUInt(Weapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                    ShotsLanded = json.GetUInt(Weapon.ShotsHit.ToIndexedStatsKey(numericIndex))
                };
            }
        }
    }
}
