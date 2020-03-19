// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    [TestClass]
    [SuppressMessage("ReSharper", "IteratorMethodResultIsIgnored")]
    public class PlayerStatsTests
    {
        [TestMethod]
        public void GetGeneralStats()
        {
            //single user
            TestData.Client.GetStats(TestData.TestAccounts.First());

            //multi users - different platforms
            TestData.Client.GetStats(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetRankedStats()
        {
            //single user
            TestData.Client.GetSeasonStats(TestData.TestAccounts.First(), TestData.Region);

            //multi users - different platforms
            TestData.Client.GetSeasonStats(TestData.TestAccounts, TestData.Region);
        }

        [TestMethod]
        public void GetWeaponStats()
        {
            //single user
            TestData.Client.GetWeaponStats(TestData.TestAccounts.First());

            //multi users - different platforms
            TestData.Client.GetWeaponStats(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetLevelInfo()
        {
            //single user
            TestData.Client.GetLevel(TestData.TestAccounts.First());

            //multi users - different platforms
            TestData.Client.GetLevel(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetOperatorStats()
        {
            IEnumerable<OperatorStats> opData = null;

            try
            {
                opData = WebServices.StreamObject<IEnumerable<OperatorStats>>("https://d6static.dragonfruit.network/data/operators.json");
            }
            catch
            {
                //if we can't get this file we need to forfeit...
                Assert.Inconclusive("Operators cannot be tested as a required mapping file cannot be downloaded");
            }

            //single user
            TestData.Client.GetOperatorStats(TestData.TestAccounts.First(), opData);

            //multi users - different platforms
            TestData.Client.GetOperatorStats(TestData.TestAccounts, opData);
        }
    }
}
