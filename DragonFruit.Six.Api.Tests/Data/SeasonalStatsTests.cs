﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Seasonal;
using DragonFruit.Six.Api.Seasonal.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class SeasonalStatsTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 17, 17)]
        public async Task TestSeasonalStats(string identifier, Platform platform, int season, int maxRank)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            var stats = await Client.GetSeasonalStatsAsync(account, season);

            Assert.AreEqual(maxRank, stats.MaxRank);
        }

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, Region.EMEA, 10, 13)]
        public async Task TestLegacySeasonalStats(string identifier, Platform platform, Region region, int season, int maxRank)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            var stats = await Client.GetSeasonalStatsAsync(account, season, region: region);

            Assert.AreEqual(maxRank, stats.MaxRank);
        }
    }
}
