// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.Web;
using DragonFruit.Six.API.Stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    [TestClass]
    public class PlayerStatsTests
    {
        [TestMethod]
        public async Task
        GetGeneralStats()
        {
            // single user
            await GeneralStats.GetStats(TestData.TestAccounts.First(),
                                        TestData.Token);

            // multi users - different platforms
            await GeneralStats.GetStats(TestData.TestAccounts, TestData.Token);
        }

        [TestMethod]
        public async Task
        GetRankedStats()
        {
            // single user
            await Season.GetSeason(TestData.TestAccounts.First(), TestData.Region,
                                   TestData.Token);

            // multi users - different platforms
            await Season.GetSeason(TestData.TestAccounts, TestData.Region,
                                   TestData.Token);
        }

        [TestMethod]
        public async Task
        GetWeaponStats()
        {
            // single user
            await WeaponStats.GetWeaponStats(TestData.TestAccounts.First(),
                                             TestData.Token);

            // multi users - different platforms
            await WeaponStats.GetWeaponStats(TestData.TestAccounts, TestData.Token);
        }

        [TestMethod]
        public async Task
        GetLevelInfo()
        {
            // single user
            await PlayerLevel.GetLevel(TestData.TestAccounts.First(), TestData.Token);

            // multi users - different platforms
            await PlayerLevel.GetLevel(TestData.TestAccounts, TestData.Token);
        }

        [TestMethod]
        public async Task
        GetOperatorStats()
        {
            IEnumerable<Operator> opData = null;

            try
            {
                opData = WebServices.StreamObject<IEnumerable<Operator>>(
                    "https://d6static.dragonfruit.network/data/operators.json");
            }
            catch
            {
                // if we can't get this file we need to forfeit...
                Assert.Inconclusive(
                    "Operators cannot be tested as a required mapping file cannot be downloaded");
            }

            // single user
            await Operator.GetOperatorStats(TestData.TestAccounts.First(), opData,
                                            TestData.Token);

            // multi users - different platforms
            await Operator.GetOperatorStats(TestData.TestAccounts, opData,
                                            TestData.Token);
        }
    }
}
