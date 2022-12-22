// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Services.Developer;

namespace DragonFruit.Six.Api.Tests
{
    public abstract class Dragon6ApiTest
    {
        protected static readonly Dragon6DeveloperClient Client = new("00000000-0000-0000-0000-000000000001.045a00e5c0", "d3574f2ae25d47f7993689f9b4ad40c2", "dragon6.token.read");

        protected static Dragon6TestAccounts Accounts = new();
    }
}
