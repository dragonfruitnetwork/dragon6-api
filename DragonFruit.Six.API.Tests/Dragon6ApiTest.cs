// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Tests
{
    public abstract class Dragon6ApiTest
    {
        private static readonly List<AccountInfo> Accounts = new();
        protected static readonly Dragon6TestClient Client = new();

        protected static IEnumerable<OperatorStats> OperatorInfo { get; set; }

        protected AccountInfo GetAccountInfoFor(string identifier, Platform platform)
        {
            var account = Accounts.SingleOrDefault(x => identifier == x.Identifiers.Ubisoft);

            if (account != null)
            {
                return account;
            }

            var onlineAccount = Client.GetUser(platform, LookupMethod.UserId, identifier);
            Accounts.Add(onlineAccount);

            return onlineAccount;
        }
    }
}
