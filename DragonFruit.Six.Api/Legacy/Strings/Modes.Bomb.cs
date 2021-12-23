﻿// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(LegacyStatTypes.Playlists)]

    public static class Bomb
    {
        public const string Wins = "plantbombpvp_matchwon";
        public const string Losses = "plantbombpvp_matchlost";
        public const string MatchesPlayed = "plantbombpvp_matchplayed";

        public const string Time = "plantbombpvp_timeplayed";
        public const string Highscore = "plantbombpvp_bestscore";
    }
}