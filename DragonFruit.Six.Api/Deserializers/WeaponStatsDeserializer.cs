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
        public static ILookup<string, WeaponStats> DeserializeWeaponStats(this JObject jObject)
        {
            var results = jObject[Misc.Results]?.ToObject<Dictionary<string, JObject>>();
            IEnumerable<WeaponStats> enumeratedResults;

            if (results == null || results.Count == 0)
            {
                enumeratedResults = Enumerable.Empty<WeaponStats>();
            }
            else
            {
                var weapons = Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>();
                enumeratedResults = results.SelectMany(x => DeserializeInternal(x, weapons));
            }

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static IEnumerable<WeaponStats> DeserializeInternal(KeyValuePair<string, JObject> data, IEnumerable<WeaponType> weapons) => weapons.Select(x =>
        {
            var numericIndex = (int)x;

            return new WeaponStats
            {
                ProfileId = data.Key,

                Class = x,
                TimesChosen = data.Value.GetUInt(Weapon.Picked.ToIndexedStatsKey(numericIndex)),

                Kills = data.Value.GetUInt(Weapon.Kills.ToIndexedStatsKey(numericIndex)),
                Deaths = data.Value.GetUInt(Weapon.Deaths.ToIndexedStatsKey(numericIndex)),

                Headshots = data.Value.GetUInt(Weapon.Headshots.ToIndexedStatsKey(numericIndex)),
                Downs = data.Value.GetUInt(Weapon.Downs.ToIndexedStatsKey(numericIndex)),
                DownAssists = data.Value.GetUInt(Weapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                ShotsFired = data.Value.GetUInt(Weapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                ShotsLanded = data.Value.GetUInt(Weapon.ShotsHit.ToIndexedStatsKey(numericIndex))
            };
        });
    }
}
