using System;
using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class General
    {
        /// <summary>
        ///     Get a Users current R6 Clearance Level
        /// </summary>
        /// <param name="playerInfo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> GetLevel(AccountInfo playerInfo, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(d6WebRequest.FormAccountInfoUrl(playerInfo.Platform, playerInfo.GUID), token));

            return await Alignments.AlignLevel(rawData);
        }

        /// <summary>
        ///     Get Generalised stats for player
        /// </summary>
        /// <param name="playerInfo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<General> GetStats(AccountInfo playerInfo, string token)
        {
            var rawData = await Task.Run(() => d6WebRequest.GetWebJObject(
                d6WebRequest.FormStatsUrl(playerInfo,
                    "rankedpvp_death,rankedpvp_kdratio,rankedpvp_kills,rankedpvp_matchlost,rankedpvp_matchplayed,rankedpvp_matchwlratio,rankedpvp_matchwon,rankedpvp_timeplayed,casualpvp_death,casualpvp_kdratio,casualpvp_kills,casualpvp_matchlost,casualpvp_matchplayed,casualpvp_matchwlratio,casualpvp_matchwon,casualpvp_timeplayed,generalpvp_barricadedeployed,generalpvp_dbno,generalpvp_death,generalpvp_headshot,generalpvp_killassists,generalpvp_kills,generalpvp_matchlost,generalpvp_matchwlratio,generalpvp_matchwon,generalpvp_meleekills,generalpvp_reinforcementdeploy,generalpvp_revive,generalpvp_suicide,generalpvp_timeplayed,generalpvp_revive,generalpve_kills,generalpve_death,generalpve_matchwon,generalpve_matchlost,custompvp_timeplayed,plantbombpvp_bestscore,rescuehostagepvp_bestscore,secureareapvp_bestscore,casualpvp_timeplayed,rankedpvp_timeplayed,generalpve_timeplayed,generalpvp_bulletfired,generalpvp_penetrationkills,generalpvp_bullethit"),
                token));

            return Alignments.AlignGeneralStats(rawData, playerInfo.GUID);
        }

        #region Vars

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public float WL { get; set; }
        public int MatchesPlayed => Casual_MatchesPlayed + Ranked_MatchesPlayed + THunt_MatchesPlayed;

        public int Casual_Kills { get; set; }
        public int Casual_Deaths { get; set; }
        public float Casual_KD { get; set; }
        public int Casual_Wins { get; set; }
        public int Casual_Losses { get; set; }
        public float Casual_WL { get; set; }
        public int Casual_MatchesPlayed { get; set; }

        public int Barricades { get; set; }
        public int Reinforcements { get; set; }
        public int Downs { get; set; }
        public int Revives { get; set; }
        public int Suicides { get; set; }
        public int Headshots { get; set; }
        public int Penetrations { get; set; }
        public int Knifes { get; set; }
        public int Assists { get; set; }
        public long ShotsFired { get; set; }
        public long ShotsConnected { get; set; }

        public int THunt_Kills { get; set; }
        public int THunt_Deaths { get; set; }
        public float THunt_KD { get; set; }
        public int THunt_Wins { get; set; }
        public int THunt_Losses { get; set; }
        public float THunt_WL { get; set; }
        public int THunt_MatchesPlayed => THunt_Losses + THunt_Wins;

        public int HIScore_Bomb { get; set; }
        public int HIScore_Secure { get; set; }
        public int HIScore_Hostage { get; set; }

        public TimeSpan TimePlayed_THunt { get; set; }
        public TimeSpan TimePlayed_Casual { get; set; }
        public TimeSpan TimePlayed_Ranked { get; set; }
        public TimeSpan TimePlayed_General { get; set; }
        public TimeSpan TimePlayed_Custom { get; set; }


        public int Ranked_Wins { get; set; }
        public int Ranked_Losses { get; set; }
        public float Ranked_WL { get; set; }
        public int Ranked_MatchesPlayed { get; set; }

        public int Ranked_Kills { get; set; }
        public int Ranked_Deaths { get; set; }
        public float Ranked_KD { get; set; }

        #endregion
    }
}