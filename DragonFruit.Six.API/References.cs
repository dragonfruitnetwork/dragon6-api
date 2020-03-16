// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Globalization;

namespace DragonFruit.Six.API
{
    public static class References
    {
        public static readonly CultureInfo Culture = new CultureInfo("en-US", false);

        /// <summary>
        /// English Versions of Rank ID -> Names (for operations prior to ember rise)
        /// </summary>
        [Obsolete("LegacyRankNames dictionary is deprecated, please use LegacyRanks dictionary instead.")]
        public static readonly IReadOnlyDictionary<uint, string> LegacyRankNames = new Dictionary<uint, string>
        {
            { 0, "Unranked" },

            { 1, "Copper 4" },
            { 2, "Copper 3" },
            { 3, "Copper 2" },
            { 4, "Copper 1" },

            { 5, "Bronze 4" },
            { 6, "Bronze 3" },
            { 7, "Bronze 2" },
            { 8, "Bronze 1" },

            { 9, "Silver 4" },
            { 10, "Silver 3" },
            { 11, "Silver 2" },
            { 12, "Silver 1" },

            { 13, "Gold 4" },
            { 14, "Gold 3" },
            { 15, "Gold 2" },
            { 16, "Gold 1" },

            { 17, "Platinum 3" },
            { 18, "Platinum 2" },
            { 19, "Platinum 1" },

            { 20, "Diamond" }
        };

        /// <summary>
        /// English Versions of Rank ID -> Names
        /// </summary>
        [Obsolete("RankNames dictionary is deprecated, please use Ranks dictionary instead.")]
        public static readonly IReadOnlyDictionary<uint, string> RankNames = new Dictionary<uint, string>
        {
            { 0, "Unranked" },

            { 1, "Copper 5" },
            { 2, "Copper 4" },
            { 3, "Copper 3" },
            { 4, "Copper 2" },
            { 5, "Copper 1" },

            { 6, "Bronze 5" },
            { 7, "Bronze 4" },
            { 8, "Bronze 3" },
            { 9, "Bronze 2" },
            { 10, "Bronze 1" },

            { 11, "Silver 5" },
            { 12, "Silver 4" },
            { 13, "Silver 3" },
            { 14, "Silver 2" },
            { 15, "Silver 1" },

            { 16, "Gold 3" },
            { 17, "Gold 2" },
            { 18, "Gold 1" },

            { 19, "Platinum 3" },
            { 20, "Platinum 2" },
            { 21, "Platinum 1" },

            { 22, "Diamond" },

            { 23, "Champion" }
        };

        /// <summary>
        /// Weapon Types
        /// </summary>
        public static readonly IReadOnlyDictionary<byte, string> WeaponClasses = new Dictionary<byte, string>
        {
            { 1, "Assault Rifle" },
            { 2, "SMG" },
            { 3, "LMG" },
            { 4, "Sniper Rifle" },
            { 5, "Pistol" },
            { 6, "Shotgun" },
            { 7, "Machine Pistol" },
            { 8, "Shield" },
            { 9, "Launcher" }
        };

        /// <summary>
        /// Ranks
        /// </summary>
        public static readonly IReadOnlyDictionary<uint, Rank> Ranks = new Dictionary<uint, Rank>
        {
            { 0, new Rank(0, "Unranked", "https://d6static.dragonfruit.network/rank/v2/0.svg") },

            { 1, new Rank(1, "Copper 5", "https://d6static.dragonfruit.network/rank/v2/1.svg") },
            { 2, new Rank(2, "Copper 4", "https://d6static.dragonfruit.network/rank/v2/2.svg") },
            { 3, new Rank(3, "Copper 3", "https://d6static.dragonfruit.network/rank/v2/3.svg") },
            { 4, new Rank(4, "Copper 2", "https://d6static.dragonfruit.network/rank/v2/4.svg") },
            { 5, new Rank(5, "Copper 1", "https://d6static.dragonfruit.network/rank/v2/5.svg") },

            { 6, new Rank(6, "Bronze 5", "https://d6static.dragonfruit.network/rank/v2/6.svg") },
            { 7, new Rank(7, "Bronze 4", "https://d6static.dragonfruit.network/rank/v2/7.svg") },
            { 8, new Rank(8, "Bronze 3", "https://d6static.dragonfruit.network/rank/v2/8.svg") },
            { 9, new Rank(9, "Bronze 2", "https://d6static.dragonfruit.network/rank/v2/9.svg") },
            { 10, new Rank(10, "Bronze 1", "https://d6static.dragonfruit.network/rank/v2/10.svg") },

            { 11, new Rank(11, "Silver 5", "https://d6static.dragonfruit.network/rank/v2/11.svg") },
            { 12, new Rank(12, "Silver 4", "https://d6static.dragonfruit.network/rank/v2/12.svg") },
            { 13, new Rank(13, "Silver 3", "https://d6static.dragonfruit.network/rank/v2/13.svg") },
            { 14, new Rank(14, "Silver 2", "https://d6static.dragonfruit.network/rank/v2/14.svg") },
            { 15, new Rank(15, "Silver 1", "https://d6static.dragonfruit.network/rank/v2/15.svg") },

            { 16, new Rank(16, "Gold 3", "https://d6static.dragonfruit.network/rank/v2/16.svg") },
            { 17, new Rank(17, "Gold 2", "https://d6static.dragonfruit.network/rank/v2/17.svg") },
            { 18, new Rank(18, "Gold 1", "https://d6static.dragonfruit.network/rank/v2/18.svg") },

            { 19, new Rank(19, "Platinum 3", "https://d6static.dragonfruit.network/rank/v2/19.svg") },
            { 20, new Rank(20, "Platinum 2", "https://d6static.dragonfruit.network/rank/v2/20.svg") },
            { 21, new Rank(21, "Platinum 1", "https://d6static.dragonfruit.network/rank/v2/21.svg") },

            { 22, new Rank(22, "Diamond", "https://d6static.dragonfruit.network/rank/v2/22.svg") },
            { 23, new Rank(23, "Champion", "https://d6static.dragonfruit.network/rank/v2/23.svg") },
        };

        /// <summary>
        /// LegacyRanks
        /// </summary>
        public static readonly IReadOnlyDictionary<uint, Rank> LegacyRanks = new Dictionary<uint, Rank>
        {
            { 0, new Rank(0, "Unranked", "https://d6static.dragonfruit.network/rank/v1/0.svg") },

            { 1, new Rank(1, "Copper 4", "https://d6static.dragonfruit.network/rank/v1/1.svg") },
            { 2, new Rank(2, "Copper 3", "https://d6static.dragonfruit.network/rank/v1/2.svg") },
            { 3, new Rank(3, "Copper 2", "https://d6static.dragonfruit.network/rank/v1/3.svg") },
            { 4, new Rank(4, "Copper 1", "https://d6static.dragonfruit.network/rank/v1/4.svg") },

            { 5, new Rank(5, "Bronze 4", "https://d6static.dragonfruit.network/rank/v1/5.svg") },
            { 6, new Rank(6, "Bronze 3", "https://d6static.dragonfruit.network/rank/v1/6.svg") },
            { 7, new Rank(7, "Bronze 2", "https://d6static.dragonfruit.network/rank/v1/7.svg") },
            { 8, new Rank(8, "Bronze 1", "https://d6static.dragonfruit.network/rank/v1/8.svg") },

            { 9, new Rank(9, "Silver 4", "https://d6static.dragonfruit.network/rank/v1/9.svg") },
            { 10, new Rank(10, "Silver 3", "https://d6static.dragonfruit.network/rank/v1/10.svg") },
            { 11, new Rank(11, "Silver 2", "https://d6static.dragonfruit.network/rank/v1/11.svg") },
            { 12, new Rank(12, "Silver 1", "https://d6static.dragonfruit.network/rank/v1/12.svg") },

            { 13, new Rank(13, "Gold 4", "https://d6static.dragonfruit.network/rank/v1/13.svg") },
            { 14, new Rank(14, "Gold 3", "https://d6static.dragonfruit.network/rank/v1/14.svg") },
            { 15, new Rank(15, "Gold 2", "https://d6static.dragonfruit.network/rank/v1/15.svg") },
            { 16, new Rank(16, "Gold 1", "https://d6static.dragonfruit.network/rank/v1/16.svg") },

            { 17, new Rank(17, "Platinum 3", "https://d6static.dragonfruit.network/rank/v1/17.svg") },
            { 18, new Rank(18, "Platinum 2", "https://d6static.dragonfruit.network/rank/v1/18.svg") },
            { 19, new Rank(19, "Platinum 1", "https://d6static.dragonfruit.network/rank/v1/19.svg") },

            { 20, new Rank(20, "Diamond", "https://d6static.dragonfruit.network/rank/v1/20.svg") },
        };
    }

    public class Rank
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }

        public Rank(uint _id, string _name, string _iconUrl)
        {
            Id = _id;
            Name = _name;
            IconUrl = _iconUrl;
        }
    }
}
