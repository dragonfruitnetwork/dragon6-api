// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Tokens;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Tokens
{
    [TestFixture]
    public class TokenExpiryTests
    {
        [Test]
        public void TestTokenExpiry()
        {
            var token = new Dragon6Token();
            Assert.True(token.Expired);
        }
    }
}
