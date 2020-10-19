// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Globalization;
using DragonFruit.Six.API.Data.Containers;

namespace DragonFruit.Six.API
{
    public static class References
    {
        public static readonly CultureInfo Culture = new CultureInfo("en-US", false);

        public static RankContainer Ranks(int rank) => rank switch
        {
            1 => new RankContainer(1, "Copper 5", "/rank/v2/1.svg"),
            2 => new RankContainer(2, "Copper 4", "/rank/v2/2.svg"),
            3 => new RankContainer(3, "Copper 3", "/rank/v2/3.svg"),
            4 => new RankContainer(4, "Copper 2", "/rank/v2/4.svg"),
            5 => new RankContainer(5, "Copper 1", "/rank/v2/5.svg"),

            6 => new RankContainer(6, "Bronze 5", "/rank/v2/6.svg"),
            7 => new RankContainer(7, "Bronze 4", "/rank/v2/7.svg"),
            8 => new RankContainer(8, "Bronze 3", "/rank/v2/8.svg"),
            9 => new RankContainer(9, "Bronze 2", "/rank/v2/9.svg"),
            10 => new RankContainer(10, "Bronze 1", "/rank/v2/10.svg"),

            11 => new RankContainer(11, "Silver 5", "/rank/v2/11.svg"),
            12 => new RankContainer(12, "Silver 4", "/rank/v2/12.svg"),
            13 => new RankContainer(13, "Silver 3", "/rank/v2/13.svg"),
            14 => new RankContainer(14, "Silver 2", "/rank/v2/14.svg"),
            15 => new RankContainer(15, "Silver 1", "/rank/v2/15.svg"),

            16 => new RankContainer(16, "Gold 3", "/rank/v2/16.svg"),
            17 => new RankContainer(17, "Gold 2", "/rank/v2/17.svg"),
            18 => new RankContainer(18, "Gold 1", "/rank/v2/18.svg"),

            19 => new RankContainer(19, "Platinum 3", "/rank/v2/19.svg"),
            20 => new RankContainer(20, "Platinum 2", "/rank/v2/20.svg"),
            21 => new RankContainer(21, "Platinum 1", "/rank/v2/21.svg"),

            22 => new RankContainer(22, "Diamond", "/rank/v2/22.svg"),
            23 => new RankContainer(23, "Champion", "/rank/v2/23.svg"),

            _ => new RankContainer(0, "Unranked", "/rank/v2/0.svg")
        };

        public static RankContainer LegacyRanks(int legacyRank) => legacyRank switch
        {
            1 => new RankContainer(1, "Copper 4", "/rank/v1/1.svg"),
            2 => new RankContainer(2, "Copper 3", "/rank/v1/2.svg"),
            3 => new RankContainer(3, "Copper 2", "/rank/v1/3.svg"),
            4 => new RankContainer(4, "Copper 1", "/rank/v1/4.svg"),

            5 => new RankContainer(5, "Bronze 4", "/rank/v1/5.svg"),
            6 => new RankContainer(6, "Bronze 3", "/rank/v1/6.svg"),
            7 => new RankContainer(7, "Bronze 2", "/rank/v1/7.svg"),
            8 => new RankContainer(8, "Bronze 1", "/rank/v1/8.svg"),

            9 => new RankContainer(9, "Silver 4", "/rank/v1/9.svg"),
            10 => new RankContainer(10, "Silver 3", "/rank/v1/10.svg"),
            11 => new RankContainer(11, "Silver 2", "/rank/v1/11.svg"),
            12 => new RankContainer(12, "Silver 1", "/rank/v1/12.svg"),

            13 => new RankContainer(13, "Gold 4", "/rank/v1/13.svg"),
            14 => new RankContainer(14, "Gold 3", "/rank/v1/14.svg"),
            15 => new RankContainer(15, "Gold 2", "/rank/v1/15.svg"),
            16 => new RankContainer(16, "Gold 1", "/rank/v1/16.svg"),

            17 => new RankContainer(17, "Platinum 3", "/rank/v1/17.svg"),
            18 => new RankContainer(18, "Platinum 2", "/rank/v1/18.svg"),
            19 => new RankContainer(19, "Platinum 1", "/rank/v1/19.svg"),

            20 => new RankContainer(20, "Diamond", "/rank/v1/20.svg"),

            _ => new RankContainer(0, "Unranked", "/rank/v1/0.svg")
        };
    }
}
