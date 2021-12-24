// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Utils;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class RatioTests
    {
        [TestCase(2, 1, 2)]
        [TestCase(10, 1, 10)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 2, 0.5f)]
        public void TestRatioCalculation(int itemOne, int itemTwo, float expected)
        {
            var ratio = RatioUtils.RatioOf(itemOne, itemTwo);
            Assert.AreEqual(expected, ratio);
        }
    }
}
