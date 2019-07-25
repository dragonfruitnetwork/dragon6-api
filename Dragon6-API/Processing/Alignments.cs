using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    /// <summary>
    /// Takes Ubisoft JSON and pareses it into a Dragon6 Class
    /// </summary>
    /// <param name="json"></param>
    /// <param name="GUID"></param>
    /// <returns></returns>
    class Alignments
    {
        /// <summary>
        /// Aligns into an AccountInfo Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<AccountInfo> AlignAccount(string json)
        {
            var values = await Task.Run(() => JObject.Parse(json));

            return new AccountInfo
            {
                PlayerName = values["profiles"][0]["nameOnPlatform"].ToString(),
                GUID = values["profiles"][0]["profileId"].ToString(),
                Platform = (string)values["profiles"][0]["platformType"] == "uplay"? References.Platforms.PC : (string)values["profiles"][0]["platformType"] == "psn" ? References.Platforms.PSN:References.Platforms.XB1
            };
        }

        /// <summary>
        /// Aligns into an PlayerStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<PlayerStats> AlignGeneralStats(string json,string GUID)
        {
            var PlayerObj = await Task.Run(() => JObject.Parse(json));
            return new PlayerStats
            {
                // Casual
                Casual_Kills = int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Kills] ?? "0"),
                Casual_Deaths = int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Deaths] ?? "0"),
                Casual_KD = float.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Kills] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Deaths] ?? "1"),

                Casual_Wins = int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Wins] ?? "0"),
                Casual_Losses = int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Losses] ?? "0"),
                Casual_WL = float.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Wins] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Losses] ?? "1"),

                Casual_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Time] ?? "0"),

                // General
                Barricades = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Barricades] ?? "0"),
                Reinforcements = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Reinforcements] ?? "0"),

                Downs = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Downs] ?? "0"),
                Revives = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Revives] ?? "0"),

                Headshots = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Headshots] ?? "0"),
                Knifes = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Knives] ?? "0"),

                Assists = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Assists] ?? "0"),
                Suicides = int.Parse((string)PlayerObj["results"][GUID][Consts.General.Suicides] ?? "0"),

                // Terrorist Hunt
                THunt_Kills = int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Kills] ?? "0"),
                THunt_Deaths = int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Deaths] ?? "0"),
                THunt_KD = float.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Kills] ?? "1") /
                           float.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Deaths] ?? "1"),

                THunt_Wins = int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Wins] ?? "0"),
                THunt_Losses = int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Losses] ?? "0"),
                THunt_WL = float.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Wins] ?? "1") /
                           float.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Losses] ?? "1"),
                THunt_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Wins] ?? "0") + int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Losses] ?? "0"),

                // Gamemodes
                HIScore_Secure =
                    int.Parse((string)PlayerObj["results"][GUID][Consts.ModeScores.Secure] ?? "0"),
                HIScore_Bomb = int.Parse((string)PlayerObj["results"][GUID][Consts.ModeScores.Bomb] ?? "0"),
                HIScore_Hostage =
                    int.Parse((string)PlayerObj["results"][GUID][Consts.ModeScores.Hostage] ?? "0"),

                // Time Played
                TimePlayed_Casual =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID][Consts.Casual.Time] ?? "0")),
                TimePlayed_THunt =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Time] ?? "0")),
                TimePlayed_Ranked =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Time] ?? "0")),
                TimePlayed_General =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID][Consts.Overall.Time] ?? "0")),
                TimePlayed_Custom =
                    TimeSpan.FromSeconds(
                        double.Parse((string)PlayerObj["results"][GUID][Consts.CustomGame.Time] ?? "0")),

                // Ranked
                Ranked_Wins = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Wins] ?? "0"),
                Ranked_Losses = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Losses] ?? "0"),
                Ranked_WL = float.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Wins] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Losses] ?? "1"),
                Ranked_MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.MatchesPlayed] ?? "0"),

                Ranked_Kills = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Kills] ?? "0"),
                Ranked_Deaths = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Deaths] ?? "0"),
                Ranked_KD = float.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Kills] ?? "1") /
                            float.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.Deaths] ?? "1"),

                // General
                Wins = int.Parse((string)PlayerObj["results"][GUID][Consts.Overall.Wins] ?? "0"),
                Losses = int.Parse((string)PlayerObj["results"][GUID][Consts.Overall.Losses] ?? "0"),
                Kills = int.Parse((string)PlayerObj["results"][GUID][Consts.Overall.Kills] ?? "0"),
                Deaths = int.Parse((string)PlayerObj["results"][GUID][Consts.Overall.Deaths] ?? "0"),
                WL = float.Parse((string)PlayerObj["results"][GUID][Consts.Overall.WL] ?? "0"),
                MatchesPlayed = int.Parse((string)PlayerObj["results"][GUID][Consts.Ranked.MatchesPlayed] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID][Consts.Casual.MatchesPlayed] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Wins] ?? "0")
                              + int.Parse((string)PlayerObj["results"][GUID][Consts.PvE.Losses] ?? "0")
            };

        }

        /// <summary>
        /// Aligns into an SeasonalStats Class
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<SeasonalStats> AlignSeason(string json,string GUID)
        {
            var response = await Task.Run(() =>
                JObject.Parse(json));

            return new SeasonalStats
            {
                Season = (int)response["players"][GUID][Consts.RankedSeason.Season],
                Rank = (int)response["players"][GUID][Consts.RankedSeason.Rank],
                Max_Rank = (int)response["players"][GUID][Consts.RankedSeason.MaxRank],
                Wins = (int)response["players"][GUID][Consts.RankedSeason.Wins],
                Losses = (int)response["players"][GUID][Consts.RankedSeason.Losses],
                Abandons = (int)response["players"][GUID][Consts.RankedSeason.Abandons],
                MMR = (int)response["players"][GUID][Consts.RankedSeason.MMR]
            };

        }

        /// <summary>
        /// Gets the User's Level as an int32
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static async Task<int> AlignLevel(string json)
        {
            return (int)await Task.Run(() =>
                JObject.Parse(json)["player_profiles"]
                    [0][Consts.General.Level]);
        }
    }
}
