// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Legacy.Entities;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class LegacyStatsTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", 7600, 590)]
        [TestCase("a5e7c9c4-a225-4d8e-810f-0c529d829a34", 6000, 470)]
        public async Task TestGeneralStats(string userId, int expectedOverallKills, int expectedTimePlayedHours)
        {
            var stats = await Client.GetLegacyStatsAsync(Accounts[userId]);

            Assert.GreaterOrEqual(stats.Overall.Kills, expectedOverallKills);
            Assert.GreaterOrEqual(stats.Overall.TimePlayed.TotalHours, expectedTimePlayedHours);

            Assert.NotZero(stats.Headshots);
            Assert.NotZero(stats.Secure.Highscore);
        }

        [TestCase("3dc3cd27-8eb7-4fe0-8774-1006a8f509a2", 845, 200)]
        [TestCase("b6c8e00a-00f9-44fb-b83e-eb9135933b91", 1570, 500)]
        public async Task TestWeaponStats(string userId, int minRifleKills, int minShotgunKills)
        {
            var weaponStats = (await Client.GetLegacyWeaponStatsAsync(Accounts[userId])).ToDictionary(x => x.Class, x => x);

            Assert.NotZero(weaponStats.Count);
            Assert.GreaterOrEqual(weaponStats[LegacyWeaponType.Shotgun].Kills, minShotgunKills);
            Assert.GreaterOrEqual(weaponStats[LegacyWeaponType.AssaultRifle].Kills, minRifleKills);
        }

        [TestCase("e76672be-1269-4afd-a1f5-d2ec6f5a2c7f", "2:A", 55, 90)]
        [TestCase("9b1918ce-a45b-4140-b1d8-7e00965fbf92", "6:17", 45, 37)]
        public async Task TestOperatorStats(string userId, string operatorIndex, int kills, int wins)
        {
            var selectedOperator = await Client.GetLegacyOperatorStatsAsync(Accounts[userId]).ContinueWith(t => t.Result.SingleOrDefault(y => y.OperatorId == operatorIndex));

            Assert.IsNotNull(selectedOperator);

            Assert.GreaterOrEqual(selectedOperator.Kills, kills);
            Assert.GreaterOrEqual(selectedOperator.Wins, wins);

            Assert.IsTrue(selectedOperator.Kd > 0);
            Assert.IsTrue(selectedOperator.Wl > 0);
        }

        [TestCase("603fc6ba-db16-4aba-81b2-e9f9601d7d24", 300)]
        public async Task PlayerLevelStatsTest(string userId, int level)
        {
            var accountLevel = await Client.GetLegacyLevelAsync(Accounts[userId]);

            Assert.IsNotNull(accountLevel);
            Assert.GreaterOrEqual(accountLevel.Level, level);
        }
    }
}
