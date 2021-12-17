// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Extensions;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Modern
{
    [TestFixture]
    public class WeaponStatsTests : Dragon6ApiTest
    {
        [TestCase("ab1ff7ae-13e4-4a6a-9b03-317285f8057b", Platform.PC, true)]
        [TestCase("352655b3-2ff4-4713-9ad5-c10eb080e6f6", Platform.PC, false)]
        [TestCase("b598e9a9-f817-42fe-b381-45f918e5efa4", Platform.XB1, true)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN, false)]
        public void BasicWeaponStatsTest(string userId, Platform platform, bool expectResults)
        {
            var account = GetAccountInfoFor(userId, platform);
            var operatorStats = Client.GetModernWeaponStatsFor(account, startDate: DateTimeOffset.Now.AddDays(-30));

            Assert.IsTrue(operatorStats?.AllModes.AsAny.Primary.Any() ?? !expectResults);
        }
    }
}
