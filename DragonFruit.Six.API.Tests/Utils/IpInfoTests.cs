// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Data.Extensions;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class IpInfoTests : Dragon6ApiTest
    {
        [Test]
        public void TestIpInformation()
        {
            Client.GetUserLocationInfo();
        }
    }
}
