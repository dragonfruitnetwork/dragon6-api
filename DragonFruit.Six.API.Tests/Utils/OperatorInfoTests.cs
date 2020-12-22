// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Utils;
using NUnit.Framework;

namespace DragonFruit.Six.API.Tests.Utils
{
    [TestFixture]
    public class OperatorInfoTests : Dragon6ApiTest
    {
        [Test]
        public void OperatorInfoTest()
        {
            OperatorInfo ??= Client.GetOperatorInfo();
        }
    }
}
