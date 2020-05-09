// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Exceptions;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.Developer.Clients;
using DragonFruit.Six.Developer.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DragonFruit.Six.API.Tests
{
    public class Dragon6TestClient : Dragon6Client
    {
        private const string EnvironmentVariableName = "Dragon6-devKey";

        private static string DevKey => RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Environment.GetEnvironmentVariable(EnvironmentVariableName, EnvironmentVariableTarget.User)
            : Environment.GetEnvironmentVariable(EnvironmentVariableName);

        public Dragon6TestClient()
        {
            if (string.IsNullOrWhiteSpace(DevKey))
            {
                Assert.Inconclusive("No Developer Key Available, if you need one, please request one by creating an issue on the GitHub Repo");
            }
        }

        private readonly Lazy<Dragon6DeveloperClient> _developerClient = new Lazy<Dragon6DeveloperClient>(() => new Dragon6DeveloperClient(DevKey));

        protected override T ValidateAndProcess<T>(Task<HttpResponseMessage> response)
        {
            try
            {
                return base.ValidateAndProcess<T>(response);
            }
            catch (UbisoftErrorException)
            {
                //pretend to be ubisoft club and try again
                AppId = UbisoftIdentifiers.UbisoftAppIds[UbisoftService.UbisoftClub];
                return PerformLast<T>();
            }
        }

        protected override TokenBase GetToken() => _developerClient.Value.GetDeveloperToken();
    }
}
