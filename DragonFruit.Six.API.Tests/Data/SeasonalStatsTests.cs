// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.API.Tests.Data
{
    [TestFixture]
    public class SeasonalStatsTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 17, 17)]
        public void TestSeasonalStats(string identifier, Platform platform, int season, int maxRank)
        {
            var account = GetAccountInfoFor(identifier, platform);
            var stats = Client.GetSeasonStats(account, season);

            Assert.AreEqual(maxRank, stats.MaxRank);
        }

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, "EMEA", 10, 13)]
        public void TestLegacySeasonalStats(string identifier, Platform platform, string region, int season, int maxRank)
        {
            var account = GetAccountInfoFor(identifier, platform);
            var stats = Client.GetSeasonStats(account, region, season);

            Assert.AreEqual(maxRank, stats.MaxRank);
        }
    }
}
