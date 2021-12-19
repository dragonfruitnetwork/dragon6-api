// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Utils
{
    public static class UbisoftIdentifiers
    {
        private static IReadOnlyDictionary<string, Platform> _gameIds;

        internal const string UbiAppIdHeader = "Ubi-AppId";
        internal const string UbiSessionIdHeader = "Ubi-SessionId";

        /// <summary>
        /// <see cref="IReadOnlyDictionary{TKey,TValue}"/> of platforms to game ids used for checking playtime stats
        /// </summary>
        internal static IReadOnlyDictionary<string, Platform> GameIds => _gameIds ??= PlatformParser.PlatformsTo(p => p.GameId());

        /// <summary>
        /// Gets the Ubi-AppId for the specified service
        /// </summary>
        public static string AppId(this UbisoftService service) => service switch
        {
            UbisoftService.RainbowSix => "39baebad-39e5-4552-8c25-2c9b919064e2",
            UbisoftService.UPlay => "e06033f4-28a4-43fb-8313-6c2d882bc4a6",
            UbisoftService.UbisoftClub => "314d4fef-e568-454a-ae06-43e3bece12a6",
            UbisoftService.UbisoftAccount => "c5393f10-7ac7-4b4f-90fa-21f8f3451a04",
            UbisoftService.NewStatsSite => "3587dcbb-7f81-457c-9781-0e3f29f6f56a",

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Ubisoft-assigned ids for getting account play stats
        /// </summary>
        public static string GameId(this Platform platform) => platform switch
        {
            Platform.PSN => "fb4cc4c9-2063-461d-a1e8-84a7d36525fc",
            Platform.XB1 => "4008612d-3baf-49e4-957a-33066726a7bc",
            Platform.PC => "e3d5ea9e-50bd-43b7-88bf-39794f4e3d40",

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Ubisoft-assigned ids for getting game stats. Used in the "sandbox"
        /// </summary>
        public static string GameSpaceId(this Platform platform) => platform switch
        {
            Platform.PSN => "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66",
            Platform.XB1 => "98a601e5-ca91-4440-b1c5-753f601a2c90",
            Platform.PC => "5172a557-50b5-4665-b7db-e3f2e8c5041d",

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Convert a stats request key to a response key
        /// </summary>
        internal static string ToStatsKey(this string key) => $"{key}:infinite";

        /// <summary>
        /// Convert an indexed stats request key to a response key
        /// </summary>
        internal static string ToIndexedStatsKey(this string key, object index) => $"{key}:{index}:infinite";
    }
}
