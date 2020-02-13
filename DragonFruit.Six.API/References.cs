// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Stats;

namespace DragonFruit.Six.API
{
    public enum Platforms
    {
        PC = 1,
        PSN = 2,
        XB1 = 3
    }

    public enum LookupMethod
    {
        /// <summary>
        /// Player's name
        /// </summary>
        Name,

        /// <summary>
        /// The User ID, which is global across different ubi games
        /// </summary>
        UserId,

        /// <summary>
        /// Id on the platform, not always the same as the GUID
        /// </summary>
        PlatformId
    }

    public enum OperatorType
    {
        /// <summary>
        /// Attacker or Defender (i.e. Recruit)
        /// </summary>
        Independent = 0,

        /// <summary>
        /// Attacking Operator
        /// </summary>
        Attacker = 1,

        /// <summary>
        /// Defending Operator
        /// </summary>
        Defender = 2
    }

    public static class References
    {
        /// <summary>
        /// Regions for ranked
        /// </summary>
        public static readonly string[] Regions =
        {
            "EMEA",
            "APAC",
            "NCSA"
        };

        /// <summary>
        /// Used for <see cref="LoginInfo"/>
        /// </summary>
        public static readonly Dictionary<Platforms, string> GameIds =
            new Dictionary<Platforms, string>
            {
                [Platforms.PSN] = "fb4cc4c9-2063-461d-a1e8-84a7d36525fc",
                [Platforms.XB1] = "4008612d-3baf-49e4-957a-33066726a7bc",
                [Platforms.PC] = "e3d5ea9e-50bd-43b7-88bf-39794f4e3d40"
            };

        /// <summary>
        /// English Versions of Rank ID -> Names (for operations prior to ember rise)
        /// </summary>
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
        /// English Names of Weapon Types
        /// </summary>
        public static readonly IReadOnlyDictionary<byte, string> WeaponClasses = new Dictionary<byte, string>
        {
            { 1, "Assault Rifle" },
            { 2, "SMG" },
            { 3, "LMG" },
            { 4, "Marksman Rifle" },
            { 5, "Handgun" },
            { 6, "Shotgun" },
            { 7, "Machine Pistol" }
        };
    }
}
