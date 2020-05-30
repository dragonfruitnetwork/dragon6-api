// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Tests
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public static class TestData
    {
        public const string Region = "EMEA";

        public static readonly IEnumerable<AccountInfo> TestAccounts = new[]
        {
            new AccountInfo
            {
                Identifiers = new UserIdentifierContainer("14c01250-ef26-4a32-92ba-e04aa557d619"),
                PlayerName = "PaPa.Curry",
                Platform = Platform.PC
            },
            new AccountInfo
            {
                Identifiers = new UserIdentifierContainer("21d95808-d692-4bf3-b825-f5ad3396d079"),
                PlayerName = "Frost_Bites_",
                Platform = Platform.PC
            },
            new AccountInfo
            {
                Identifiers = new UserIdentifierContainer
                {
                    Profile = "be982999-2adb-4fbe-b2a5-3cbc4b7a79bf",
                    Ubisoft = "a5e7c9c4-a225-4d8e-810f-0c529d829a34",
                    Platform = "7729747787525340203"
                },
                PlayerName = "TheKoreanKoala",
                Platform = Platform.PSN
            },
            new AccountInfo
            {
                Identifiers = new UserIdentifierContainer
                {
                    Profile = "6c5b5c77-a7db-4c5f-8802-de797ce529a8",
                    Ubisoft = "b6c8e00a-00f9-44fb-b83e-eb9135933b91",
                    Platform = "2535444832986122"
                },
                PlayerName = "Jancer",
                Platform = Platform.XB1
            }
        };
    }
}
