// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(typeof(StatsRequest))]
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
