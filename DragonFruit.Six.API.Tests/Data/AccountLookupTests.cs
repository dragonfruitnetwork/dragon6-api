// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Data.Extensions;
using DragonFruit.Six.Api.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class AccountLookupTests : Dragon6ApiTest
    {
        [TestCase("papa.curry", LookupMethod.Name)]
        [TestCase("Frost_Bites_", LookupMethod.Name)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", LookupMethod.UserId, Platform.PSN)]
        [TestCase("b6c8e00a-00f9-44fb-b83e-eb9135933b91", LookupMethod.UserId, Platform.XB1)]
        public void TestAccountLookup(string identifier, LookupMethod method, Platform platform = Platform.PC)
        {
            var account = Client.GetUser(platform, method, identifier);

            Assert.IsTrue(method switch
            {
                LookupMethod.Name => identifier.Equals(account.PlayerName, StringComparison.OrdinalIgnoreCase),
                LookupMethod.UserId => identifier.Equals(account.Identifiers.Ubisoft),
                LookupMethod.PlatformId => identifier.Equals(account.Identifiers.Platform),

                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            });
        }

        [TestCase("l52655b3-2ff4-4713-9ad5-c10eb080e6f6")]
        [TestCase("352655b3-2ff4-4713-xxxx-c10eb080e6f6")]
        public void TestInvalidAccountLookup(string identifier)
        {
            Assert.Catch<ArgumentException>(() => Client.GetUserByUbisoftId(identifier, Platform.PC));
        }
    }
}
