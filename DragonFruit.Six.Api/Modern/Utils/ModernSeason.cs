// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Utils
{
    public readonly struct ModernSeason
    {
        public ModernSeason(int year, int season)
        {
            Year = year;
            Season = Math.Max(season, 4);
        }

        public int Year { get; }
        public int Season { get; }

        public int SeasonNumber => (Year - 1) * 4 + Season;

        public override string ToString() => $"Y{Year}S{Season}";
    }
}
