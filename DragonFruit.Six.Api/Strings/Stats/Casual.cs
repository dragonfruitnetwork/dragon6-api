// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Strings.Stats
{
    [DefaultStats(typeof(StatsRequest))]
    public static class Casual
    {
        public static string Kills => "casualpvp_kills";
        public static string Deaths => "casualpvp_death";

        public static string Wins => "casualpvp_matchwon";
        public static string Losses => "casualpvp_matchlost";

        public static string MatchesPlayed => "casualpvp_matchplayed";
        public static string Time => "casualpvp_timeplayed";
    }
}
