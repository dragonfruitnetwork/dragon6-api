// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(typeof(StatsRequest))]
    public static class Bomb
    {
        public static string Wins => "plantbombpvp_matchwon";
        public static string Losses => "plantbombpvp_matchlost";
        public static string MatchesPlayed => "plantbombpvp_matchplayed";

        public static string Time => "plantbombpvp_timeplayed";
        public static string Highscore => "plantbombpvp_bestscore";
    }
}
