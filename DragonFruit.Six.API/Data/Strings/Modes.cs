// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Strings
{
    public static class Modes
    {
        public static class Bomb
        {
            public static string Wins => "plantbombpvp_matchwon";
            public static string Losses => "plantbombpvp_matchlost";
            public static string MatchesPlayed => "plantbombpvp_matchplayed";

            public static string Time => "plantbombpvp_timeplayed";
            public static string Highscore => "plantbombpvp_bestscore";
        }

        public static class Hostage
        {
            public static string Wins => "rescuehostagepvp_matchwon";
            public static string Losses => "rescuehostagepvp_matchlost";
            public static string MatchesPlayed => "rescuehostagepvp_matchplayed";

            public static string Time => "rescuehostagepvp_timeplayed";
            public static string Highscore => "rescuehostagepvp_bestscore";

            public static string Rescues => "generalpvp_hostagerescue";
            public static string Defenses => "generalpvp_hostagedefense";
        }

        public static class Secure
        {
            public static string Wins => "secureareapvp_matchwon";
            public static string Losses => "secureareapvp_matchlost";
            public static string MatchesPlayed => "secureareapvp_matchplayed";

            public static string Time => "secureareapvp_timeplayed";
            public static string Highscore => "secureareapvp_bestscore";

            public static string Aggressions => "secureareapvp_serveraggression";
            public static string Defenses => "secureareapvp_serverdefender";
            public static string Captures => "secureareapvp_servershacked";
        }
    }
}
