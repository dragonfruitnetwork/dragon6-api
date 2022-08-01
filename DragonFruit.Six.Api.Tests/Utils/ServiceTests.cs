// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Services.Geolocation;
using DragonFruit.Six.Api.Services.Status;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class ServiceTests : Dragon6ApiTest
    {
        [Test]
        public async Task TestGeolocation()
        {
            // test the request works without throwing
            // as we don't know who's running this, there's no real way to validate correctness of this part
            await Client.GeolocateAsync().ConfigureAwait(false);

            var addressInfo = await Client.GeolocateAsync("8.8.8.8", "172.217.16.238", "194.39.167.145", "2620:119:35::35").ConfigureAwait(false);
            var addressDirectory = addressInfo.ToDictionary(x => x.IP);

            // google services
            Assert.AreEqual("Google", addressDirectory["8.8.8.8"].ServiceProvider);
            Assert.AreEqual("Google Servers", addressDirectory["172.217.16.238"].ServiceProvider);

            // IPv6 DNS server
            Assert.AreEqual("Cisco OpenDNS, LLC", addressDirectory["2620:119:35::35"].ServiceProvider);

            // random ip address from UK
            Assert.AreEqual("United Kingdom", addressDirectory["194.39.167.145"].CountryName);
        }

        [Test]
        public async Task TestServerStatus() => await Client.GetServerStatusAsync();
    }
}
