// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Services.Status;
using NUnit.Framework;

namespace DragonFruit.Six.Api.Tests.Utils
{
    [TestFixture]
    public class ServiceTests : Dragon6ApiTest
    {
        [Test]
        public async Task TestGeolocation() => await Client.GeolocateAsync();

        [Test]
        public async Task TestServerStatus() => await Client.GetServerStatusAsync();
    }
}
