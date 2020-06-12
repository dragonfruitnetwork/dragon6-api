// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API
{
    public static class Endpoints
    {
        public static readonly string BaseEndpoint = "https://public-ubiservices.ubi.com";

        public static readonly string StatsBase = BaseEndpoint + "/v1/spaces";
        public static readonly string IdServer = BaseEndpoint + "/v3/profiles";

        /// <summary>
        /// Used for <see cref="AccountLoginInfo"/>
        /// </summary>
        public static readonly Dictionary<Platform, string> GameIds =
            new Dictionary<Platform, string>
            {
                [Platform.PSN] = "fb4cc4c9-2063-461d-a1e8-84a7d36525fc",
                [Platform.XB1] = "4008612d-3baf-49e4-957a-33066726a7bc",
                [Platform.PC] = "e3d5ea9e-50bd-43b7-88bf-39794f4e3d40"
            };

        /// <summary>
        /// Game ids used for getting stats
        /// </summary>
        public static readonly Dictionary<Platform, string> GameSpaceIds =
            new Dictionary<Platform, string>
            {
                [Platform.PSN] = "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66",
                [Platform.XB1] = "98a601e5-ca91-4440-b1c5-753f601a2c90",
                [Platform.PC] = "5172a557-50b5-4665-b7db-e3f2e8c5041d"
            };

        public static readonly Dictionary<Platform, string> Stats =
            new Dictionary<Platform, string>
            {
                [Platform.PSN] = $"{StatsBase}/{GameSpaceIds[Platform.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics",
                [Platform.XB1] = $"{StatsBase}/{GameSpaceIds[Platform.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics",
                [Platform.PC] = $"{StatsBase}/{GameSpaceIds[Platform.PC]}/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics"
            };

        public static readonly Dictionary<Platform, string> RankedStats =
            new Dictionary<Platform, string>
            {
                [Platform.PSN] = $"{StatsBase}/{GameSpaceIds[Platform.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players",
                [Platform.XB1] = $"{StatsBase}/{GameSpaceIds[Platform.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players",
                [Platform.PC] = $"{StatsBase}/{GameSpaceIds[Platform.PC]}/sandboxes/OSBOR_PC_LNCH_A/r6karma/players"
            };

        public static readonly Dictionary<Platform, string> ProfileInfo =
            new Dictionary<Platform, string>
            {
                [Platform.PSN] = $"{StatsBase}/{GameSpaceIds[Platform.PSN]}/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions",
                [Platform.XB1] = $"{StatsBase}/{GameSpaceIds[Platform.XB1]}/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions",
                [Platform.PC] = $"{StatsBase}/{GameSpaceIds[Platform.PC]}/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions"
            };
    }
}
