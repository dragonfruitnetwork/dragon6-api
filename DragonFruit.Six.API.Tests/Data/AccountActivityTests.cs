// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Globalization;
using DragonFruit.Six.Api.Data.Extensions;
using DragonFruit.Six.Api.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class AccountActivityTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 20201201)]
        [TestCase("352655b3-2ff4-4713-9ad5-c10eb080e6f6", Platform.PC, 20200901)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN, 20191001)]
        public void TestAccountActivity(string id, Platform platform, int lastLogin)
        {
            if (!DateTime.TryParseExact(lastLogin.ToString(), "yyyyMMdd", null, DateTimeStyles.None, out var lastLoginDate))
            {
                Assert.Inconclusive($"{nameof(lastLogin)} was in an invalid format");
            }

            var account = GetAccountInfoFor(id, platform);
            var login = Client.GetLoginInfo(account);

            Assert.IsTrue(login.Activity.Last.UtcDateTime.Date > lastLoginDate.Date);
        }
    }
}
