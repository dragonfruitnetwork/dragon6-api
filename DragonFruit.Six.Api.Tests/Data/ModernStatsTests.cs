// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern;
using DragonFruit.Six.Api.Modern.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class ModernStatsTests : Dragon6ApiTest
    {
        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC)]
        [TestCase("d0cc86e3-f3b8-493c-bb36-c9416183477a", Platform.PC)]
        public async Task TestModernSummary(string userId, Platform platform)
        {
            var account = await GetAccountInfoFor(userId, platform);
            var data = await Client.GetModernStatsSummaryAsync(account);

            // summaries are returned in an array but there should only be one entry
            data?.AllModes.AsAny.SingleOrDefault();
        }

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC)]
        [TestCase("d0cc86e3-f3b8-493c-bb36-c9416183477a", Platform.PC)]
        public async Task TestModernOperators(string userId, Platform platform)
        {
            var account = await GetAccountInfoFor(userId, platform);
            var data = await Client.GetModernOperatorStatsAsync(account, operatorType: OperatorType.Attacker);

            var operators = data?.AllModes.AsAttacker;
        }

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC)]
        [TestCase("d0cc86e3-f3b8-493c-bb36-c9416183477a", Platform.PC)]
        public async Task TestModernWeapons(string userId, Platform platform)
        {
            var account = await GetAccountInfoFor(userId, platform);
            var data = await Client.GetModernWeaponStatsAsync(account);

            var primaryWeapons = data?.AllModes.AsDefender.Primary;
        }

        [TestCase("14c01250-ef26-4a32-92ba-e04aa557d619", Platform.PC)]
        [TestCase("d0cc86e3-f3b8-493c-bb36-c9416183477a", Platform.PC)]
        public async Task TestModernSeasons(string userId, Platform platform)
        {
            var account = await GetAccountInfoFor(userId, platform);
            var data = await Client.GetModernSeasonStatsAsync(account, PlaylistType.Independent);

            var seasons = data?.AllModes.AsAny;
        }
    }
}
