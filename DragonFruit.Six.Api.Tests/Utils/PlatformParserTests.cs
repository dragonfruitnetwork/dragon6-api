// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Accounts.Utils;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Utils;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class PlatformParserTests
    {
        [TestCase("pc", Platform.PC)]
        [TestCase("XB1", Platform.XB1)]
        public void TestPlatformParser(string platform, Platform expectedPlatform)
        {
            Assert.AreEqual(expectedPlatform, PlatformParser.GetPlatform(platform));
        }
    }
}
