// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    [TestClass]
    public class AccountInfoTests : TestBase
    {
        [TestMethod]
        public void GetSingleUserTests()
        {
            static string KeySelector(AccountInfo x) => x.PlayerName;

            //test user id & platform id lookup (for other platforms)
            foreach (var users in TestData.TestAccounts.GroupBy(x => x.Platform))
            {
                var userIdUsers = Client.GetUsers(users.Key, LookupMethod.UserId, users.Select(x => x.Identifiers.Ubisoft)).OrderBy((Func<AccountInfo, string>)KeySelector);
                var platformIdUsers = Client.GetUsers(users.Key, LookupMethod.PlatformId, users.Select(x => x.Identifiers.Platform)).OrderBy((Func<AccountInfo, string>)KeySelector);

                for (int i = 0; i < userIdUsers.Count(); i++)
                {
                    Assert.IsTrue(userIdUsers.ElementAt(i).Equals(platformIdUsers.ElementAt(i)));
                }
            }
        }

        [TestMethod]
        public void GetLoginInfoTests()
        {
            Client.GetLoginInfo(TestData.TestAccounts.First());
            Client.GetLoginInfo(TestData.TestAccounts);
        }
    }
}
