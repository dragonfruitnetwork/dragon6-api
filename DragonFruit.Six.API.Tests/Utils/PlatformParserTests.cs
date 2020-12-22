// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;
using NUnit.Framework;

namespace DragonFruit.Six.API.Tests.Utils
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
