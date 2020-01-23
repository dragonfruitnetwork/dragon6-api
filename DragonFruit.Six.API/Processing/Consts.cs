// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Processing
{
    public static class Accounts
    {
        public const string Name = "nameOnPlatform";
        public const string Platform = "platformType";

        public const string PlatformIdentifier = "idOnPlatform";
        public const string ProfileIdentifier = "profileId";
        public const string UserIdentifier = "userId";
    }

    public static class Misc
    {
        public const string Results = "results";
        public const string Profile = "profiles";
        public const string Players = "players";
    }

    public static class GeneralCasual
    {
        public const string Kills = "casualpvp_kills:infinite";
        public const string Deaths = "casualpvp_death:infinite";

        public const string Wins = "casualpvp_matchwon:infinite";
        public const string Losses = "casualpvp_matchlost:infinite";

        public const string MatchesPlayed = "casualpvp_matchplayed:infinite";
        public const string Time = "casualpvp_timeplayed:infinite";
    }

    public static class GeneralRanked
    {
        public const string Kills = "rankedpvp_kills:infinite";
        public const string Deaths = "rankedpvp_death:infinite";

        public const string Wins = "rankedpvp_matchwon:infinite";
        public const string Losses = "rankedpvp_matchlost:infinite";

        public const string MatchesPlayed = "rankedpvp_matchplayed:infinite";
        public const string Time = "rankedpvp_timeplayed:infinite";
    }

    public static class SeasonalRanked
    {
        public const string Season = "season";
        public const string Rank = "rank";
        public const string MaxRank = "max_rank";
        public const string Wins = "wins";
        public const string Losses = "losses";
        public const string Abandons = "abandons";
        public const string MMR = "mmr";
        public const string MaxMMR = "max_mmr";
    }

    public static class GeneralPvE
    {
        public const string Kills = "generalpve_kills:infinite";
        public const string Deaths = "generalpve_death:infinite";

        public const string Wins = "generalpve_matchwon:infinite";
        public const string Losses = "generalpve_matchlost:infinite";

        //public const string MatchesPlayed = ""; [NOT AVALIABLE - Add Wins and Losses]
        public const string Time = "generalpve_timeplayed:infinite";
    }

    public static class GeneralCustomGame
    {
        public const string Time = "custompvp_timeplayed:infinite";
    }

    public static class GeneralModeSpecifics
    {
        public const string Bomb = "plantbombpvp_bestscore:infinite";
        public const string Hostage = "rescuehostagepvp_bestscore:infinite";
        public const string Secure = "secureareapvp_bestscore:infinite";
    }

    public static class General
    {
        public const string Barricades = "generalpvp_barricadedeployed:infinite";
        public const string Reinforcements = "generalpvp_reinforcementdeploy:infinite";

        public const string Downs = "generalpvp_dbno:infinite";
        public const string Revives = "generalpvp_revive:infinite";

        public const string Headshots = "generalpvp_headshot:infinite";
        public const string Knives = "generalpvp_meleekills:infinite";
        public const string Penetrations = "generalpvp_penetrationkills:infinite";

        public const string Assists = "generalpvp_killassists:infinite";
        public const string Suicides = "generalpvp_suicide:infinite";

        public const string BulletFired = "generalpvp_bulletfired:infinite";
        public const string BulletHit = "generalpvp_bullethit:infinite";

        public const string Level = "level";
    }

    public static class OverallPvP
    {
        public const string Kills = "generalpvp_kills:infinite";
        public const string Deaths = "generalpvp_death:infinite";

        public const string Wins = "generalpvp_matchwon:infinite";
        public const string Losses = "generalpvp_matchlost:infinite";
        public const string WL = "generalpvp_matchwlratio:infinite";

        public const string Time = "generalpvp_timeplayed:infinite";
    }

    public static class OverallWeapon
    {
        public const string Kills = "weapontypepvp_kills:{0}:infinite";
        public const string Headshots = "weapontypepvp_headshot:{0}:infinite";
        public const string ShotsFired = "weapontypepvp_bulletfired:{0}:infinite";
        public const string ShotsHit = "weapontypepvp_bullethit:{0}:infinite";
    }

    public static class OverallOperator
    {
        public const string Kills = "operatorpvp_roundwon:{0}:infinite";
        public const string Deaths = "operatorpvp_roundlost:{0}:infinite";
        public const string Wins = "operatorpvp_kills:{0}:infinite";
        public const string Losses = "operatorpvp_death:{0}:infinite";
        public const string Downs = "operatorpvp_headshot:{0}:infinite";
        public const string Headshots = "operatorpvp_dbno:{0}:infinite";
        public const string Rounds = "operatorpvp_roundplayed:{0}:infinite";
    }
}
