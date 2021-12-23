// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Accounts.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class AccountLookupTests : Dragon6ApiTest
    {
        [TestCase("Curry.", IdentifierType.Name)]
        [TestCase("papa.curry", IdentifierType.Name)]
        [TestCase("PaPa.Yukina", IdentifierType.Name)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", IdentifierType.UserId, Platform.PSN)]
        [TestCase("b6c8e00a-00f9-44fb-b83e-eb9135933b91", IdentifierType.UserId, Platform.XB1)]
        public async Task TestAccountLookup(string identifier, IdentifierType method, Platform platform = Platform.PC)
        {
            var account = await Client.GetAccountAsync(identifier, platform, method);

            Assert.IsTrue(method switch
            {
                IdentifierType.Name => identifier.Equals(account.Username, StringComparison.OrdinalIgnoreCase),
                IdentifierType.UserId => identifier.Equals(account.UbisoftId),
                IdentifierType.PlatformId => identifier.Equals(account.PlatformId),

                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            });
        }

        [TestCase("l52655b3-2ff4-4713-9ad5-c10eb080e6f6")]
        [TestCase("352655b3-2ff4-4713-xxxx-c10eb080e6f6")]
        public void TestInvalidAccountLookup(string identifier)
        {
            Assert.Catch(() => Client.GetAccountAsync(identifier, Platform.PC, IdentifierType.UserId));
        }
    }
}
