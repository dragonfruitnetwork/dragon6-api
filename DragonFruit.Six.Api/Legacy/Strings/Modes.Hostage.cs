﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Utils;

// ReSharper disable CheckNamespace

namespace DragonFruit.Six.Api.Strings.Stats.Modes
{
    [DefaultStats(LegacyStatTypes.Playlists)]
    internal static class Hostage
    {
        public const string Wins = "rescuehostagepvp_matchwon";
        public const string Losses = "rescuehostagepvp_matchlost";
        public const string MatchesPlayed = "rescuehostagepvp_matchplayed";

        public const string Time = "rescuehostagepvp_timeplayed";
        public const string Highscore = "rescuehostagepvp_bestscore";

        public const string Rescues = "generalpvp_hostagerescue";
        public const string Defenses = "generalpvp_hostagedefense";
    }
}
