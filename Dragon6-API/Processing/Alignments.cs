using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dragon6.API.Helpers;
using Dragon6.API.Processing;
using Dragon6.API.Stats;
using Newtonsoft.Json.Linq;
using General = Dragon6.API.Stats.General;
using Operator = Dragon6.API.Stats.Operator;
using Weapon = Dragon6.API.Stats.Weapon;

namespace Dragon6.API
{
    /// <summary>
    ///     Takes Ubisoft JSON and pareses it into a Dragon6 Class
    /// </summary>
    public static class Alignments
    {
        /// <summary>
        ///     Aligns into an AccountInfo Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static AccountInfo AlignAccount(this JObject jObject)
        {
            var json = JObject.FromObject(jObject["profiles"][0]);

            return new AccountInfo
            {
                PlayerName = json["nameOnPlatform"].ToString(),
                GUID = json["profileId"].ToString(),
                Platform = (string) json["platformType"] == "uplay" ? References.Platforms.PC :
                    (string) json["platformType"] == "psn" ? References.Platforms.PSN : References.Platforms.XB1
            };
        }

        /// <summary>
        ///     Aligns into an PlayerStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static General AlignGeneralStats(this JObject jObject, string GUID)
        {
            if (jObject == null) return new General();

            var json = new JSONConverter(jObject["results"][GUID]);
            return new General
            {
                // Casual
                Casual_Kills = json.GetInt32(Casual.Kills),
                Casual_Deaths = json.GetInt32(Casual.Deaths),
                Casual_KD = json.GetFloat(Casual.Kills, 1) / json.GetFloat(Casual.Deaths, 1),

                Casual_Wins = json.GetInt32(Casual.Wins),
                Casual_Losses = json.GetInt32(Casual.Losses),
                Casual_WL = json.GetFloat(Casual.Wins, 1) / json.GetFloat(Casual.Losses, 1),

                Casual_MatchesPlayed = json.GetInt32(Casual.Time),

                // General
                Barricades = json.GetInt32(Processing.General.Barricades),
                Reinforcements = json.GetInt32(Processing.General.Reinforcements),

                Downs = json.GetInt32(Processing.General.Downs),
                Revives = json.GetInt32(Processing.General.Revives),

                Penetrations = json.GetInt32(Processing.General.Penetrations),
                Headshots = json.GetInt32(Processing.General.Headshots),
                Knifes = json.GetInt32(Processing.General.Knives),

                Assists = json.GetInt32(Processing.General.Assists),
                Suicides = json.GetInt32(Processing.General.Suicides),

                ShotsFired = json.GetInt64(Processing.General.BulletFired),
                ShotsConnected = json.GetInt64(Processing.General.BulletHit),

                // Terrorist Hunt
                THunt_Kills = json.GetInt32(PvE.Kills),
                THunt_Deaths = json.GetInt32(PvE.Deaths),
                THunt_KD = json.GetFloat(PvE.Kills, 1) / json.GetFloat(PvE.Deaths, 1),

                THunt_Wins = json.GetInt32(PvE.Wins),
                THunt_Losses = json.GetInt32(PvE.Losses),
                THunt_WL = json.GetFloat(PvE.Wins, 1) / json.GetFloat(PvE.Losses, 1),

                // Gamemodes
                HIScore_Secure = json.GetInt32(ModeScores.Secure),
                HIScore_Bomb = json.GetInt32(ModeScores.Bomb),
                HIScore_Hostage = json.GetInt32(ModeScores.Hostage),

                // Time Played
                TimePlayed_Casual = TimeSpan.FromSeconds(json.GetDouble(Casual.Time)),
                TimePlayed_THunt = TimeSpan.FromSeconds(json.GetDouble(PvE.Time)),
                TimePlayed_Ranked = TimeSpan.FromSeconds(json.GetDouble(Ranked.Time)),
                TimePlayed_General = TimeSpan.FromSeconds(json.GetDouble(Overall.Time)),
                TimePlayed_Custom = TimeSpan.FromSeconds(json.GetDouble(CustomGame.Time)),

                // Ranked
                Ranked_Wins = json.GetInt32(Ranked.Wins),
                Ranked_Losses = json.GetInt32(Ranked.Losses),
                Ranked_WL = json.GetFloat(Ranked.Wins, 1) / json.GetFloat(Ranked.Losses, 1),
                Ranked_MatchesPlayed = json.GetInt32(Ranked.MatchesPlayed),

                Ranked_Kills = json.GetInt32(Ranked.Kills),
                Ranked_Deaths = json.GetInt32(Ranked.Deaths),
                Ranked_KD = json.GetFloat(Ranked.Kills, 1) / json.GetFloat(Ranked.Deaths, 1),

                // General (Overall Stats)
                Wins = json.GetInt32(Overall.Wins),
                Losses = json.GetInt32(Overall.Losses),
                Kills = json.GetInt32(Overall.Kills),
                Deaths = json.GetInt32(Overall.Deaths),
                WL = json.GetFloat(Overall.WL)
            };
        }

        /// <summary>
        ///     Aligns into an SeasonalStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Season AlignSeason(this JObject jObject, string GUID)
        {
            var json = new JSONConverter(jObject["players"][GUID]);

            return new Season
            {
                SeasonID = json.GetInt32(RankedSeason.Season),
                Rank = json.GetInt32(RankedSeason.Rank),
                Max_Rank = json.GetInt32(RankedSeason.MaxRank),
                Wins = json.GetInt32(RankedSeason.Wins),
                Losses = json.GetInt32(RankedSeason.Losses),
                Abandons = json.GetInt32(RankedSeason.Abandons),
                MMR = json.GetInt32(RankedSeason.MMR)
            };
        }

        /// <summary>
        ///     Gets the User's Level as an int32
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<int> AlignLevel(this JObject json)
        {
            return (int) await Task.Run(() => json["player_profiles"][0][Processing.General.Level]);
        }

        /// <summary>
        ///     gets list of operators with their stats - if you don't have a icon map send an empty dictionary instead
        /// </summary>
        /// <param name="json"></param>
        /// <param name="guid"></param>
        /// <param name="operatorNameIndex"></param>
        /// <param name="UseMap"></param>
        /// <param name="operatorIconMap"></param>
        /// <returns></returns>
        public static List<Operator> AlignOperators(this JObject jObject, string guid,
            Dictionary<string, string> operatorNameIndex, Dictionary<string, string> operatorIconMap)
        {
            var json = new JSONConverter(jObject["results"][guid]);

            //get map of operator ids to names

            var collection = new List<Operator>();
            foreach (var index in operatorNameIndex.Keys.ToArray())
            {
                var stats = new Operator
                {
                    Name = operatorNameIndex[index],
                    Index = index,
                    Kills = json.GetInt32(string.Format(Processing.Operator.Kills, index)),
                    Deaths = json.GetInt32(string.Format(Processing.Operator.Deaths, index)),
                    Wins = json.GetInt32(string.Format(Processing.Operator.Wins, index)),
                    Losses = json.GetInt32(string.Format(Processing.Operator.Losses, index)),
                    Headshots = json.GetInt32(string.Format(Processing.Operator.Headshots, index)),
                    Downs = json.GetInt32(string.Format(Processing.Operator.Downs, index)),
                    RoundsPlayed = json.GetInt32(string.Format(Processing.Operator.Rounds, index)),
                    KD = json.GetFloat(string.Format(Processing.Operator.Kills, index), 1) /
                         json.GetFloat(string.Format(Processing.Operator.Deaths, index), 1),
                    WL = json.GetFloat(string.Format(Processing.Operator.Wins, index), 1) /
                         json.GetFloat(string.Format(Processing.Operator.Losses, index), 1)
                };

                //if a dictionary in the form ID -> op icon url is specified, set the link
                if (operatorIconMap.Any())
                    try
                    {
                        stats.ImageURL = operatorIconMap[index];
                    }
                    catch
                    {
                        //cannot find the operator icon index - it's not the end of the world, just continue
                    }


                collection.Add(stats);
            }

            return collection;
        }

        /// <summary>
        ///     gets list of weapons and accompanying stats
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static List<Weapon> AlignWeapons(this JObject jObject, string guid)
        {
            var json = new JSONConverter(jObject["results"][guid]);
            var collection = new List<Weapon>();

            foreach (var index in References.WeaponClasses.Keys)
                collection.Add(new Weapon
                {
                    WeaponClass = References.WeaponClasses[index],
                    WeaponClassID = index,
                    Kills = json.GetInt32(string.Format(Processing.Weapon.Kills, index)),
                    Headshots = json.GetInt32(string.Format(Processing.Weapon.Headshots, index)),
                    BulletsFired = json.GetInt32(string.Format(Processing.Weapon.ShotsFired, index)),
                    BulletsHit = json.GetInt32(string.Format(Processing.Weapon.ShotsHit, index))
                });

            return collection;
        }
    }
}