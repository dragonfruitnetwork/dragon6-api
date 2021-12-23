// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Legacy;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class LegacyStatsTests : Dragon6ApiTest
    {
        private static object[] _accounts =
        {
            new object[] { "14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC },
            new object[] { "b6c8e00a-00f9-44fb-b83e-eb9135933b91", Platform.XB1 },
            new object[] { "a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN }
        };

        [Test]
        [TestCaseSource(nameof(_accounts))]
        public async Task GeneralStatsTest(string identifier, Platform platform)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            await Client.GetLegacyStatsAsync(account);
        }

        [Test]
        [TestCaseSource(nameof(_accounts))]
        public async Task WeaponStatsTest(string identifier, Platform platform)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            await Client.GetLegacyWeaponStatsAsync(account);
        }

        // [Test]
        // [TestCaseSource(nameof(_accounts))]
        // public async Task PlayerLevelStatsTest(string identifier, Platform platform)
        // {
        //     var account = await GetAccountInfoFor(identifier, platform);
        //     Client.GetLevel(account);
        // }

        [Test]
        [TestCaseSource(nameof(_accounts))]
        public async Task PlayerOperatorStatsTest(string identifier, Platform platform)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            await Client.GetLegacyOperatorStatsAsync(account);
        }
    }
}
