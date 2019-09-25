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

        public static string GetWeaponClass(int id)
        {
            try
            {
                return WeaponClasses[id];
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetRankName(int id)
        {
            try
            {
                return RankNames[id];
            }
            catch
            {
                if(id > 21)
                    return RankNames[20]; //temp fix for broken ubi api
            }

            return RankNames[0];
        }

        /// <summary>
        /// English Versions of Rank ID -> Names
        /// </summary>
        private static readonly Dictionary<int, string> RankNames = new Dictionary<int, string>
        {
            {0, "Unranked"},
            {1, "Copper 4"},
            {2, "Copper 3"},
            {3, "Copper 2"},
            {4, "Copper 1"},
            {5, "Bronze 4"},
            {6, "Bronze 3"},
            {7, "Bronze 2"},
            {8, "Bronze 1"},
            {9, "Silver 4"},
            {10, "Silver 3"},
            {11, "Silver 2"},
            {12, "Silver 1"},
            {13, "Gold 4"},
            {14, "Gold 3"},
            {15, "Gold 2"},
            {16, "Gold 1"},
            {17, "Platinum 3"},
            {18, "Platinum 2"},
            {19, "Platinum 1"},
            {20, "Diamond"},
            {21, "Champion"}
        };

        /// <summary>
        /// English Names of Weapon Types
        /// </summary>
        private static readonly Dictionary<int, string> WeaponClasses = new Dictionary<int, string>
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
