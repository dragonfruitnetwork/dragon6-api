// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Net.Http;
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
                Platform = Platforms.PC
            },
            new AccountInfo
            {
                Guid = "21d95808-d692-4bf3-b825-f5ad3396d079",
                PlayerName = "Frost_Bites_",
                Platform = Platforms.PC
            },
            new AccountInfo
            {
                Guid = "be982999-2adb-4fbe-b2a5-3cbc4b7a79bf",
                PlayerName = "TheKoreanKoala",
                Platform = Platforms.PSN
            }
        };

        internal static string Token => string.IsNullOrWhiteSpace(_token) ? GetToken() : _token;

        private static string _token = string.Empty;

        private static string GetToken()
        {
            using var client = new HttpClient();
            using var tokenTask = client.GetStringAsync("https://dragon6.dragonfruit.network/api/token");

            tokenTask.Wait();

            _token = tokenTask.Result;
            return tokenTask.Result;
        }
    }
}
