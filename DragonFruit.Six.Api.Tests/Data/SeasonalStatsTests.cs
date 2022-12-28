// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Seasonal;
using DragonFruit.Six.Api.Seasonal.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class SeasonalStatsTests : Dragon6ApiTest
    {
        /// <summary>
        /// Test seasonal record deserialization is happening as expected
        /// </summary>
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", 0, 16)]
        public async Task TestSeasonalRecords(string userId, int season15Rank, int season17Rank)
        {
            var seasons = Enumerable.Range(15, 7);
            var stats = (await Client.GetSeasonalStatsRecordsAsync(Accounts[userId], seasons, BoardType.Ranked, Region.EMEA)).ToDictionary(x => x.SeasonId);

            Assert.AreEqual(season15Rank, stats[15].Rank);
            Assert.AreEqual(season17Rank, stats[17].Rank);
        }

        /// <summary>
        /// Tests seasonal lookup against ranked2 and older seasons
        /// </summary>
        [Test]
        public async Task TestMultiPlatformMultiVersionRanked()
        {
            var stats = (await Client.GetSeasonalStatsRecordsAsync(Accounts, new[] { 28, 27, 26, 25 })).ToList();
            Assert.Greater(stats.Count, 48);

            var casualMMR = stats.Single(x => x.ProfileId == "14c01250-ef26-4a32-92ba-e04aa557d619" && x.Board == BoardType.Casual && x.SeasonId == 26).MMR;
            Assert.Greater(casualMMR, 2200);

            var rankedWins = stats.Where(x => x.ProfileId == "45c0cccb-a1a8-4433-b3d8-52aaa40d16d2" && x.Board == BoardType.Ranked).OrderByDescending(x => x.SeasonId).First().Wins;
            Assert.Greater(rankedWins, 5);
        }

        [Test]
        public async Task TestRanked2SeasonStats()
        {
            var stats = (await Client.GetSeasonalStatsAsync(Accounts, PlatformGroup.PC)).ToList();
            Assert.GreaterOrEqual(Accounts.Count() * 4, stats.Count);
        }
    }
}
