// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Helpers
{
    public static class UbisoftIdentifiers
    {
        public static IReadOnlyDictionary<UbisoftService, string> Websites => new Dictionary<UbisoftService, string>
        {
            [UbisoftService.RainbowSix] = "39baebad-39e5-4552-8c25-2c9b919064e2",
            [UbisoftService.UPlay] = "e06033f4-28a4-43fb-8313-6c2d882bc4a6",
            [UbisoftService.UbisoftClub] = "314d4fef-e568-454a-ae06-43e3bece12a6",
            [UbisoftService.UbisoftAccount] = "c5393f10-7ac7-4b4f-90fa-21f8f3451a04"
        };
    }
}
