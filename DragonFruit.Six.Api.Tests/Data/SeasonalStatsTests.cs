// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
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
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC, 0, 16)]
        public async Task TestSeasonalRecords(string identifier, Platform platform, int season15Rank, int season17Rank)
        {
            var account = await GetAccountInfoFor(identifier, platform);
            var seasons = Enumerable.Range(15, 7);
            var stats = (await Client.GetSeasonalStatsRecordsAsync(account, seasons, BoardType.Ranked, Region.EMEA)).ToDictionary(x => x.SeasonId);

            Assert.AreEqual(season15Rank, stats[15].Rank);
            Assert.AreEqual(season17Rank, stats[17].Rank);
        }

        /// <summary>
        /// Tests seasonal lookup against ranked2 and older seasons
        /// </summary>
        [Test]
        public async Task TestMultiPlatformMultiVersionRanked()
        {
            var accounts = new[]
            {
                await GetAccountInfoFor("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC),
                await GetAccountInfoFor("45c0cccb-a1a8-4433-b3d8-52aaa40d16d2", Platform.PC),
                await GetAccountInfoFor("5e992dc8-7d93-4f28-9690-08b4d6788cc8", Platform.PSN)
            };

            var stats = await Client.GetSeasonalStatsRecordsAsync(accounts, new[] { 28, 27, 26, 25 });
            Assert.AreEqual(48, stats.Count);

            var casualMMR = stats.Single(x => x.ProfileId == "14c01250-ef26-4a32-92ba-e04aa557d619" && x.Board == BoardType.Casual && x.SeasonId == 26).MMR;
            Assert.Greater(casualMMR, 2200);

            var rankedWins = stats.Where(x => x.ProfileId == "45c0cccb-a1a8-4433-b3d8-52aaa40d16d2" && x.Board == BoardType.Ranked).OrderByDescending(x => x.SeasonId).First().Wins;
            Assert.Greater(rankedWins, 5);
        }
    }
}
