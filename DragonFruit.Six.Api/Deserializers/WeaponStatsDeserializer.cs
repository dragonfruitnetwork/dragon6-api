// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Strings.Stats;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class WeaponStatsDeserializer
    {
        public static ILookup<string, WeaponStats> DeserializeWeaponStats(this JObject json, bool training = false)
        {
            var results = (json[Misc.Results] as JObject)?.Properties();
            IEnumerable<WeaponStats> enumeratedResults;

            if (results == null)
            {
                enumeratedResults = Enumerable.Empty<WeaponStats>();
            }
            else
            {
                var weapons = Enum.GetValues(typeof(WeaponType)).Cast<WeaponType>();

                enumeratedResults = training switch
                {
                    true => results.SelectMany(x => DeserializeTrainingInternal(x, weapons)),
                    false => results.SelectMany(x => DeserializeInternal(x, weapons))
                };
            }

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static IEnumerable<WeaponStats> DeserializeInternal(JProperty data, IEnumerable<WeaponType> weapons) => weapons.Select(x =>
        {
            var numericIndex = (int)x;
            var property = (JObject)data.Value;

            return new WeaponStats
            {
                ProfileId = data.Name,

                Class = x,
                TimesChosen = property.GetUInt(Weapon.Picked.ToIndexedStatsKey(numericIndex)),

                Kills = property.GetUInt(Weapon.Kills.ToIndexedStatsKey(numericIndex)),
                Deaths = property.GetUInt(Weapon.Deaths.ToIndexedStatsKey(numericIndex)),

                Headshots = property.GetUInt(Weapon.Headshots.ToIndexedStatsKey(numericIndex)),
                Downs = property.GetUInt(Weapon.Downs.ToIndexedStatsKey(numericIndex)),
                DownAssists = property.GetUInt(Weapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                ShotsFired = property.GetUInt(Weapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                ShotsLanded = property.GetUInt(Weapon.ShotsHit.ToIndexedStatsKey(numericIndex))
            };
        });

        private static IEnumerable<WeaponStats> DeserializeTrainingInternal(JProperty data, IEnumerable<WeaponType> weapons) => weapons.Select(x =>
        {
            var numericIndex = (int)x;
            var property = (JObject)data.Value;

            return new WeaponStats
            {
                ProfileId = data.Name,

                Class = x,
                TimesChosen = property.GetUInt(WeaponTraining.Picked.ToIndexedStatsKey(numericIndex)),

                Kills = property.GetUInt(WeaponTraining.Kills.ToIndexedStatsKey(numericIndex)),
                Deaths = property.GetUInt(WeaponTraining.Deaths.ToIndexedStatsKey(numericIndex)),

                Headshots = property.GetUInt(WeaponTraining.Headshots.ToIndexedStatsKey(numericIndex)),
                Downs = property.GetUInt(WeaponTraining.Downs.ToIndexedStatsKey(numericIndex)),
                DownAssists = property.GetUInt(WeaponTraining.DownAssists.ToIndexedStatsKey(numericIndex)),

                ShotsFired = property.GetUInt(WeaponTraining.ShotsFired.ToIndexedStatsKey(numericIndex)),
                ShotsLanded = property.GetUInt(WeaponTraining.ShotsHit.ToIndexedStatsKey(numericIndex))
            };
        });
    }
}
