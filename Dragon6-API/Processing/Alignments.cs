using Dragon6.API.Helpers;
using Dragon6.API.Stats;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Dragon6.API
{
    /// <summary>
    /// Takes Ubisoft JSON and pareses it into a Dragon6 Class
    /// </summary>
    internal class Alignments
    {
        /// <summary>
        /// Aligns into an AccountInfo Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> AlignAccount(string json)
        {
            var values = await Task.Run(() => JObject.Parse(json));
            values = JObject.FromObject(values["profiles"][0]);

            return new AccountInfo
            {
                PlayerName = values["nameOnPlatform"].ToString(),
                GUID = values["profileId"].ToString(),
                Platform = (string)values["platformType"] == "uplay" ? References.Platforms.PC : (string)values["platformType"] == "psn" ? References.Platforms.PSN : References.Platforms.XB1
            };
        }

        /// <summary>
        /// Aligns into an PlayerStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static General AlignGeneralStats(string json, string GUID)
        {
            var PlayerObj = (JObject)JObject.Parse(json)["results"][GUID];
            var JSON = new JSONConverter(PlayerObj);

            if (PlayerObj == null)
            {
                return new General();
            }

            return new General
            {
                // Casual
                Casual_Kills = JSON.GetInt32(Consts.Casual.Kills),
                Casual_Deaths = JSON.GetInt32(Consts.Casual.Deaths),
                Casual_KD = JSON.GetFloat(Consts.Casual.Kills, 1) / JSON.GetFloat(Consts.Casual.Deaths, 1),

                Casual_Wins = JSON.GetInt32(Consts.Casual.Wins),
                Casual_Losses = JSON.GetInt32(Consts.Casual.Losses),
                Casual_WL = JSON.GetFloat(Consts.Casual.Wins, 1) / JSON.GetFloat(Consts.Casual.Losses, 1),

                Casual_MatchesPlayed = JSON.GetInt32(Consts.Casual.Time),

                // General
                Barricades = JSON.GetInt32(Consts.General.Barricades),
                Reinforcements = JSON.GetInt32(Consts.General.Reinforcements),

                Downs = JSON.GetInt32(Consts.General.Downs),
                Revives = JSON.GetInt32(Consts.General.Revives),

                Penetrations = JSON.GetInt32(Consts.General.Penetrations),
                Headshots = JSON.GetInt32(Consts.General.Headshots),
                Knifes = JSON.GetInt32(Consts.General.Knives),

                Assists = JSON.GetInt32(Consts.General.Assists),
                Suicides = JSON.GetInt32(Consts.General.Suicides),

                ShotsFired = JSON.GetInt64(Consts.General.BulletFired),
                ShotsConnected = JSON.GetInt64(Consts.General.BulletHit),

                // Terrorist Hunt
                THunt_Kills = JSON.GetInt32(Consts.PvE.Kills),
                THunt_Deaths = JSON.GetInt32(Consts.PvE.Deaths),
                THunt_KD = JSON.GetFloat(Consts.PvE.Kills, 1) / JSON.GetFloat(Consts.PvE.Deaths, 1),

                THunt_Wins = JSON.GetInt32(Consts.PvE.Wins),
                THunt_Losses = JSON.GetInt32(Consts.PvE.Losses),
                THunt_WL = JSON.GetFloat(Consts.PvE.Wins, 1) / JSON.GetFloat(Consts.PvE.Losses, 1),

                // Gamemodes
                HIScore_Secure = JSON.GetInt32(Consts.ModeScores.Secure),
                HIScore_Bomb = JSON.GetInt32(Consts.ModeScores.Bomb),
                HIScore_Hostage = JSON.GetInt32(Consts.ModeScores.Hostage),

                // Time Played
                TimePlayed_Casual = TimeSpan.FromSeconds(JSON.GetDouble(Consts.Casual.Time)),
                TimePlayed_THunt = TimeSpan.FromSeconds(JSON.GetDouble(Consts.PvE.Time)),
                TimePlayed_Ranked = TimeSpan.FromSeconds(JSON.GetDouble(Consts.Ranked.Time)),
                TimePlayed_General = TimeSpan.FromSeconds(JSON.GetDouble(Consts.Overall.Time)),
                TimePlayed_Custom = TimeSpan.FromSeconds(JSON.GetDouble(Consts.CustomGame.Time)),

                // Ranked
                Ranked_Wins = JSON.GetInt32(Consts.Ranked.Wins),
                Ranked_Losses = JSON.GetInt32(Consts.Ranked.Losses),
                Ranked_WL = JSON.GetFloat(Consts.Ranked.Wins, 1) / JSON.GetFloat(Consts.Ranked.Losses, 1),
                Ranked_MatchesPlayed = JSON.GetInt32(Consts.Ranked.MatchesPlayed),

                Ranked_Kills = JSON.GetInt32(Consts.Ranked.Kills),
                Ranked_Deaths = JSON.GetInt32(Consts.Ranked.Deaths),
                Ranked_KD = JSON.GetFloat(Consts.Ranked.Kills, 1) / JSON.GetFloat(Consts.Ranked.Deaths, 1),

                // General (Overall Stats)
                Wins = JSON.GetInt32(Consts.Overall.Wins),
                Losses = JSON.GetInt32(Consts.Overall.Losses),
                Kills = JSON.GetInt32(Consts.Overall.Kills),
                Deaths = JSON.GetInt32(Consts.Overall.Deaths),
                WL = JSON.GetFloat(Consts.Overall.WL),
            };

        }

        /// <summary>
        /// Aligns into an SeasonalStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<Season> AlignSeason(string json, string GUID)
        {
            var JSON = new JSONConverter((JObject)JObject.Parse(json)["players"][GUID]);

            return new Season
            {
                SeasonID = JSON.GetInt32(Consts.RankedSeason.Season),
                Rank = JSON.GetInt32(Consts.RankedSeason.Rank),
                Max_Rank = JSON.GetInt32(Consts.RankedSeason.MaxRank),
                Wins = JSON.GetInt32(Consts.RankedSeason.Wins),
                Losses = JSON.GetInt32(Consts.RankedSeason.Losses),
                Abandons = JSON.GetInt32(Consts.RankedSeason.Abandons),
                MMR = JSON.GetInt32(Consts.RankedSeason.MMR)
            };

        }

        /// <summary>
        /// Gets the User's Level as an int32
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<int> AlignLevel(string json)
        {
            return (int)await Task.Run(() => JObject.Parse(json)["player_profiles"][0][Consts.General.Level]);
        }
    }
}
