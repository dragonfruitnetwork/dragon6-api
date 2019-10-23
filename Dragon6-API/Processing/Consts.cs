namespace Dragon6.API.Processing
{
    /// <summary>
    ///     casual stats
    /// </summary>
    public class Casual
    {
        public const string Kills = "casualpvp_kills:infinite";
        public const string Deaths = "casualpvp_death:infinite";

        public const string Wins = "casualpvp_matchwon:infinite";
        public const string Losses = "casualpvp_matchlost:infinite";

        public const string MatchesPlayed = "casualpvp_matchplayed:infinite";
        public const string Time = "casualpvp_timeplayed:infinite";
    }

    /// <summary>
    ///     permanent ranked stats (not seasonal)
    /// </summary>
    public class Ranked
    {
        public const string Kills = "rankedpvp_kills:infinite";
        public const string Deaths = "rankedpvp_death:infinite";

        public const string Wins = "rankedpvp_matchwon:infinite";
        public const string Losses = "rankedpvp_matchlost:infinite";

        public const string MatchesPlayed = "rankedpvp_matchplayed:infinite";
        public const string Time = "rankedpvp_timeplayed:infinite";
    }

    /// <summary>
    ///     Stats relating to a ranked season
    /// </summary>
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

    /// <summary>
    ///     Stats relating to terrorist hunt, the PvE mode.
    /// </summary>
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
        public const string Penetrations = "generalpvp_penetrationkills:infinite";

        public const string Assists = "generalpvp_killassists:infinite";
        public const string Suicides = "generalpvp_suicide:infinite";

        public const string BulletFired = "generalpvp_bulletfired:infinite";
        public const string BulletHit = "generalpvp_bullethit:infinite";

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

    public class Weapon
    {
        public const string Kills = "weapontypepvp_kills:{0}:infinite";
        public const string Headshots = "weapontypepvp_headshot:{0}:infinite";
        public const string ShotsFired = "weapontypepvp_bulletfired:{0}:infinite";
        public const string ShotsHit = "weapontypepvp_bullethit:{0}:infinite";
    }

    public class Operator
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