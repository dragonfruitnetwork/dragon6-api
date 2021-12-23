// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Legacy.Entities;
using DragonFruit.Six.Api.Services.Developer;

namespace DragonFruit.Six.Api.Tests
{
    public abstract class Dragon6ApiTest
    {
        private static readonly List<UbisoftAccount> Accounts = new();
        protected static readonly Dragon6DeveloperClient Client = new("00000000-0000-0000-0000-000000000001.045a00e5c0", "d3574f2ae25d47f7993689f9b4ad40c2", "dragon6.token.read");

        protected static IEnumerable<LegacyOperatorStats> OperatorInfo { get; set; }

        protected async Task<UbisoftAccount> GetAccountInfoFor(string identifier, Platform platform)
        {
            var account = Accounts.SingleOrDefault(x => identifier == x.UbisoftId);

            if (account != null)
            {
                return account;
            }

            var onlineAccount = await Client.GetAccountAsync(identifier, platform, IdentifierType.UserId).ConfigureAwait(false);
            Accounts.Add(onlineAccount);

            return onlineAccount;
        }
    }
}
