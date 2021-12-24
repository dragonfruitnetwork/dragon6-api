// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(LegacyStatTypes.Playlists)]

    internal static class Secure
    {
        public const string Wins = "secureareapvp_matchwon";
        public const string Losses = "secureareapvp_matchlost";
        public const string MatchesPlayed = "secureareapvp_matchplayed";

        public const string Time = "secureareapvp_timeplayed";
        public const string Highscore = "secureareapvp_bestscore";

        public const string Aggressions = "secureareapvp_serveraggression";
        public const string Defenses = "secureareapvp_serverdefender";
        public const string Captures = "secureareapvp_servershacked";
    }
}
