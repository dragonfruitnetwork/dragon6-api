﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Strings
{
    [DefaultStats(LegacyStatTypes.Casual)]
    internal static class Casual
    {
        public const string Kills = "casualpvp_kills";
        public const string Deaths = "casualpvp_death";

        public const string Wins = "casualpvp_matchwon";
        public const string Losses = "casualpvp_matchlost";

        public const string MatchesPlayed = "casualpvp_matchplayed";
        public const string Time = "casualpvp_timeplayed";
    }
}
