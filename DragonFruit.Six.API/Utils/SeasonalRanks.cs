// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Containers;

namespace DragonFruit.Six.API.Utils
{
    public static class SeasonalRanks
    {
        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the user rank
        /// </summary>
        public static RankInfo Rank(int rankId) => rankId switch
        {
            1 => new RankInfo(1, "Copper 5", "/rank/v2/1.svg"),
            2 => new RankInfo(2, "Copper 4", "/rank/v2/2.svg"),
            3 => new RankInfo(3, "Copper 3", "/rank/v2/3.svg"),
            4 => new RankInfo(4, "Copper 2", "/rank/v2/4.svg"),
            5 => new RankInfo(5, "Copper 1", "/rank/v2/5.svg"),

            6 => new RankInfo(6, "Bronze 5", "/rank/v2/6.svg"),
            7 => new RankInfo(7, "Bronze 4", "/rank/v2/7.svg"),
            8 => new RankInfo(8, "Bronze 3", "/rank/v2/8.svg"),
            9 => new RankInfo(9, "Bronze 2", "/rank/v2/9.svg"),
            10 => new RankInfo(10, "Bronze 1", "/rank/v2/10.svg"),

            11 => new RankInfo(11, "Silver 5", "/rank/v2/11.svg"),
            12 => new RankInfo(12, "Silver 4", "/rank/v2/12.svg"),
            13 => new RankInfo(13, "Silver 3", "/rank/v2/13.svg"),
            14 => new RankInfo(14, "Silver 2", "/rank/v2/14.svg"),
            15 => new RankInfo(15, "Silver 1", "/rank/v2/15.svg"),

            16 => new RankInfo(16, "Gold 3", "/rank/v2/16.svg"),
            17 => new RankInfo(17, "Gold 2", "/rank/v2/17.svg"),
            18 => new RankInfo(18, "Gold 1", "/rank/v2/18.svg"),

            19 => new RankInfo(19, "Platinum 3", "/rank/v2/19.svg"),
            20 => new RankInfo(20, "Platinum 2", "/rank/v2/20.svg"),
            21 => new RankInfo(21, "Platinum 1", "/rank/v2/21.svg"),

            22 => new RankInfo(22, "Diamond", "/rank/v2/22.svg"),
            23 => new RankInfo(23, "Champion", "/rank/v2/23.svg"),

            _ => new RankInfo(0, "Unranked", "/rank/v2/0.svg")
        };

        /// <summary>
        /// Gets the <see cref="RankInfo"/> for the user rank (pre-season 15)
        /// </summary>
        public static RankInfo Legacy(int legacyRankId) => legacyRankId switch
        {
            1 => new RankInfo(1, "Copper 4", "/rank/v1/1.svg"),
            2 => new RankInfo(2, "Copper 3", "/rank/v1/2.svg"),
            3 => new RankInfo(3, "Copper 2", "/rank/v1/3.svg"),
            4 => new RankInfo(4, "Copper 1", "/rank/v1/4.svg"),

            5 => new RankInfo(5, "Bronze 4", "/rank/v1/5.svg"),
            6 => new RankInfo(6, "Bronze 3", "/rank/v1/6.svg"),
            7 => new RankInfo(7, "Bronze 2", "/rank/v1/7.svg"),
            8 => new RankInfo(8, "Bronze 1", "/rank/v1/8.svg"),

            9 => new RankInfo(9, "Silver 4", "/rank/v1/9.svg"),
            10 => new RankInfo(10, "Silver 3", "/rank/v1/10.svg"),
            11 => new RankInfo(11, "Silver 2", "/rank/v1/11.svg"),
            12 => new RankInfo(12, "Silver 1", "/rank/v1/12.svg"),

            13 => new RankInfo(13, "Gold 4", "/rank/v1/13.svg"),
            14 => new RankInfo(14, "Gold 3", "/rank/v1/14.svg"),
            15 => new RankInfo(15, "Gold 2", "/rank/v1/15.svg"),
            16 => new RankInfo(16, "Gold 1", "/rank/v1/16.svg"),

            17 => new RankInfo(17, "Platinum 3", "/rank/v1/17.svg"),
            18 => new RankInfo(18, "Platinum 2", "/rank/v1/18.svg"),
            19 => new RankInfo(19, "Platinum 1", "/rank/v1/19.svg"),

            20 => new RankInfo(20, "Diamond", "/rank/v1/20.svg"),

            _ => new RankInfo(0, "Unranked", "/rank/v1/0.svg")
        };
    }
}
