// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Legacy.Entities;
using DragonFruit.Six.Api.Legacy.Strings;
using DragonFruit.Six.Api.Strings.Stats.Modes;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Legacy
{
    public static class LegacyStatsDeserializer
    {
        private static readonly Regex OperatorIdentifier = new(@"(\d:[0-9A-F]*)", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        /// Deserializes a <see cref="JObject"/> into a <see cref="IReadOnlyDictionary{TKey,TValue}"/> of <see cref="Entities.LegacyStats"/>
        /// </summary>
        public static IReadOnlyDictionary<string, LegacyStats> DeserializeGeneralStats(this JObject json)
        {
            var results = json.RemoveContainer<JObject>()?.Properties().Select(data =>
            {
                var property = (JObject)data.Value;

                return new LegacyStats
                {
                    ProfileId = data.Name,

                    Casual = new LegacyPlaylistStats
                    {
                        Kills = property.GetUInt(Casual.Kills.ToStatsKey()),
                        Deaths = property.GetUInt(Casual.Deaths.ToStatsKey()),

                        Wins = property.GetUInt(Casual.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Casual.Losses.ToStatsKey()),

                        MatchesPlayed = property.GetUInt(Casual.MatchesPlayed.ToStatsKey()),
                        Duration = property.GetUInt(Casual.Time.ToStatsKey())
                    },

                    Training = new LegacyPlaylistStats
                    {
                        Kills = property.GetUInt(Training.Kills.ToStatsKey()),
                        Deaths = property.GetUInt(Training.Deaths.ToStatsKey()),

                        Wins = property.GetUInt(Training.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Training.Losses.ToStatsKey()),

                        Duration = property.GetUInt(Training.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(Training.MatchesPlayed.ToStatsKey())
                    },

                    Ranked = new LegacyPlaylistStats
                    {
                        Kills = property.GetUInt(Ranked.Kills.ToStatsKey()),
                        Deaths = property.GetUInt(Ranked.Deaths.ToStatsKey()),

                        Wins = property.GetUInt(Ranked.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Ranked.Losses.ToStatsKey()),

                        Duration = property.GetUInt(Ranked.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(Ranked.MatchesPlayed.ToStatsKey()),
                    },

                    Overall = new LegacyPlaylistStats
                    {
                        Kills = property.GetUInt(General.Kills.ToStatsKey()),
                        Deaths = property.GetUInt(General.Deaths.ToStatsKey()),

                        Wins = property.GetUInt(General.Wins.ToStatsKey()),
                        Losses = property.GetUInt(General.Losses.ToStatsKey()),

                        Duration = property.GetUInt(General.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(General.MatchesPlayed.ToStatsKey())
                    },

                    Bomb = new LegacyBombModeStats
                    {
                        Wins = property.GetUInt(Bomb.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Bomb.Losses.ToStatsKey()),

                        Highscore = property.GetUInt(Bomb.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Bomb.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(Bomb.MatchesPlayed.ToStatsKey())
                    },

                    Hostage = new LegacyHostageModeStats
                    {
                        Wins = property.GetUInt(Hostage.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Hostage.Losses.ToStatsKey()),

                        Highscore = property.GetUInt(Hostage.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Hostage.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(Hostage.MatchesPlayed.ToStatsKey()),

                        Rescues = property.GetUInt(Hostage.Rescues.ToStatsKey()),
                        Defenses = property.GetUInt(Hostage.Defenses.ToStatsKey())
                    },

                    Secure = new LegacySecureModeStats
                    {
                        Wins = property.GetUInt(Secure.Wins.ToStatsKey()),
                        Losses = property.GetUInt(Secure.Losses.ToStatsKey()),

                        Highscore = property.GetUInt(Secure.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Secure.Time.ToStatsKey()),
                        MatchesPlayed = property.GetUInt(Secure.MatchesPlayed.ToStatsKey()),

                        Aggressions = property.GetUInt(Secure.Aggressions.ToStatsKey()),
                        Defenses = property.GetUInt(Secure.Defenses.ToStatsKey()),
                        Captures = property.GetUInt(Secure.Captures.ToStatsKey())
                    },

                    // non-containerised stats
                    Barricades = property.GetUInt(General.Barricades.ToStatsKey()),
                    Reinforcements = property.GetUInt(General.Reinforcements.ToStatsKey()),
                    GadgetsDestroyed = property.GetUInt(General.GadgetsDestroyed.ToStatsKey()),

                    Downs = property.GetUInt(General.Downs.ToStatsKey()),
                    Revives = property.GetUInt(General.Revives.ToStatsKey()),

                    // todo move to killtypes class?
                    Penetrations = property.GetUInt(General.Penetrations.ToStatsKey()),
                    Headshots = property.GetUInt(General.Headshots.ToStatsKey()),
                    Knifes = property.GetUInt(General.Knives.ToStatsKey()),
                    BlindKills = property.GetUInt(General.BlindKills.ToStatsKey()),

                    Assists = property.GetUInt(General.Assists.ToStatsKey()),
                    DownAssists = property.GetUInt(General.DownAssists.ToStatsKey()),
                    Suicides = property.GetUInt(General.Suicides.ToStatsKey()),

                    ShotsFired = property.GetULong(General.BulletFired.ToStatsKey()),
                    ShotsConnected = property.GetULong(General.BulletHit.ToStatsKey()),

                    Experience = property.GetULong(General.Experience.ToStatsKey()),
                };
            });

            return (results ?? Enumerable.Empty<LegacyStats>()).ToDictionary(x => x.ProfileId, x => x, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> into a <see cref="ILookup{TKey,TElement}"/> of <see cref="LegacyOperatorStats"/>
        /// </summary>
        public static ILookup<string, LegacyOperatorStats> DeserializeOperatorStats(this JObject json)
        {
            // selectmany function needs to be split due to yield statement (this applies to all ILookup-returning functions)
            return json.RemoveContainer<JObject>()?.Properties().SelectMany(DeserializeOperatorStatsInternal).ToLookup(x => x.ProfileId);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> into a <see cref="ILookup{TKey,TElement}"/> of <see cref="LegacyWeaponStats"/>
        /// </summary>
        public static ILookup<string, LegacyWeaponStats> DeserializeWeaponStats(this JObject json)
        {
            var weaponClasses = Enum.GetValues(typeof(LegacyWeaponType)).Cast<LegacyWeaponType>();
            return json.RemoveContainer<JObject>()?.Properties().SelectMany(x => DeserializeWeaponStatsInternal(x, weaponClasses)).ToLookup(x => x.ProfileId);
        }

        /// <summary>
        /// Deserializes a <see cref="JObject"/> into a <see cref="IReadOnlyDictionary{TKey,TValue}"/> of <see cref="LegacyLevelStats"/>
        /// </summary>
        public static IReadOnlyDictionary<string, LegacyLevelStats> DeserializePlayerLevelStats(this JObject json)
        {
            return json.RemoveContainer<JArray>().ToObject<IEnumerable<LegacyLevelStats>>()?.ToDictionary(x => x.ProfileId);
        }

        private static IEnumerable<LegacyOperatorStats> DeserializeOperatorStatsInternal(JProperty data)
        {
            var property = (JObject)data.Value;

            // use the pattern regex above to determine what operators the user has
            var operatorIndices = property.Properties().Select(x => OperatorIdentifier.Match(x.Name).Groups[1].Value).Distinct();

            foreach (var index in operatorIndices)
            {
                yield return new LegacyOperatorStats
                {
                    OperatorId = index,
                    ProfileId = data.Name,

                    Kills = property.GetUInt(Operator.Kills.ToIndexedStatsKey(index)),
                    Deaths = property.GetUInt(Operator.Deaths.ToIndexedStatsKey(index)),

                    Wins = property.GetUInt(Operator.Wins.ToIndexedStatsKey(index)),
                    Losses = property.GetUInt(Operator.Losses.ToIndexedStatsKey(index)),

                    RoundsPlayed = property.GetUInt(Operator.Rounds.ToIndexedStatsKey(index)),
                    Duration = property.GetUInt(Operator.Time.ToIndexedStatsKey(index)),

                    Headshots = property.GetUInt(Operator.Headshots.ToIndexedStatsKey(index)),
                    Downs = property.GetUInt(Operator.Downs.ToIndexedStatsKey(index)),
                    Experience = property.GetUInt(Operator.Experience.ToIndexedStatsKey(index))
                };
            }
        }

        private static IEnumerable<LegacyWeaponStats> DeserializeWeaponStatsInternal(JProperty data, IEnumerable<LegacyWeaponType> weaponClasses)
        {
            var property = (JObject)data.Value;

            foreach (var weaponClass in weaponClasses)
            {
                var numericIndex = (int)weaponClass;
                yield return new LegacyWeaponStats
                {
                    ProfileId = data.Name,

                    Class = weaponClass,
                    TimesChosen = property.GetUInt(Weapon.Picked.ToIndexedStatsKey(numericIndex)),

                    Kills = property.GetUInt(Weapon.Kills.ToIndexedStatsKey(numericIndex)),
                    Deaths = property.GetUInt(Weapon.Deaths.ToIndexedStatsKey(numericIndex)),

                    Headshots = property.GetUInt(Weapon.Headshots.ToIndexedStatsKey(numericIndex)),
                    Downs = property.GetUInt(Weapon.Downs.ToIndexedStatsKey(numericIndex)),
                    DownAssists = property.GetUInt(Weapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                    ShotsFired = property.GetUInt(Weapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                    ShotsLanded = property.GetUInt(Weapon.ShotsHit.ToIndexedStatsKey(numericIndex))
                };
            }
        }
    }
}
