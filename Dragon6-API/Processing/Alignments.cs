using System;
using System.Threading.Tasks;
using Dragon6.API.Consts;
using Dragon6.API.Helpers;
using Dragon6.API.Stats;
using Newtonsoft.Json.Linq;
using General = Dragon6.API.Stats.General;

namespace Dragon6.API
{
    /// <summary>
    ///     Takes Ubisoft JSON and pareses it into a Dragon6 Class
    /// </summary>
    internal class Alignments
    {
        /// <summary>
        ///     Aligns into an AccountInfo Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static AccountInfo AlignAccount(JObject json)
        {
            var values = JObject.FromObject(json["profiles"][0]);

            return new AccountInfo
            {
                PlayerName = values["nameOnPlatform"].ToString(),
                GUID = values["profileId"].ToString(),
                Platform = (string) values["platformType"] == "uplay" ? References.Platforms.PC :
                    (string) values["platformType"] == "psn" ? References.Platforms.PSN : References.Platforms.XB1
            };
        }

        /// <summary>
        ///     Aligns into an PlayerStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static General AlignGeneralStats(JObject jObject, string GUID)
        {
            if (jObject == null)
            {
                return new General();
            }

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
                Barricades = json.GetInt32(Consts.General.Barricades),
                Reinforcements = json.GetInt32(Consts.General.Reinforcements),

                Downs = json.GetInt32(Consts.General.Downs),
                Revives = json.GetInt32(Consts.General.Revives),

                Penetrations = json.GetInt32(Consts.General.Penetrations),
                Headshots = json.GetInt32(Consts.General.Headshots),
                Knifes = json.GetInt32(Consts.General.Knives),

                Assists = json.GetInt32(Consts.General.Assists),
                Suicides = json.GetInt32(Consts.General.Suicides),

                ShotsFired = json.GetInt64(Consts.General.BulletFired),
                ShotsConnected = json.GetInt64(Consts.General.BulletHit),

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
        public static async Task<Season> AlignSeason(JObject json, string GUID)
        {
            var JSON = new JSONConverter(json["players"][GUID]);

            return new Season
            {
                SeasonID = JSON.GetInt32(RankedSeason.Season),
                Rank = JSON.GetInt32(RankedSeason.Rank),
                Max_Rank = JSON.GetInt32(RankedSeason.MaxRank),
                Wins = JSON.GetInt32(RankedSeason.Wins),
                Losses = JSON.GetInt32(RankedSeason.Losses),
                Abandons = JSON.GetInt32(RankedSeason.Abandons),
                MMR = JSON.GetInt32(RankedSeason.MMR)
            };
        }

        /// <summary>
        ///     Gets the User's Level as an int32
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<int> AlignLevel(JObject json)
        {
            return (int) await Task.Run(() => json["player_profiles"][0][Consts.General.Level]);
        }
    }
}