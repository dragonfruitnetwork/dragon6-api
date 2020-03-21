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
        internal const string AppId = "39baebad-39e5-4552-8c25-2c9b919064e2";

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

        public static readonly IReadOnlyDictionary<uint, RankContainer> Ranks
            = new Dictionary<uint, RankContainer>
            {
                [0] = new RankContainer(0, "Unranked", "https://d6static.dragonfruit.network/rank/v2/0.svg"),

                [1] = new RankContainer(1, "Copper 5", "https://d6static.dragonfruit.network/rank/v2/1.svg"),
                [2] = new RankContainer(2, "Copper 4", "https://d6static.dragonfruit.network/rank/v2/2.svg"),
                [3] = new RankContainer(3, "Copper 3", "https://d6static.dragonfruit.network/rank/v2/3.svg"),
                [4] = new RankContainer(4, "Copper 2", "https://d6static.dragonfruit.network/rank/v2/4.svg"),
                [5] = new RankContainer(5, "Copper 1", "https://d6static.dragonfruit.network/rank/v2/5.svg"),

                [6] = new RankContainer(6, "Bronze 5", "https://d6static.dragonfruit.network/rank/v2/6.svg"),
                [7] = new RankContainer(7, "Bronze 4", "https://d6static.dragonfruit.network/rank/v2/7.svg"),
                [8] = new RankContainer(8, "Bronze 3", "https://d6static.dragonfruit.network/rank/v2/8.svg"),
                [9] = new RankContainer(9, "Bronze 2", "https://d6static.dragonfruit.network/rank/v2/9.svg"),
                [10] = new RankContainer(10, "Bronze 1", "https://d6static.dragonfruit.network/rank/v2/10.svg"),

                [11] = new RankContainer(11, "Silver 5", "https://d6static.dragonfruit.network/rank/v2/11.svg"),
                [12] = new RankContainer(12, "Silver 4", "https://d6static.dragonfruit.network/rank/v2/12.svg"),
                [13] = new RankContainer(13, "Silver 3", "https://d6static.dragonfruit.network/rank/v2/13.svg"),
                [14] = new RankContainer(14, "Silver 2", "https://d6static.dragonfruit.network/rank/v2/14.svg"),
                [15] = new RankContainer(15, "Silver 1", "https://d6static.dragonfruit.network/rank/v2/15.svg"),

                [16] = new RankContainer(16, "Gold 3", "https://d6static.dragonfruit.network/rank/v2/16.svg"),
                [17] = new RankContainer(17, "Gold 2", "https://d6static.dragonfruit.network/rank/v2/17.svg"),
                [18] = new RankContainer(18, "Gold 1", "https://d6static.dragonfruit.network/rank/v2/18.svg"),

                [19] = new RankContainer(19, "Platinum 3", "https://d6static.dragonfruit.network/rank/v2/19.svg"),
                [20] = new RankContainer(20, "Platinum 2", "https://d6static.dragonfruit.network/rank/v2/20.svg"),
                [21] = new RankContainer(21, "Platinum 1", "https://d6static.dragonfruit.network/rank/v2/21.svg"),

                [22] = new RankContainer(22, "Diamond", "https://d6static.dragonfruit.network/rank/v2/22.svg"),
                [23] = new RankContainer(23, "Champion", "https://d6static.dragonfruit.network/rank/v2/23.svg"),
            };

        public static readonly IReadOnlyDictionary<uint, RankContainer> LegacyRanks
            = new Dictionary<uint, RankContainer>
            {
                [0] = new RankContainer(0, "Unranked", "https://d6static.dragonfruit.network/rank/v1/0.svg"),

                [1] = new RankContainer(1, "Copper 4", "https://d6static.dragonfruit.network/rank/v1/1.svg"),
                [2] = new RankContainer(2, "Copper 3", "https://d6static.dragonfruit.network/rank/v1/2.svg"),
                [3] = new RankContainer(3, "Copper 2", "https://d6static.dragonfruit.network/rank/v1/3.svg"),
                [4] = new RankContainer(4, "Copper 1", "https://d6static.dragonfruit.network/rank/v1/4.svg"),

                [5] = new RankContainer(5, "Bronze 4", "https://d6static.dragonfruit.network/rank/v1/5.svg"),
                [6] = new RankContainer(6, "Bronze 3", "https://d6static.dragonfruit.network/rank/v1/6.svg"),
                [7] = new RankContainer(7, "Bronze 2", "https://d6static.dragonfruit.network/rank/v1/7.svg"),
                [8] = new RankContainer(8, "Bronze 1", "https://d6static.dragonfruit.network/rank/v1/8.svg"),

                [9] = new RankContainer(9, "Silver 4", "https://d6static.dragonfruit.network/rank/v1/9.svg"),
                [10] = new RankContainer(10, "Silver 3", "https://d6static.dragonfruit.network/rank/v1/10.svg"),
                [11] = new RankContainer(11, "Silver 2", "https://d6static.dragonfruit.network/rank/v1/11.svg"),
                [12] = new RankContainer(12, "Silver 1", "https://d6static.dragonfruit.network/rank/v1/12.svg"),

                [13] = new RankContainer(13, "Gold 4", "https://d6static.dragonfruit.network/rank/v1/13.svg"),
                [14] = new RankContainer(14, "Gold 3", "https://d6static.dragonfruit.network/rank/v1/14.svg"),
                [15] = new RankContainer(15, "Gold 2", "https://d6static.dragonfruit.network/rank/v1/15.svg"),
                [16] = new RankContainer(16, "Gold 1", "https://d6static.dragonfruit.network/rank/v1/16.svg"),

                [17] = new RankContainer(17, "Platinum 3", "https://d6static.dragonfruit.network/rank/v1/17.svg"),
                [18] = new RankContainer(18, "Platinum 2", "https://d6static.dragonfruit.network/rank/v1/18.svg"),
                [19] = new RankContainer(19, "Platinum 1", "https://d6static.dragonfruit.network/rank/v1/19.svg"),

                [20] = new RankContainer(20, "Diamond", "https://d6static.dragonfruit.network/rank/v1/20.svg"),
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
