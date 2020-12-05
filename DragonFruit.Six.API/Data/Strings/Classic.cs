// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data.Strings
{
    public static class Classic
    {
        public static string Kills => "generalpvp_kills";
        public static string Deaths => "generalpvp_death";

        public static string Wins => "generalpvp_matchwon";
        public static string Losses => "generalpvp_matchlost";

        public static string Time => "generalpvp_timeplayed";
        public static string MatchesPlayed => "generalpvp_matchplayed";

        public static string Barricades => "generalpvp_barricadedeployed";
        public static string Reinforcements => "generalpvp_reinforcementdeploy";
        public static string GadgetsDestroyed => "generalpvp_gadgetdestroy";

        public static string Downs => "generalpvp_dbno";
        public static string Revives => "generalpvp_revive";

        public static string Headshots => "generalpvp_headshot";
        public static string Knives => "generalpvp_meleekills";
        public static string Penetrations => "generalpvp_penetrationkills";
        public static string BlindKills => "generalpvp_blindkills";

        public static string Assists => "generalpvp_killassists";
        public static string DownAssists => "generalpvp_dbnoassists";
        public static string Suicides => "generalpvp_suicide";

        public static string BulletFired => "generalpvp_bulletfired";
        public static string BulletHit => "generalpvp_bullethit";

        public static string Experience => "generalpvp_totalxp";

        // todo this sometimes sends back a negative number (overflow wrap)
        //public static string DistanceTravelled => "generalpvp_distancetravelled";
    }
}
