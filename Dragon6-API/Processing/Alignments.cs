// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using Dragon6.API.Helpers;
using Dragon6.API.Processing;
using Dragon6.API.Stats;
using DragonFruit.Common.Storage.Shared;
using Newtonsoft.Json.Linq;
using General = Dragon6.API.Stats.General;
using Operator = Dragon6.API.Stats.Operator;
using Weapon = Dragon6.API.Stats.Weapon;

namespace Dragon6.API
{
    /// <summary>
    ///     Ubisoft gibberish -> Usable data
    /// </summary>
    public static class Alignments
    {
        /// <summary>
        ///     Get Account Information
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static AccountInfo AlignAccount(this JObject jObject)
        {
            var json = (JObject)jObject["profiles"][0];

            return new AccountInfo
            {
                PlayerName = json.GetString("nameOnPlatform"),
                Guid = json.GetString("profileId"),
                Platform = PlatformParser.GetUbiPlatform(json.GetString("platformType"))
            };
        }

        /// <summary>
        ///     Get General Stats
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static General AlignGeneralStats(this JObject jObject, string GUID)
        {
            if (jObject == null) return new General();

            var json = (JObject)jObject["results"][GUID];

            return new General
            {
                // Casual
                Casual_Kills = json.GetUInt(Casual.Kills),
                Casual_Deaths = json.GetUInt(Casual.Deaths),
                Casual_KD = json.GetFloat(Casual.Kills, 1) / json.GetFloat(Casual.Deaths, 1),

                Casual_Wins = json.GetUInt(Casual.Wins),
                Casual_Losses = json.GetUInt(Casual.Losses),
                Casual_WL = json.GetFloat(Casual.Wins, 1) / json.GetFloat(Casual.Losses, 1),

                Casual_MatchesPlayed = json.GetUInt(Casual.Time),

                // General
                Barricades = json.GetUInt(Processing.General.Barricades),
                Reinforcements = json.GetUInt(Processing.General.Reinforcements),

                Downs = json.GetUInt(Processing.General.Downs),
                Revives = json.GetUInt(Processing.General.Revives),

                Penetrations = json.GetUInt(Processing.General.Penetrations),
                Headshots = json.GetUInt(Processing.General.Headshots),
                Knifes = json.GetUInt(Processing.General.Knives),

                Assists = json.GetUInt(Processing.General.Assists),
                Suicides = json.GetUInt(Processing.General.Suicides),

                ShotsFired = json.GetLong(Processing.General.BulletFired),
                ShotsConnected = json.GetLong(Processing.General.BulletHit),

                // Terrorist Hunt
                THunt_Kills = json.GetUInt(PvE.Kills),
                THunt_Deaths = json.GetUInt(PvE.Deaths),
                THunt_KD = json.GetFloat(PvE.Kills, 1) / json.GetFloat(PvE.Deaths, 1),

                THunt_Wins = json.GetUInt(PvE.Wins),
                THunt_Losses = json.GetUInt(PvE.Losses),
                THunt_WL = json.GetFloat(PvE.Wins, 1) / json.GetFloat(PvE.Losses, 1),

                // Gamemodes
                HIScore_Secure = json.GetUInt(ModeScores.Secure),
                HIScore_Bomb = json.GetUInt(ModeScores.Bomb),
                HIScore_Hostage = json.GetUInt(ModeScores.Hostage),

                // Time Played
                TimePlayed_Casual = TimeSpan.FromSeconds(json.GetDouble(Casual.Time)),
                TimePlayed_THunt = TimeSpan.FromSeconds(json.GetDouble(PvE.Time)),
                TimePlayed_Ranked = TimeSpan.FromSeconds(json.GetDouble(Ranked.Time)),
                TimePlayed_General = TimeSpan.FromSeconds(json.GetDouble(Overall.Time)),
                TimePlayed_Custom = TimeSpan.FromSeconds(json.GetDouble(CustomGame.Time)),

                // Ranked
                Ranked_Wins = json.GetUInt(Ranked.Wins),
                Ranked_Losses = json.GetUInt(Ranked.Losses),
                Ranked_WL = json.GetFloat(Ranked.Wins, 1) / json.GetFloat(Ranked.Losses, 1),
                Ranked_MatchesPlayed = json.GetUInt(Ranked.MatchesPlayed),

                Ranked_Kills = json.GetUInt(Ranked.Kills),
                Ranked_Deaths = json.GetUInt(Ranked.Deaths),
                Ranked_KD = json.GetFloat(Ranked.Kills, 1) / json.GetFloat(Ranked.Deaths, 1),

                // General (Overall Stats)
                Wins = json.GetUInt(Overall.Wins),
                Losses = json.GetUInt(Overall.Losses),
                Kills = json.GetUInt(Overall.Kills),
                Deaths = json.GetUInt(Overall.Deaths),
                WL = json.GetFloat(Overall.WL)
            };
        }

        /// <summary>
        ///     Get Season-Specific Ranked Stats
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Season AlignSeason(this JObject jObject, string GUID)
        {
            var json = (JObject) jObject["players"][GUID];

            return new Season
            {
                SeasonId = json.GetByte(RankedSeason.Season),
                Rank = json.GetUInt(RankedSeason.Rank),
                Max_Rank = json.GetUInt(RankedSeason.MaxRank),
                Wins = json.GetUInt(RankedSeason.Wins),
                Losses = json.GetUInt(RankedSeason.Losses),
                Abandons = json.GetUInt(RankedSeason.Abandons),
                MMR = json.GetUInt(RankedSeason.MMR)
            };
        }

        /// <summary>
        ///     Get the User's Level
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static uint AlignLevel(this JObject json) =>
            ((uint?) json["player_profiles"][0][Processing.General.Level]).GetValueOrDefault(0);

        /// <summary>
        ///     Get list of operators and stats
        /// </summary>
        /// <param name="json"></param>
        /// <param name="guid"></param>
        /// <param name="operatorNameIndex"></param>
        /// <param name="UseMap"></param>
        /// <param name="operatorIconMap"></param>
        /// <returns></returns>
        public static IEnumerable<Operator> AlignOperators(this JObject jObject, string guid,
            Dictionary<string, string> operatorNameIndex, Dictionary<string, string> operatorIconMap = null)
        {
            var json = (JObject)jObject["results"][guid];

            foreach (var index in operatorNameIndex.Keys.ToArray())
            {
                var stats = new Operator
                {
                    Name = operatorNameIndex[index],
                    Index = index,
                    Kills = json.GetUInt(string.Format(Processing.Operator.Kills, index)),
                    Deaths = json.GetUInt(string.Format(Processing.Operator.Deaths, index)),
                    Wins = json.GetUInt(string.Format(Processing.Operator.Wins, index)),
                    Losses = json.GetUInt(string.Format(Processing.Operator.Losses, index)),
                    Headshots = json.GetUInt(string.Format(Processing.Operator.Headshots, index)),
                    Downs = json.GetUInt(string.Format(Processing.Operator.Downs, index)),
                    RoundsPlayed = json.GetUInt(string.Format(Processing.Operator.Rounds, index)),
                    KD = json.GetFloat(string.Format(Processing.Operator.Kills, index), 1) /
                         json.GetFloat(string.Format(Processing.Operator.Deaths, index), 1),
                    WL = json.GetFloat(string.Format(Processing.Operator.Wins, index), 1) /
                         json.GetFloat(string.Format(Processing.Operator.Losses, index), 1)
                };

                //if a dictionary in the form ID -> op icon url is specified, set the link
                if (operatorIconMap != null)
                    try
                    {
                        stats.ImageURL = operatorIconMap[index];
                    }
                    catch
                    {
                        //cannot find the operator icon index - it's not the end of the world, just continue
                    }

                yield return stats;
            }
        }

        /// <summary>
        ///     gets list of weapons and accompanying stats
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static IEnumerable<Weapon> AlignWeapons(this JObject jObject, string guid)
        {
            var json = (JObject)jObject["results"][guid];

            foreach (var index in References.WeaponClasses.Keys)
                yield return new Weapon
                {
                    WeaponClass = References.WeaponClasses[index],
                    WeaponClassID = index,
                    Kills = json.GetUInt(string.Format(Processing.Weapon.Kills, index)),
                    Headshots = json.GetUInt(string.Format(Processing.Weapon.Headshots, index)),
                    BulletsFired = json.GetUInt(string.Format(Processing.Weapon.ShotsFired, index)),
                    BulletsHit = json.GetUInt(string.Format(Processing.Weapon.ShotsHit, index))
                };
        }
    }
}