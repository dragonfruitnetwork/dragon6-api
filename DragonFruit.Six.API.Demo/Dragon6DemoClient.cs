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

namespace DragonFruit.Six.API.Demo
{
    public class Dragon6DemoClient : Dragon6Client
    {
        private const string EnvironmentVariableName = "devKey";

        private static string DevKey => RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
#if !DEBUG
            ? Environment.GetEnvironmentVariable(EnvironmentVariableName, EnvironmentVariableTarget.Process)
#else
            ? Environment.GetEnvironmentVariable(EnvironmentVariableName, EnvironmentVariableTarget.User)
#endif
            : Environment.GetEnvironmentVariable(EnvironmentVariableName);

        public Dragon6DemoClient()
        {
            if (string.IsNullOrWhiteSpace(DevKey))
            {
                Console.WriteLine("No Developer Key Available, if you need one, please request one by creating an issue on the GitHub Repo");
                Environment.Exit(2);
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
