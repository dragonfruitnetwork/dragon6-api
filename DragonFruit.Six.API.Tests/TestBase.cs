// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Clients;
using DragonFruit.Six.Developer.Clients;

namespace DragonFruit.Six.API.Tests
{
    public abstract class TestBase
    {
        private static Dragon6Client _client;

        protected Dragon6Client Client => _client ??= new Dragon6DemoClient();
    }
}
