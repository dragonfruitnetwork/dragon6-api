// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data.Strings
{
    public static class Modes
    {
        public static class Bomb
        {
            public static readonly string Wins = "plantbombpvp_matchwon";
            public static readonly string Losses = "plantbombpvp_matchlost";
            public static readonly string MatchesPlayed = "plantbombpvp_matchplayed";

            public static readonly string Time = "plantbombpvp_timeplayed";
            public static readonly string Highscore = "plantbombpvp_bestscore";
        }

        public static class Hostage
        {
            public static readonly string Wins = "rescuehostagepvp_matchwon";
            public static readonly string Losses = "rescuehostagepvp_matchlost";
            public static readonly string MatchesPlayed = "rescuehostagepvp_matchplayed";

            public static readonly string Time = "rescuehostagepvp_timeplayed";
            public static readonly string Highscore = "rescuehostagepvp_bestscore";
        }

        public static class Secure
        {
            public static readonly string Wins = "secureareapvp_matchwon";
            public static readonly string Losses = "secureareapvp_matchlost";
            public static readonly string MatchesPlayed = "secureareapvp_matchplayed";

            public static readonly string Time = "secureareapvp_timeplayed";
            public static readonly string Highscore = "secureareapvp_bestscore";
        }
    }
}
