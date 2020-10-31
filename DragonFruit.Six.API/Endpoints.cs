// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API
{
    public static class Endpoints
    {
        /// <summary>
        /// Public API endpoint
        /// </summary>
        public static string BaseEndpoint => "https://public-ubiservices.ubi.com";

        /// <summary>
        /// Public-facing endpoint for generating access tokens
        /// </summary>
        public static string IdServer => BaseEndpoint + "/v3/profiles";

        /// <summary>
        /// Url of the platform-specific "sandbox", the place where all the stats are acquired from
        /// </summary>
        private static string SandboxUrlFor(this Platform platform) => $"{BaseEndpoint}/v1/spaces/{platform.GameSpaceId()}/sandboxes" + platform switch
        {
            Platform.PSN => "/OSBOR_PS4_LNCH_A",
            Platform.XB1 => "/OSBOR_XBOXONE_LNCH_A",
            Platform.PC => "/OSBOR_PC_LNCH_A",

            _ => throw new ArgumentOutOfRangeException()
        };

        public static string StatsEndpoint(this Platform platform) => $"{SandboxUrlFor(platform)}/playerstats2/statistics";
        public static string SeasonalStatsEndpoint(this Platform platform) => $"{SandboxUrlFor(platform)}/r6karma/players";
        public static string ProfileStatsEndpoint(this Platform platform) => $"{SandboxUrlFor(platform)}/r6playerprofile/playerprofile/progressions";
    }
}
