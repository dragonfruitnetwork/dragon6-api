// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Enums;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class ModernStatsTests : Dragon6ApiTest
    {
        [TestCaseSource(nameof(Accounts))]
        public async Task TestModernSummary(UbisoftAccount account)
        {
            var data = await Client.GetModernStatsSummaryAsync(account);

            ValidateResponse(data, s => s.AllModes.AsAny);
            Assert.AreEqual(1, data.AllModes.AsAny.Count());
        }

        [TestCaseSource(nameof(Accounts))]
        public async Task TestModernOperators(UbisoftAccount account)
        {
            var data = await Client.GetModernOperatorStatsAsync(account, operatorType: OperatorType.Attacker);
            ValidateResponse(data, s => s.AllModes.AsAttacker);
        }

        [TestCaseSource(nameof(Accounts))]
        public async Task TestModernWeapons(UbisoftAccount account)
        {
            var data = await Client.GetModernWeaponStatsAsync(account);
            ValidateResponse(data, s => s.AllModes.AsDefender.Primary);
        }

        [TestCaseSource(nameof(Accounts))]
        public async Task TestModernSeasons(UbisoftAccount account)
        {
            var data = await Client.GetModernSeasonStatsAsync(account, PlaylistType.Independent);
            ValidateResponse(data, s => s.AllModes.AsAny);
        }

        private static void ValidateResponse<T, TTarget>(ModernModeStatsContainer<T> container, Func<ModernModeStatsContainer<T>, IEnumerable<TTarget>> selector)
        {
            if (container == null)
            {
                Assert.Inconclusive();
            }

            Assert.IsNotEmpty(selector.Invoke(container));
        }
    }
}
