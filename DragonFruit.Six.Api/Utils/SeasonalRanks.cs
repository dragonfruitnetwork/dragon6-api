// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Linq;
using DragonFruit.Six.Api.Containers;

namespace DragonFruit.Six.Api.Utils
{
    public static class SeasonalRanks
    {
        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the current rank based on id
        /// </summary>
        public static RankInfo GetFromId(int rankId, bool legacy = false) => GetRank(rankId, legacy);

        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the current rank based on the MMR value
        /// </summary>
        public static RankInfo GetFromMMR(int mmr, bool legacy = false) => GetRank(mmr, legacy, true);

        private static RankInfo GetRank(int identifier, bool isLegacyRanks = false, bool isMMR = false)
        {
            var itemsSource = isLegacyRanks ? LegacyRanks : Ranks;

            return isMMR switch
            {
                false => itemsSource.ElementAtOrDefault(identifier) ?? Ranks[0],
                true => itemsSource.Where(x => (x.MinMMR ?? int.MinValue) <= identifier && (x.MaxMMR ?? int.MaxValue) >= identifier).OrderByDescending(x => x.Id).First()
            };
        }

        #region Data Source

        private static readonly RankInfo[] Ranks =
        {
            new(0, "Unranked", "/rank/v2/0.svg", null, null),

            new(1, "Copper 5", "/rank/v2/1.svg", null, 1199),
            new(2, "Copper 4", "/rank/v2/2.svg", 1200, 1299),
            new(3, "Copper 3", "/rank/v2/3.svg", 1300, 1399),
            new(4, "Copper 2", "/rank/v2/4.svg", 1400, 1499),
            new(5, "Copper 1", "/rank/v2/5.svg", 1500, 1599),

            new(6, "Bronze 5", "/rank/v2/6.svg", 1600, 1699),
            new(7, "Bronze 4", "/rank/v2/7.svg", 1700, 1799),
            new(8, "Bronze 3", "/rank/v2/8.svg", 1800, 1899),
            new(9, "Bronze 2", "/rank/v2/9.svg", 1900, 1999),
            new(10, "Bronze 1", "/rank/v2/10.svg", 2000, 2099),

            new(11, "Silver 5", "/rank/v2/11.svg", 2100, 2199),
            new(12, "Silver 4", "/rank/v2/12.svg", 2200, 2299),
            new(13, "Silver 3", "/rank/v2/13.svg", 2300, 2399),
            new(14, "Silver 2", "/rank/v2/14.svg", 2400, 2499),
            new(15, "Silver 1", "/rank/v2/15.svg", 2500, 2599),

            new(16, "Gold 3", "/rank/v2/16.svg", 2600, 2799),
            new(17, "Gold 2", "/rank/v2/17.svg", 2800, 2999),
            new(18, "Gold 1", "/rank/v2/18.svg", 3000, 3199),

            new(19, "Platinum 3", "/rank/v2/19.svg", 3200, 3599),
            new(20, "Platinum 2", "/rank/v2/20.svg", 3600, 3999),
            new(21, "Platinum 1", "/rank/v2/21.svg", 4000, 4399),

            new(22, "Diamond", "/rank/v2/22.svg", 4400, 4999),
            new(23, "Champion", "/rank/v2/23.svg", 5000, null)
        };

        private static readonly RankInfo[] LegacyRanks =
        {
            new(0, "Unranked", "/rank/v1/0.svg", null, null),

            new(1, "Copper 4", "/rank/v1/1.svg", null, 1399),
            new(2, "Copper 3", "/rank/v1/2.svg", 1400, 1499),
            new(3, "Copper 2", "/rank/v1/3.svg", 1500, 1599),
            new(4, "Copper 1", "/rank/v1/4.svg", 1600, 1699),

            new(5, "Bronze 4", "/rank/v1/5.svg", 1700, 1799),
            new(6, "Bronze 3", "/rank/v1/6.svg", 1800, 1899),
            new(7, "Bronze 2", "/rank/v1/7.svg", 1900, 1999),
            new(8, "Bronze 1", "/rank/v1/8.svg", 2000, 2099),

            new(9, "Silver 4", "/rank/v1/9.svg", 2100, 2199),
            new(10, "Silver 3", "/rank/v1/10.svg", 2200, 2299),
            new(11, "Silver 2", "/rank/v1/11.svg", 2300, 2399),
            new(12, "Silver 1", "/rank/v1/12.svg", 2400, 2499),

            new(13, "Gold 4", "/rank/v1/13.svg", 2500, 2699),
            new(14, "Gold 3", "/rank/v1/14.svg", 2700, 2899),
            new(15, "Gold 2", "/rank/v1/15.svg", 2900, 3099),
            new(16, "Gold 1", "/rank/v1/16.svg", 3100, 3299),

            new(17, "Platinum 3", "/rank/v1/17.svg", 3300, 3699),
            new(18, "Platinum 2", "/rank/v1/18.svg", 3700, 4099),
            new(19, "Platinum 1", "/rank/v1/19.svg", 4100, 4499),

            new(20, "Diamond", "/rank/v1/20.svg", 4500, null)
        };

        #endregion
    }
}
