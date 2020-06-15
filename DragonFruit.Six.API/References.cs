// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Globalization;
using DragonFruit.Six.API.Data.Containers;

namespace DragonFruit.Six.API
{
    public static class References
    {
        public static readonly CultureInfo Culture = new CultureInfo("en-US", false);

        #region Dictionaries

        public static readonly IReadOnlyDictionary<byte, string> WeaponClasses
            = new Dictionary<byte, string>
            {
                [1] = "Assault Rifle",
                [2] = "SMG",
                [3] = "LMG",
                [4] = "Sniper Rifle",
                [5] = "Pistol",
                [6] = "Shotgun",
                [7] = "Machine Pistol",
                [8] = "Shield",
                [9] = "Launcher"
            };

        public static readonly IEnumerable<RankContainer> Ranks = new RankContainer[]
        {
            new RankContainer(0, "Unranked", "/rank/v2/0.svg"),

            new RankContainer(1, "Copper 5", "/rank/v2/1.svg"),
            new RankContainer(2, "Copper 4", "/rank/v2/2.svg"),
            new RankContainer(3, "Copper 3", "/rank/v2/3.svg"),
            new RankContainer(4, "Copper 2", "/rank/v2/4.svg"),
            new RankContainer(5, "Copper 1", "/rank/v2/5.svg"),

            new RankContainer(6, "Bronze 5", "/rank/v2/6.svg"),
            new RankContainer(7, "Bronze 4", "/rank/v2/7.svg"),
            new RankContainer(8, "Bronze 3", "/rank/v2/8.svg"),
            new RankContainer(9, "Bronze 2", "/rank/v2/9.svg"),
            new RankContainer(10, "Bronze 1", "/rank/v2/10.svg"),

            new RankContainer(11, "Silver 5", "/rank/v2/11.svg"),
            new RankContainer(12, "Silver 4", "/rank/v2/12.svg"),
            new RankContainer(13, "Silver 3", "/rank/v2/13.svg"),
            new RankContainer(14, "Silver 2", "/rank/v2/14.svg"),
            new RankContainer(15, "Silver 1", "/rank/v2/15.svg"),

            new RankContainer(16, "Gold 3", "/rank/v2/16.svg"),
            new RankContainer(17, "Gold 2", "/rank/v2/17.svg"),
            new RankContainer(18, "Gold 1", "/rank/v2/18.svg"),

            new RankContainer(19, "Platinum 3", "/rank/v2/19.svg"),
            new RankContainer(20, "Platinum 2", "/rank/v2/20.svg"),
            new RankContainer(21, "Platinum 1", "/rank/v2/21.svg"),

            new RankContainer(22, "Diamond", "/rank/v2/22.svg"),
            new RankContainer(23, "Champion", "/rank/v2/23.svg"),
        };

        public static readonly IEnumerable<RankContainer> LegacyRanks = new RankContainer[]
        {
            new RankContainer(0, "Unranked", "/rank/v1/0.svg"),

            new RankContainer(1, "Copper 4", "/rank/v1/1.svg"),
            new RankContainer(2, "Copper 3", "/rank/v1/2.svg"),
            new RankContainer(3, "Copper 2", "/rank/v1/3.svg"),
            new RankContainer(4, "Copper 1", "/rank/v1/4.svg"),

            new RankContainer(5, "Bronze 4", "/rank/v1/5.svg"),
            new RankContainer(6, "Bronze 3", "/rank/v1/6.svg"),
            new RankContainer(7, "Bronze 2", "/rank/v1/7.svg"),
            new RankContainer(8, "Bronze 1", "/rank/v1/8.svg"),

            new RankContainer(9, "Silver 4", "/rank/v1/9.svg"),
            new RankContainer(10, "Silver 3", "/rank/v1/10.svg"),
            new RankContainer(11, "Silver 2", "/rank/v1/11.svg"),
            new RankContainer(12, "Silver 1", "/rank/v1/12.svg"),

            new RankContainer(13, "Gold 4", "/rank/v1/13.svg"),
            new RankContainer(14, "Gold 3", "/rank/v1/14.svg"),
            new RankContainer(15, "Gold 2", "/rank/v1/15.svg"),
            new RankContainer(16, "Gold 1", "/rank/v1/16.svg"),

            new RankContainer(17, "Platinum 3", "/rank/v1/17.svg"),
            new RankContainer(18, "Platinum 2", "/rank/v1/18.svg"),
            new RankContainer(19, "Platinum 1", "/rank/v1/19.svg"),

            new RankContainer(20, "Diamond", "/rank/v1/20.svg"),
        };

        #endregion

        #region Obsolete Dictionaries

        [Obsolete("LegacyRankNames dictionary is deprecated, please use LegacyRanks dictionary instead.")]
        public static readonly IReadOnlyDictionary<uint, string> LegacyRankNames
            = new Dictionary<uint, string>
            {
                [0] = "Unranked",

                [1] = "Copper 4",
                [2] = "Copper 3",
                [3] = "Copper 2",
                [4] = "Copper 1",

                [5] = "Bronze 4",
                [6] = "Bronze 3",
                [7] = "Bronze 2",
                [8] = "Bronze 1",

                [9] = "Silver 4",
                [10] = "Silver 3",
                [11] = "Silver 2",
                [12] = "Silver 1",

                [13] = "Gold 4",
                [14] = "Gold 3",
                [15] = "Gold 2",
                [16] = "Gold 1",

                [17] = "Platinum 3",
                [18] = "Platinum 2",
                [19] = "Platinum 1",

                [20] = "Diamond"
            };

        [Obsolete("RankNames dictionary is deprecated, please use Ranks dictionary instead.")]
        public static readonly IReadOnlyDictionary<uint, string> RankNames
            = new Dictionary<uint, string>
            {
                [0] = "Unranked",

                [1] = "Copper 5",
                [2] = "Copper 4",
                [3] = "Copper 3",
                [4] = "Copper 2",
                [5] = "Copper 1",

                [6] = "Bronze 5",
                [7] = "Bronze 4",
                [8] = "Bronze 3",
                [9] = "Bronze 2",
                [10] = "Bronze 1",

                [11] = "Silver 5",
                [12] = "Silver 4",
                [13] = "Silver 3",
                [14] = "Silver 2",
                [15] = "Silver 1",

                [16] = "Gold 3",
                [17] = "Gold 2",
                [18] = "Gold 1",

                [19] = "Platinum 3",
                [20] = "Platinum 2",
                [21] = "Platinum 1",

                [22] = "Diamond",

                [23] = "Champion"
            };

        #endregion
    }
}
