// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
using DragonFruit.Six.Api.Seasonal.Entities;

namespace DragonFruit.Six.Api.Seasonal
{
    public static class Ranks
    {
        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the provided rank and season
        /// </summary>
        /// <param name="id">The id of the rank to return</param>
        /// <param name="season">The id of the season (optional, -1 for the latest season)</param>
        public static RankInfo GetFromId(int id, int season = -1) => GetRank(id, season);

        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the provided mmr and season
        /// </summary>
        /// <param name="mmr">The mmr of the rank to return</param>
        /// <param name="season">The id of the season (optional, -1 for the latest season)</param>
        public static RankInfo GetFromMMR(int mmr, int season = -1) => GetRank(mmr, season, true);

        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the identifier and season
        /// </summary>
        /// <param name="identifier">The id of the rank or the mmr</param>
        /// <param name="season">The id of the season (optional, -1 for the latest season)</param>
        /// <param name="isMMR">Whether the <see cref="RankInfo"/> represents mmr.</param>
        public static RankInfo GetRank(int identifier, int season = -1, bool isMMR = false)
        {
            var itemsSource = season switch
            {
                // season 1-14
                >= 01 and <= 14 => RankingV1,

                // season 15-22
                >= 15 and <= 22 => RankingV2,

                // season 23-27
                <= 27 => RankingV3,

                // season 28- (incl. latest season identifier)
                _ => RankingV4
            };

            if (isMMR)
            {
                return itemsSource.Where(x => (x.MinMMR ?? int.MinValue) <= identifier && (x.MaxMMR ?? int.MaxValue) >= identifier).OrderByDescending(x => x.Id).First();
            }

            // if the rank isn't in the array, return generic unranked one
            return identifier + 1 <= itemsSource.Length ? itemsSource[identifier] : RankingV4[0];
        }

        #region Data Sources

        private static readonly RankInfo[] RankingV4 =
        {
            new(0, "Unranked", "/rank/v4/0.png", null, null),

            new(1, "Copper 5", "/rank/v4/1.png", null, 1099),
            new(2, "Copper 4", "/rank/v4/2.png", 1100, 1199),
            new(3, "Copper 3", "/rank/v4/3.png", 1200, 1299),
            new(4, "Copper 2", "/rank/v4/4.png", 1300, 1399),
            new(5, "Copper 1", "/rank/v4/5.png", 1400, 1499),

            new(6, "Bronze 5", "/rank/v4/6.png", 1500, 1599),
            new(7, "Bronze 4", "/rank/v4/7.png", 1600, 1699),
            new(8, "Bronze 3", "/rank/v4/8.png", 1700, 1799),
            new(9, "Bronze 2", "/rank/v4/9.png", 1800, 1899),
            new(10, "Bronze 1", "/rank/v4/10.png", 1900, 1999),

            new(11, "Silver 5", "/rank/v4/11.png", 2000, 2099),
            new(12, "Silver 4", "/rank/v4/12.png", 2100, 2199),
            new(13, "Silver 3", "/rank/v4/13.png", 2200, 2299),
            new(14, "Silver 2", "/rank/v4/14.png", 2300, 2399),
            new(15, "Silver 1", "/rank/v4/15.png", 2400, 2499),

            new(16, "Gold 5", "/rank/v4/16.png", 2500, 2599),
            new(17, "Gold 4", "/rank/v4/17.png", 2600, 2699),
            new(18, "Gold 3", "/rank/v4/18.png", 2700, 2799),
            new(19, "Gold 2", "/rank/v4/19.png", 2800, 2899),
            new(20, "Gold 1", "/rank/v4/20.png", 2900, 2999),

            new(21, "Platinum 5", "/rank/v4/21.png", 3000, 3099),
            new(22, "Platinum 4", "/rank/v4/22.png", 3100, 3199),
            new(23, "Platinum 3", "/rank/v4/23.png", 3200, 3299),
            new(24, "Platinum 2", "/rank/v4/24.png", 3300, 3399),
            new(25, "Platinum 1", "/rank/v4/25.png", 3400, 3499),

            new(26, "Emerald 5", "/rank/v4/26.png", 3500, 3599),
            new(27, "Emerald 4", "/rank/v4/27.png", 3600, 3699),
            new(28, "Emerald 3", "/rank/v4/28.png", 3700, 3799),
            new(29, "Emerald 2", "/rank/v4/29.png", 3800, 3899),
            new(30, "Emerald 1", "/rank/v4/30.png", 3900, 3999),

            new(31, "Diamond 5", "/rank/v4/31.png", 4000, 4099),
            new(32, "Diamond 4", "/rank/v4/32.png", 4100, 4199),
            new(33, "Diamond 3", "/rank/v4/33.png", 4200, 4299),
            new(34, "Diamond 2", "/rank/v4/34.png", 4300, 4399),
            new(35, "Diamond 1", "/rank/v4/35.png", 4400, 4499),

            new(36, "Champion", "/rank/v4/36.png", 4500, null)
        };

        private static readonly RankInfo[] RankingV3 =
        {
            new(0, "Unranked", "/rank/v3-png/0.png", null, null),

            new(1, "Copper 5", "/rank/v3-png/1.png", null, 1199),
            new(2, "Copper 4", "/rank/v3-png/2.png", 1200, 1299),
            new(3, "Copper 3", "/rank/v3-png/3.png", 1300, 1399),
            new(4, "Copper 2", "/rank/v3-png/4.png", 1400, 1499),
            new(5, "Copper 1", "/rank/v3-png/5.png", 1500, 1599),

            new(6, "Bronze 5", "/rank/v3-png/6.png", 1600, 1699),
            new(7, "Bronze 4", "/rank/v3-png/7.png", 1700, 1799),
            new(8, "Bronze 3", "/rank/v3-png/8.png", 1800, 1899),
            new(9, "Bronze 2", "/rank/v3-png/9.png", 1900, 1999),
            new(10, "Bronze 1", "/rank/v3-png/10.png", 2000, 2099),

            new(11, "Silver 5", "/rank/v3-png/11.png", 2100, 2199),
            new(12, "Silver 4", "/rank/v3-png/12.png", 2200, 2299),
            new(13, "Silver 3", "/rank/v3-png/13.png", 2300, 2399),
            new(14, "Silver 2", "/rank/v3-png/14.png", 2400, 2499),
            new(15, "Silver 1", "/rank/v3-png/15.png", 2500, 2599),

            new(16, "Gold 3", "/rank/v3-png/16.png", 2600, 2799),
            new(17, "Gold 2", "/rank/v3-png/17.png", 2800, 2999),
            new(18, "Gold 1", "/rank/v3-png/18.png", 3000, 3199),

            new(19, "Platinum 3", "/rank/v3-png/19.png", 3200, 3499),
            new(20, "Platinum 2", "/rank/v3-png/20.png", 3500, 3799),
            new(21, "Platinum 1", "/rank/v3-png/21.png", 3800, 4099),

            new(22, "Diamond 3", "/rank/v3-png/22.png", 4100, 4399),
            new(23, "Diamond 2", "/rank/v3-png/23.png", 4400, 4699),
            new(24, "Diamond 1", "/rank/v3-png/24.png", 4700, 4999),

            new(25, "Champion", "/rank/v3-png/25.png", 5000, null)
        };

        private static readonly RankInfo[] RankingV2 =
        {
            new(0, "Unranked", "/rank/v2-png/0.png", null, null),

            new(1, "Copper 5", "/rank/v2-png/1.png", null, 1199),
            new(2, "Copper 4", "/rank/v2-png/2.png", 1200, 1299),
            new(3, "Copper 3", "/rank/v2-png/3.png", 1300, 1399),
            new(4, "Copper 2", "/rank/v2-png/4.png", 1400, 1499),
            new(5, "Copper 1", "/rank/v2-png/5.png", 1500, 1599),

            new(6, "Bronze 5", "/rank/v2-png/6.png", 1600, 1699),
            new(7, "Bronze 4", "/rank/v2-png/7.png", 1700, 1799),
            new(8, "Bronze 3", "/rank/v2-png/8.png", 1800, 1899),
            new(9, "Bronze 2", "/rank/v2-png/9.png", 1900, 1999),
            new(10, "Bronze 1", "/rank/v2-png/10.png", 2000, 2099),

            new(11, "Silver 5", "/rank/v2-png/11.png", 2100, 2199),
            new(12, "Silver 4", "/rank/v2-png/12.png", 2200, 2299),
            new(13, "Silver 3", "/rank/v2-png/13.png", 2300, 2399),
            new(14, "Silver 2", "/rank/v2-png/14.png", 2400, 2499),
            new(15, "Silver 1", "/rank/v2-png/15.png", 2500, 2599),

            new(16, "Gold 3", "/rank/v2-png/16.png", 2600, 2799),
            new(17, "Gold 2", "/rank/v2-png/17.png", 2800, 2999),
            new(18, "Gold 1", "/rank/v2-png/18.png", 3000, 3199),

            new(19, "Platinum 3", "/rank/v2-png/19.png", 3200, 3599),
            new(20, "Platinum 2", "/rank/v2-png/20.png", 3600, 3999),
            new(21, "Platinum 1", "/rank/v2-png/21.png", 4000, 4399),

            new(22, "Diamond", "/rank/v2-png/22.png", 4400, 4999),
            new(23, "Champion", "/rank/v2-png/23.png", 5000, null)
        };

        private static readonly RankInfo[] RankingV1 =
        {
            new(0, "Unranked", "/rank/v1-png/0.png", null, null),

            new(1, "Copper 4", "/rank/v1-png/1.png", null, 1399),
            new(2, "Copper 3", "/rank/v1-png/2.png", 1400, 1499),
            new(3, "Copper 2", "/rank/v1-png/3.png", 1500, 1599),
            new(4, "Copper 1", "/rank/v1-png/4.png", 1600, 1699),

            new(5, "Bronze 4", "/rank/v1-png/5.png", 1700, 1799),
            new(6, "Bronze 3", "/rank/v1-png/6.png", 1800, 1899),
            new(7, "Bronze 2", "/rank/v1-png/7.png", 1900, 1999),
            new(8, "Bronze 1", "/rank/v1-png/8.png", 2000, 2099),

            new(9, "Silver 4", "/rank/v1-png/9.png", 2100, 2199),
            new(10, "Silver 3", "/rank/v1-png/10.png", 2200, 2299),
            new(11, "Silver 2", "/rank/v1-png/11.png", 2300, 2399),
            new(12, "Silver 1", "/rank/v1-png/12.png", 2400, 2499),

            new(13, "Gold 4", "/rank/v1-png/13.png", 2500, 2699),
            new(14, "Gold 3", "/rank/v1-png/14.png", 2700, 2899),
            new(15, "Gold 2", "/rank/v1-png/15.png", 2900, 3099),
            new(16, "Gold 1", "/rank/v1-png/16.png", 3100, 3299),

            new(17, "Platinum 3", "/rank/v1-png/17.png", 3300, 3699),
            new(18, "Platinum 2", "/rank/v1-png/18.png", 3700, 4099),
            new(19, "Platinum 1", "/rank/v1-png/19.png", 4100, 4499),

            new(20, "Diamond", "/rank/v1-png/20.png", 4500, null)
        };

        #endregion
    }
}
