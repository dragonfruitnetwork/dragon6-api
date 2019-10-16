using System.Collections.Generic;

namespace Dragon6.API
{
    public class References
    {
        public enum Platforms
        {
            PC = 1,
            PSN = 2,
            XB1 = 3
        }

        public static string[] Regions =
        {
            "EMEA",
            "APAC",
            "NCSA"
        };

        /// <summary>
        /// English Versions of Rank ID -> Names (for operations prior to ember rise)
        /// </summary>
        public static readonly Dictionary<int, string> LegacyRankNames = new Dictionary<int, string>

        /// <summary>
        /// English Versions of Rank ID -> Names
        /// </summary>
        public static readonly Dictionary<int, string> RankNames = new Dictionary<int, string>
        {
            {0, "Unranked"},

            {1, "Copper 5"},
            {2, "Copper 4"},
            {3, "Copper 3"},
            {4, "Copper 2"},
            {5, "Copper 1"},

            {6, "Bronze 5"},
            {7, "Bronze 4"},
            {8, "Bronze 3"},
            {9, "Bronze 2"},
            {10, "Bronze 1"},

            {11, "Silver 5"},
            {12, "Silver 4"},
            {13, "Silver 3"},
            {14, "Silver 2"},
            {15, "Silver 1"},

            {16, "Gold 3"},
            {17, "Gold 2"},
            {18, "Gold 1"},

            {19, "Platinum 3"},
            {20, "Platinum 2"},
            {21, "Platinum 1"},

            {22, "Diamond"},

            {23, "Champion"}
        };


        /// <summary>
        /// English Names of Weapon Types
        /// </summary>
        public static readonly Dictionary<int, string> WeaponClasses = new Dictionary<int, string>
        {
            {1, "Assault Rifle"},
            {2, "SMG"},
            {3, "LMG"},
            {4, "Marksman Rifle"},
            {5, "Handgun"},
            {6, "Shotgun"},
            {7, "Machine Pistol"}
        };

    }
}
