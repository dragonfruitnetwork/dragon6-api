// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Accounts.Entities;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Data
{
    [TestFixture]
    public class AccountLevelTests : Dragon6ApiTest
    {
        [TestCaseSource(nameof(Accounts))]
        public async Task GetAccountLevel(UbisoftAccount account)
        {
            var level = await Client.GetAccountLevelAsync(account).ConfigureAwait(false);
            Assert.GreaterOrEqual(level.Level, 5);
        }
    }
}
