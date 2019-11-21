// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Stats
{
    public class General
    {
        /// <summary>
        ///     Get a Users current clearance Level
        /// </summary>
        /// <param name="playerInfo"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<uint> GetLevel(AccountInfo playerInfo, string token)
        {
            var rawData = await Task.Run(() =>
                d6WebRequest.GetWebJObject(d6WebRequest.FormAccountInfoUrl(playerInfo.Platform, playerInfo.Guid),
                    token));

            return rawData.AlignLevel();
        }

        /// <summary>
        ///     Get Generalized stats for player
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

            return rawData.AlignGeneralStats(playerInfo.Guid);
        }

        #region Vars

        public uint Wins { get; set; }
        public uint Losses { get; set; }
        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public float WL { get; set; }
        public uint MatchesPlayed => Casual_MatchesPlayed + Ranked_MatchesPlayed + THunt_MatchesPlayed;

        public uint Casual_Kills { get; set; }
        public uint Casual_Deaths { get; set; }
        public float Casual_KD { get; set; }
        public uint Casual_Wins { get; set; }
        public uint Casual_Losses { get; set; }
        public float Casual_WL { get; set; }
        public uint Casual_MatchesPlayed { get; set; }

        public uint Barricades { get; set; }
        public uint Reinforcements { get; set; }
        public uint Downs { get; set; }
        public uint Revives { get; set; }
        public uint Suicides { get; set; }
        public uint Headshots { get; set; }
        public uint Penetrations { get; set; }
        public uint Knifes { get; set; }
        public uint Assists { get; set; }
        public long ShotsFired { get; set; }
        public long ShotsConnected { get; set; }

        public uint THunt_Kills { get; set; }
        public uint THunt_Deaths { get; set; }
        public float THunt_KD { get; set; }
        public uint THunt_Wins { get; set; }
        public uint THunt_Losses { get; set; }
        public float THunt_WL { get; set; }
        public uint THunt_MatchesPlayed => THunt_Losses + THunt_Wins;

        public uint HIScore_Bomb { get; set; }
        public uint HIScore_Secure { get; set; }
        public uint HIScore_Hostage { get; set; }

        public TimeSpan TimePlayed_THunt { get; set; }
        public TimeSpan TimePlayed_Casual { get; set; }
        public TimeSpan TimePlayed_Ranked { get; set; }
        public TimeSpan TimePlayed_General { get; set; }
        public TimeSpan TimePlayed_Custom { get; set; }

        public uint Ranked_Wins { get; set; }
        public uint Ranked_Losses { get; set; }
        public float Ranked_WL { get; set; }
        public uint Ranked_MatchesPlayed { get; set; }

        public uint Ranked_Kills { get; set; }
        public uint Ranked_Deaths { get; set; }
        public float Ranked_KD { get; set; }

        #endregion
    }
}