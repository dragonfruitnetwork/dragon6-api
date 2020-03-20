// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Linq;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    [TestClass]
    public class AccountInfoTests
    {
        [TestMethod]
        public void GetSingleUserTests()
        {
            //test user id & platform id lookup (for other platforms)
            TestData.Client.GetUser(Platform.PSN, LookupMethod.UserId, "a5e7c9c4-a225-4d8e-810f-0c529d829a34");
            TestData.Client.GetUser(Platform.PSN, LookupMethod.PlatformId, "7729747787525340203");

            //test username lookup
            TestData.Client.GetUser(Platform.PC, LookupMethod.Name, "Frost_Bites_");
        }

        [TestMethod]
        public void GetLoginInfoTests()
        {
            TestData.Client.GetLoginInfo(TestData.TestAccounts.First());
            TestData.Client.GetLoginInfo(TestData.TestAccounts);
        }

        [TestMethod]
        public void GetMultipleUsersTest()
        {
            //a list of PC identifiers for testing bulk queries
            var accountIds = new[]
            {
                "14c01250-ef26-4a32-92ba-e04aa557d619",
                "00515703-cc25-4fe1-ac64-0c271a6edab1",
                "21d95808-d692-4bf3-b825-f5ad3396d079",
                "e76672be-1269-4afd-a1f5-d2ec6f5a2c7f",
                "216c88f6-72ac-43c3-a3bc-a2115aab1e13"
            };

            var userInfo = TestData.Client.GetUsers(Platform.PC, LookupMethod.UserId, accountIds);

            Assert.AreEqual(accountIds.Length, userInfo.Count());
        }
    }
}
