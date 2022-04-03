// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

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
                        Kills = property.GetInt(Casual.Kills.ToStatsKey()),
                        Deaths = property.GetInt(Casual.Deaths.ToStatsKey()),

                        Wins = property.GetInt(Casual.Wins.ToStatsKey()),
                        Losses = property.GetInt(Casual.Losses.ToStatsKey()),

                        MatchesPlayed = property.GetInt(Casual.MatchesPlayed.ToStatsKey()),
                        Duration = property.GetInt(Casual.Time.ToStatsKey())
                    },

                    Training = new LegacyPlaylistStats
                    {
                        Kills = property.GetInt(Training.Kills.ToStatsKey()),
                        Deaths = property.GetInt(Training.Deaths.ToStatsKey()),

                        Wins = property.GetInt(Training.Wins.ToStatsKey()),
                        Losses = property.GetInt(Training.Losses.ToStatsKey()),

                        Duration = property.GetInt(Training.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(Training.MatchesPlayed.ToStatsKey())
                    },

                    Ranked = new LegacyPlaylistStats
                    {
                        Kills = property.GetInt(Ranked.Kills.ToStatsKey()),
                        Deaths = property.GetInt(Ranked.Deaths.ToStatsKey()),

                        Wins = property.GetInt(Ranked.Wins.ToStatsKey()),
                        Losses = property.GetInt(Ranked.Losses.ToStatsKey()),

                        Duration = property.GetInt(Ranked.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(Ranked.MatchesPlayed.ToStatsKey()),
                    },

                    Overall = new LegacyPlaylistStats
                    {
                        Kills = property.GetInt(General.Kills.ToStatsKey()),
                        Deaths = property.GetInt(General.Deaths.ToStatsKey()),

                        Wins = property.GetInt(General.Wins.ToStatsKey()),
                        Losses = property.GetInt(General.Losses.ToStatsKey()),

                        Duration = property.GetInt(General.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(General.MatchesPlayed.ToStatsKey())
                    },

                    Bomb = new LegacyBombModeStats
                    {
                        Wins = property.GetInt(Bomb.Wins.ToStatsKey()),
                        Losses = property.GetInt(Bomb.Losses.ToStatsKey()),

                        Highscore = property.GetInt(Bomb.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Bomb.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(Bomb.MatchesPlayed.ToStatsKey())
                    },

                    Hostage = new LegacyHostageModeStats
                    {
                        Wins = property.GetInt(Hostage.Wins.ToStatsKey()),
                        Losses = property.GetInt(Hostage.Losses.ToStatsKey()),

                        Highscore = property.GetInt(Hostage.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Hostage.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(Hostage.MatchesPlayed.ToStatsKey()),

                        Rescues = property.GetInt(Hostage.Rescues.ToStatsKey()),
                        Defenses = property.GetInt(Hostage.Defenses.ToStatsKey())
                    },

                    Secure = new LegacySecureModeStats
                    {
                        Wins = property.GetInt(Secure.Wins.ToStatsKey()),
                        Losses = property.GetInt(Secure.Losses.ToStatsKey()),

                        Highscore = property.GetInt(Secure.Highscore.ToStatsKey()),

                        Duration = property.GetUInt(Secure.Time.ToStatsKey()),
                        MatchesPlayed = property.GetInt(Secure.MatchesPlayed.ToStatsKey()),

                        Aggressions = property.GetInt(Secure.Aggressions.ToStatsKey()),
                        Defenses = property.GetInt(Secure.Defenses.ToStatsKey()),
                        Captures = property.GetInt(Secure.Captures.ToStatsKey())
                    },

                    // non-containerised stats
                    Barricades = property.GetInt(General.Barricades.ToStatsKey()),
                    Reinforcements = property.GetInt(General.Reinforcements.ToStatsKey()),
                    GadgetsDestroyed = property.GetInt(General.GadgetsDestroyed.ToStatsKey()),

                    Downs = property.GetInt(General.Downs.ToStatsKey()),
                    Revives = property.GetInt(General.Revives.ToStatsKey()),

                    // todo move to killtypes class?
                    Penetrations = property.GetInt(General.Penetrations.ToStatsKey()),
                    Headshots = property.GetInt(General.Headshots.ToStatsKey()),
                    Knifes = property.GetInt(General.Knives.ToStatsKey()),
                    BlindKills = property.GetInt(General.BlindKills.ToStatsKey()),

                    Assists = property.GetInt(General.Assists.ToStatsKey()),
                    DownAssists = property.GetInt(General.DownAssists.ToStatsKey()),
                    Suicides = property.GetInt(General.Suicides.ToStatsKey()),

                    ShotsFired = property.GetLong(General.BulletFired.ToStatsKey()),
                    ShotsConnected = property.GetLong(General.BulletHit.ToStatsKey()),

                    Experience = property.GetLong(General.Experience.ToStatsKey()),
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

                    Kills = property.GetInt(Operator.Kills.ToIndexedStatsKey(index)),
                    Deaths = property.GetInt(Operator.Deaths.ToIndexedStatsKey(index)),

                    Wins = property.GetInt(Operator.Wins.ToIndexedStatsKey(index)),
                    Losses = property.GetInt(Operator.Losses.ToIndexedStatsKey(index)),

                    RoundsPlayed = property.GetInt(Operator.Rounds.ToIndexedStatsKey(index)),
                    Duration = property.GetInt(Operator.Time.ToIndexedStatsKey(index)),

                    Headshots = property.GetInt(Operator.Headshots.ToIndexedStatsKey(index)),
                    Downs = property.GetInt(Operator.Downs.ToIndexedStatsKey(index)),
                    Experience = property.GetInt(Operator.Experience.ToIndexedStatsKey(index))
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
                    TimesChosen = property.GetInt(Weapon.Picked.ToIndexedStatsKey(numericIndex)),

                    Kills = property.GetInt(Weapon.Kills.ToIndexedStatsKey(numericIndex)),
                    Deaths = property.GetInt(Weapon.Deaths.ToIndexedStatsKey(numericIndex)),

                    Headshots = property.GetInt(Weapon.Headshots.ToIndexedStatsKey(numericIndex)),
                    Downs = property.GetInt(Weapon.Downs.ToIndexedStatsKey(numericIndex)),
                    DownAssists = property.GetInt(Weapon.DownAssists.ToIndexedStatsKey(numericIndex)),

                    ShotsFired = property.GetInt(Weapon.ShotsFired.ToIndexedStatsKey(numericIndex)),
                    ShotsLanded = property.GetInt(Weapon.ShotsHit.ToIndexedStatsKey(numericIndex))
                };
            }
        }
    }
}
