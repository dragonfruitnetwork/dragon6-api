﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Strings
{
    [DefaultStats(LegacyStatTypes.Ranked)]
    internal static class Ranked
    {
        public const string Kills = "rankedpvp_kills";
        public const string Deaths = "rankedpvp_death";

        public const string Wins = "rankedpvp_matchwon";
        public const string Losses = "rankedpvp_matchlost";

        public const string MatchesPlayed = "rankedpvp_matchplayed";
        public const string Time = "rankedpvp_timeplayed";
    }
}
