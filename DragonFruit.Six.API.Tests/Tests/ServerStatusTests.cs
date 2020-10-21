// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Diagnostics;
using DragonFruit.Six.API.Data.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests.Tests
{
    [TestClass]
    public class ServerStatusTests : TestBase
    {
        [TestMethod]
        public void TestServerStatus()
        {
            var status = Client.GetServerStatus();

            foreach (var platform in status)
            {
                Trace.WriteLine($"{platform.Platform} | {platform.Status}");
            }
        }
    }
}
