// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;

namespace DragonFruit.Six.API
{
    public static class Endpoints
    {
        public static readonly string BaseEndpoint = "https://public-ubiservices.ubi.com";

        public static readonly string StatsBase = BaseEndpoint + "/v1/spaces";
        public static readonly string IdServer = BaseEndpoint + "/v3/profiles";
        public static readonly string TokenServer = IdServer + "/sessions";

        /// <summary>
        /// Used for stats
        /// </summary>
        public static readonly Dictionary<Platforms, string> GameSpaceIds =
            new Dictionary<Platforms, string>
            {
                [Platforms.PSN] = "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66",
                [Platforms.XB1] = "98a601e5-ca91-4440-b1c5-753f601a2c90",
                [Platforms.PC] = "5172a557-50b5-4665-b7db-e3f2e8c5041d"
            };

        public static readonly Dictionary<Platforms, string> Stats =
            new Dictionary<Platforms, string>
            {
                [Platforms.PSN] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics",

                [Platforms.XB1] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics",

                [Platforms.PC] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PC]}/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics"
            };

        public static readonly Dictionary<Platforms, string> RankedStats =
            new Dictionary<Platforms, string>
            {
                [Platforms.PSN] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players",

                [Platforms.XB1] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players",

                [Platforms.PC] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PC]}/sandboxes/OSBOR_PC_LNCH_A/r6karma/players"
            };

        public static readonly Dictionary<Platforms, string> ProfileInfo =
            new Dictionary<Platforms, string>
            {
                [Platforms.PSN] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions",

                [Platforms.XB1] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions",

                [Platforms.PC] =
                    $"{StatsBase}/{GameSpaceIds[Platforms.PC]}/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions"
            };
    }
}
