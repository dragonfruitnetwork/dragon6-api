// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Globalization;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Accounts.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class AccountActivityTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 20211101)]
        [TestCase("352655b3-2ff4-4713-9ad5-c10eb080e6f6", Platform.PC, 20200901)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN, 20191001)]
        public async Task TestAccountActivity(string id, Platform platform, int lastLogin)
        {
            if (!DateTime.TryParseExact(lastLogin.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out var lastLoginDate))
            {
                Assert.Inconclusive($"{nameof(lastLogin)} was in an invalid format");
            }

            var account = await GetAccountInfoFor(id, platform);
            var login = await Client.GetAccountActivityAsync(account);

            Assert.IsTrue(login.LastSession.Date >= lastLoginDate);
        }
    }
}
