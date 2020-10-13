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

        private static readonly string[] Ranks =
        {
            "Unranked",
            "Copper 5","Copper 4","Copper 3","Copper 2","Copper 1",
            "Bronze 5","Bronze 4","Bronze 3","Bronze 2","Bronze 1",
            "Silver 5","Silver 4","Silver 3","Silver 2","Silver 1",
            "Gold 4","Gold 3","Gold 2","Gold 1",
            "Platinum 3","Platinum 2","Platinum 1",
            "Diamond",
            "Champion",

        };

        public static RankContainer RankAssigned(int id, string type)
        {
            if (type == "LegacyRank" || type == "Rank")
            {
                // Searches for id
                // If found then sets the rank name and url depending on the type of rank (i.e. "Rank" or "LegacyRank")
                return id switch
                {
                    0 => new RankContainer(0, Ranks[0], type == "LegacyRank" ? "/rank/v1/0.svg" : "/rank/v2/0.svg"),
                    1 => new RankContainer(1, type == "LegacyRank" ? Ranks[2] : Ranks[1], type == "LegacyRank" ? "/rank/v1/1.svg" : "/rank/v2/1.svg"),
                    2 => new RankContainer(2, type == "LegacyRank" ? Ranks[3] : Ranks[2], type == "LegacyRank" ? "/rank/v1/2.svg" : "/rank/v2/2.svg"),
                    3 => new RankContainer(3, type == "LegacyRank" ? Ranks[4] : Ranks[3], type == "LegacyRank" ? "/rank/v1/3.svg" : "/rank/v2/3.svg"),
                    4 => new RankContainer(4, type == "LegacyRank" ? Ranks[5] : Ranks[4], type == "LegacyRank" ? "/rank/v1/4.svg" : "/rank/v2/4.svg"),
                    5 => new RankContainer(5, type == "LegacyRank" ? Ranks[7] : Ranks[5], type == "LegacyRank" ? "/rank/v1/5.svg" : "/rank/v2/5.svg"),
                    6 => new RankContainer(6, type == "LegacyRank" ? Ranks[8] : Ranks[6], type == "LegacyRank" ? "/rank/v1/6.svg" : "/rank/v2/6.svg"),
                    7 => new RankContainer(7, type == "LegacyRank" ? Ranks[9] : Ranks[7], type == "LegacyRank" ? "/rank/v1/7.svg" : "/rank/v2/7.svg"),
                    8 => new RankContainer(8, type == "LegacyRank" ? Ranks[10] : Ranks[8], type == "LegacyRank" ? "/rank/v1/8.svg" : "/rank/v2/8.svg"),
                    9 => new RankContainer(9, type == "LegacyRank" ? Ranks[12] : Ranks[9], type == "LegacyRank" ? "/rank/v1/9.svg" : "/rank/v2/9.svg"),
                    10 => new RankContainer(10, type == "LegacyRank" ? Ranks[13] : Ranks[10], type == "LegacyRank" ? "/rank/v1/10.svg" : "/rank/v2/10.svg"),
                    11 => new RankContainer(11, type == "LegacyRank" ? Ranks[14] : Ranks[11], type == "LegacyRank" ? "/rank/v1/11.svg" : "/rank/v2/11.svg"),
                    12 => new RankContainer(12, type == "LegacyRank" ? Ranks[15] : Ranks[12], type == "LegacyRank" ? "/rank/v1/12.svg" : "rank /v2/12.svg"),
                    13 => new RankContainer(13, type == "LegacyRank" ? Ranks[16] : Ranks[13], type == "LegacyRank" ? "/rank/v1/13.svg" : "/rank/v2/13.svg"),
                    14 => new RankContainer(14, type == "LegacyRank" ? Ranks[17] : Ranks[14], type == "LegacyRank" ? "/rank/v1/14.svg" : "/rank/v2/14.svg"),
                    15 => new RankContainer(15, type == "LegacyRank" ? Ranks[18] : Ranks[15], type == "LegacyRank" ? "/rank/v1/15.svg" : "/rank/v2/15.svg"),
                    16 => new RankContainer(16, type == "LegacyRank" ? Ranks[19] : Ranks[17], type == "LegacyRank" ? "/rank/v1/16.svg" : "/rank/v2/16.svg"),
                    17 => new RankContainer(17, type == "LegacyRank" ? Ranks[20] : Ranks[18], type == "LegacyRank" ? "/rank/v1/17.svg" : "/rank/v2/17.svg"),
                    18 => new RankContainer(18, type == "LegacyRank" ? Ranks[21] : Ranks[19], type == "LegacyRank" ? "/rank/v1/18.svg" : "/rank/v2/18.svg"),
                    19 => new RankContainer(19, type == "LegacyRank" ? Ranks[22] : Ranks[20], type == "LegacyRank" ? "/rank/v1/19.svg" : "/rank/v2/19.svg"),
                    20 => new RankContainer(20, type == "LegacyRank" ? Ranks[23] : Ranks[21], type == "LegacyRank" ? "/rank/v1/20.svg" : "/rank/v2/20.svg"),
                    21 => new RankContainer(21, Ranks[22], "/rank/v2/21.svg"),
                    22 => new RankContainer(22, Ranks[23], "/rank/v2/22.svg"),
                    23 => new RankContainer(23, Ranks[24], "/rank/v2/23.svg"),
                    _ => null
                };
            }
            else
            {
                return null;
            }
        }

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
