// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Net.Http;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Tests
{
    internal static class TestData
    {
        internal const string Region = "EMEA";

        internal static readonly IEnumerable<AccountInfo> TestAccounts = new List<AccountInfo>
        {
            new AccountInfo
            {
                Guid = "14c01250-ef26-4a32-92ba-e04aa557d619",
                PlayerName = "Curry.",
                Platform = Platform.PC
            },
            new AccountInfo
            {
                Guid = "21d95808-d692-4bf3-b825-f5ad3396d079",
                PlayerName = "Frost_Bites_",
                Platform = Platform.PC
            },
            new AccountInfo
            {
                Guid = "be982999-2adb-4fbe-b2a5-3cbc4b7a79bf",
                PlayerName = "TheKoreanKoala",
                Platform = Platform.PSN
            }
        };

        internal static readonly Dragon6Client Client = new Dragon6TestClient();
    }
}
