using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API
{
    public class PlayerStats
    {
        #region Vars
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public float WL { get; set; }
        public int MatchesPlayed { get; set; }

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
        public int Knifes { get; set; }
        public int Assists { get; set; }

        public int THunt_Kills { get; set; }
        public int THunt_Deaths { get; set; }
        public float THunt_KD { get; set; }
        public int THunt_Wins { get; set; }
        public int THunt_Losses { get; set; }
        public float THunt_WL { get; set; }
        public int THunt_MatchesPlayed { get; set; }

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
        public float Ranked_MatchesPlayed { get; set; }

        public int rankedpvp_matchplayed { get; set; }

        public int Ranked_Kills { get; set; }
        public int Ranked_Deaths { get; set; }
        public float Ranked_KD { get; set; }
        #endregion

        /// <summary>
        /// Get a Users current R6 Clearance Level
        /// </summary>
        /// <param name="playerInfo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> GetLevel(AccountInfo playerInfo,string token)
        {
            //get GUID from playerInfo
            var guid = playerInfo.GUID;
            var client = new HttpClient();
            var uri =
                "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=";
            if (playerInfo.Platform == References.Platforms.PSN)
                uri =
                    "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=";
            if (playerInfo.Platform == References.Platforms.XB1)
                uri =
                    "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions?profile_ids=";

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var request = await client.GetAsync(uri + guid);

            if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            return await Alignments.AlignLevel(await request.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Get Generalised stats for player
        /// </summary>
        /// <param name="playerInfo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<PlayerStats> GetStats(AccountInfo playerInfo,string token)
        {
            var GUID = playerInfo.GUID;
            var client = new HttpClient();
            string uri;

            switch (playerInfo.Platform)
            {
                case References.Platforms.PSN:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics?populations=";
                    break;
                case References.Platforms.XB1:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics?populations=";
                    break;
                default:
                    uri =
                        "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics?populations=";
                    break;
            }

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Ubi_v1 t=" + token);
            client.DefaultRequestHeaders.Add("Ubi-Appid", "39baebad-39e5-4552-8c25-2c9b919064e2");

            var request = await client
                .GetAsync(uri + GUID +
                          "&statistics=rankedpvp_death,rankedpvp_kdratio,rankedpvp_kills,rankedpvp_matchlost,rankedpvp_matchplayed,rankedpvp_matchwlratio,rankedpvp_matchwon,rankedpvp_timeplayed,casualpvp_death,casualpvp_kdratio,casualpvp_kills,casualpvp_matchlost,casualpvp_matchplayed,casualpvp_matchwlratio,casualpvp_matchwon,casualpvp_timeplayed,generalpvp_barricadedeployed,generalpvp_dbno,generalpvp_death,generalpvp_headshot,generalpvp_killassists,generalpvp_kills,generalpvp_matchlost,generalpvp_matchwlratio,generalpvp_matchwon,generalpvp_meleekills,generalpvp_reinforcementdeploy,generalpvp_revive,generalpvp_suicide,generalpvp_timeplayed,generalpvp_revive,generalpve_kills,generalpve_death,generalpve_matchwon,generalpve_matchlost,custompvp_timeplayed,plantbombpvp_bestscore,rescuehostagepvp_bestscore,secureareapvp_bestscore,casualpvp_timeplayed,rankedpvp_timeplayed,generalpve_timeplayed");

            if (request.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            return await Alignments.AlignGeneralStats(await request.Content.ReadAsStringAsync(), GUID);
        }
    }
}
