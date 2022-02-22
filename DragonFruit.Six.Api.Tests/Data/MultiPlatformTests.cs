// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Seasonal;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class MultiPlatformTests : Dragon6ApiTest
    {
        [Test]
        public async Task MultiPlatformStatsTests()
        {
            var accounts = new[]
            {
                await GetAccountInfoFor("603fc6ba-db16-4aba-81b2-e9f9601d7d24", Platform.PC),
                await GetAccountInfoFor("b6c8e00a-00f9-44fb-b83e-eb9135933b91", Platform.XB1)
            };

            var stats = await Client.GetLegacyStatsAsync(accounts);
            var seasonalStats = await Client.GetSeasonalStatsAsync(accounts);

            Assert.IsNotNull(stats);
            Assert.IsNotNull(seasonalStats);

            Assert.AreEqual(stats.Count, accounts.Length);
            Assert.AreEqual(seasonalStats.Stats.Count, accounts.Length);
        }
    }
}
