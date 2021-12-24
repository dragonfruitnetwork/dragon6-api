// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Entities;
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

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 7600, 590)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", Platform.PSN, 6000, 470)]
        public async Task TestGeneralStats(string userId, Platform platform, int expectedOverallKills, int expectedTimePlayedHours)
        {
            var account = await GetAccountInfoFor(userId, platform);
            var stats = await Client.GetLegacyStatsAsync(account);

            Assert.GreaterOrEqual(stats.Overall.Kills, expectedOverallKills);
            Assert.GreaterOrEqual(stats.Overall.TimePlayed.TotalHours, expectedTimePlayedHours);

            Assert.NotZero(stats.Headshots);
            Assert.NotZero(stats.Secure.Highscore);
        }

        [TestCase("3dc3cd27-8eb7-4fe0-8774-1006a8f509a2", Platform.PC, 845, 200)]
        [TestCase("b6c8e00a-00f9-44fb-b83e-eb9135933b91", Platform.XB1, 1570, 500)]
        public async Task WeaponStatsTest(string identifier, Platform platform, int minRifleKills, int minShotgunKills)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            var weaponStats = (await Client.GetLegacyWeaponStatsAsync(account)).ToDictionary(x => x.Class, x => x);

            Assert.NotZero(weaponStats.Count);
            Assert.GreaterOrEqual(weaponStats[LegacyWeaponType.Shotgun].Kills, minShotgunKills);
            Assert.GreaterOrEqual(weaponStats[LegacyWeaponType.AssaultRifle].Kills, minRifleKills);
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
