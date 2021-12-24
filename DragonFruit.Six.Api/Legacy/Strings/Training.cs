// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Strings
{
    [DefaultStats(LegacyStatTypes.Training)]
    internal static class Training
    {
        public const string Kills = "generalpve_kills";
        public const string Deaths = "generalpve_death";

        public const string Wins = "generalpve_matchwon";
        public const string Losses = "generalpve_matchlost";

        public const string Time = "generalpve_timeplayed";
        public const string MatchesPlayed = "generalpve_matchplayed";
    }
}
