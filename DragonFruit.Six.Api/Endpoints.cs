// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Accounts.Enums;

namespace DragonFruit.Six.Api
{
    internal static class Endpoints
    {
        /// <summary>
        /// Public API endpoint
        /// </summary>
        public static string BaseEndpoint => "https://public-ubiservices.ubi.com";

        /// <summary>
        /// The Dragon6 static assets endpoint
        /// </summary>
        public static string AssetsEndpoint => "https://d6static.dragonfruit.network";

        /// <summary>
        /// Public-facing endpoint for generating access tokens
        /// </summary>
        public static string IdServer => BaseEndpoint + "/v3/profiles";

        /// <summary>
        /// Url of the "space", where urls are derived from
        /// </summary>
        public static string SpaceUrl(this Platform platform, int version) => $"{BaseEndpoint}/v{version}/spaces/{platform.GameSpaceId()}";

        /// <summary>
        /// Url of the platform-specific "sandbox", the place where all the stats are acquired from
        /// </summary>
        public static string SandboxUrl(this Platform platform, int version = 1) => $"{platform.SpaceUrl(version)}/sandboxes" + platform switch
        {
            Platform.PSN => "/OSBOR_PS4_LNCH_A",
            Platform.XB1 => "/OSBOR_XBOXONE_LNCH_A",
            Platform.PC => "/OSBOR_PC_LNCH_A",
            Platform.CrossPlatform => "/OSBOR_XPLAY_LNCH_A",

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
