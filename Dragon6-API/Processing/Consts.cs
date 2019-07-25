using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// the consts used by ubi to identify stats
/// </summary>
namespace Dragon6.API.Consts
{
    public class Casual
    {
        public const string Kills = "casualpvp_kills:infinite";
        public const string Deaths = "casualpvp_death:infinite";
        public const string Wins = "casualpvp_matchwon:infinite";
        public const string Losses = "casualpvp_matchlost:infinite";
        public const string MatchesPlayed = "casualpvp_matchplayed:infinite";
        public const string Time = "casualpvp_timeplayed:infinite";
    }

    public class Ranked
    { 
        public const string Kills = "rankedpvp_kills:infinite";
        public const string Deaths = "rankedpvp_death:infinite";
        public const string Wins = "rankedpvp_matchwon:infinite";
        public const string Losses = "rankedpvp_matchlost:infinite";
        public const string MatchesPlayed = "rankedpvp_matchplayed:infinite";
        public const string Time = "rankedpvp_timeplayed:infinite";
    }

    public class RankedSeason
    {
        public const string Season = "season";
        public const string Rank = "rank";
        public const string MaxRank = "max_rank";
        public const string Wins = "wins";
        public const string Losses = "losses";
        public const string Abandons = "abandons";
        public const string MMR = "mmr";
    }

    public class PvE
    {
        public const string Kills = "generalpve_kills:infinite";
        public const string Deaths = "generalpve_death:infinite";
        public const string Wins = "generalpve_matchwon:infinite";
        public const string Losses = "generalpve_matchlost:infinite";
        //public const string MatchesPlayed = ""; [NOT AVALIABLE - Add Wins and Losses]
        public const string Time = "generalpve_timeplayed:infinite";
    }

    public class CustomGame
    {
        public const string Time = "custompvp_timeplayed:infinite";
    }

    public class ModeScores
    {
        public const string Bomb = "plantbombpvp_bestscore:infinite";
        public const string Hostage = "rescuehostagepvp_bestscore:infinite";
        public const string Secure = "secureareapvp_bestscore:infinite";
    }

    public class General
    {
        public const string Barricades = "generalpvp_barricadedeployed:infinite";
        public const string Reinforcements = "generalpvp_reinforcementdeploy:infinite";
        public const string Downs = "generalpvp_dbno:infinite";
        public const string Revives = "generalpvp_revive:infinite";
        public const string Headshots = "generalpvp_headshot:infinite";
        public const string Knives = "generalpvp_meleekills:infinite";
        public const string Assists = "generalpvp_killassists:infinite";
        public const string Suicides = "generalpvp_suicide:infinite";

        public const string Level = "level";
    }

    public class Overall
    {
        public const string Kills = "generalpvp_kills:infinite";
        public const string Deaths = "generalpvp_death:infinite";
        public const string Wins = "generalpvp_matchwon:infinite";
        public const string Losses = "generalpvp_matchlost:infinite";
        public const string WL = "generalpvp_matchwlratio:infinite";
        public const string Time = "generalpvp_timeplayed:infinite";
    }
}
