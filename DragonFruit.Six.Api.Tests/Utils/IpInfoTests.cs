// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Extensions;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class IpInfoTests : Dragon6ApiTest
    {
        [Test]
        public async Task TestIpInformation()
        {
            var result = Client.Geolocate();
            var asyncResult = await Client.GeolocateAsync();

            Assert.AreEqual(result.IP, asyncResult.IP);
        }
    }
}
