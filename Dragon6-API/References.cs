﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon6.API
{
    public class References
    {
        public enum Platforms
        {
            PC,
            PSN,
            XB1
        }

        public static string[] Regions = {"EMEA", "APAC", "NCSA"};

        public static Dictionary<int, string> RankNames = new Dictionary<int, string>
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
            {20, "Diamond"}
        };

    }
}
