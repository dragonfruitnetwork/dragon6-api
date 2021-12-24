// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(LegacyStatTypes.Playlists)]
    internal static class Bomb
    {
        public const string Wins = "plantbombpvp_matchwon";
        public const string Losses = "plantbombpvp_matchlost";
        public const string MatchesPlayed = "plantbombpvp_matchplayed";

        public const string Time = "plantbombpvp_timeplayed";
        public const string Highscore = "plantbombpvp_bestscore";
    }
}
