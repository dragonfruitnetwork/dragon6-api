// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(typeof(StatsRequest))]
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
}
