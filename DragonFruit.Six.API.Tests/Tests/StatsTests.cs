// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Tests.Common;
using DragonFruit.Six.API.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests.Tests
{
    [TestClass]
    [SuppressMessage("ReSharper", "IteratorMethodResultIsIgnored")]
    public class PlayerStatsTests : TestBase
    {
        [TestMethod]
        public void GetGeneralStats()
        {
            //single user
            Client.GetClassicStats(TestData.TestAccounts.First());

            //multi users - different platforms
            Client.GetClassicStats(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetRankedStats()
        {
            //single user
            Client.GetSeasonStats(TestData.TestAccounts.First());

            //multi users - different platforms
            Client.GetSeasonStats(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetWeaponStats()
        {
            //single user
            Client.GetClassicWeaponStats(TestData.TestAccounts.First());

            //multi users - different platforms
            Client.GetClassicWeaponStats(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetLevelInfo()
        {
            //single user
            Client.GetLevel(TestData.TestAccounts.First());

            //multi users - different platforms
            Client.GetLevel(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetOperatorStats()
        {
            IEnumerable<ClassicOperatorStats> opData = null;

            try
            {
                opData = Client.GetOperatorInfo();
            }
            catch
            {
                //if we can't get this file we need to forfeit...
                Assert.Inconclusive("Operators cannot be tested as a required mapping file cannot be downloaded");
            }

            //single user
            Client.GetClassicOperatorStats(TestData.TestAccounts.First(), opData);

            //multi users - different platforms
            Client.GetClassicOperatorStats(TestData.TestAccounts, opData);
        }
    }
}
