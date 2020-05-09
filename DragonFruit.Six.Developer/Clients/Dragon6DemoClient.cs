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
using DragonFruit.Six.Developer.Extensions;

namespace DragonFruit.Six.Developer.Clients
{
    /// <summary>
    /// Dragon6 Client For API Testing. Should NOT be used outside of this repo.
    /// </summary>
    public class Dragon6DemoClient : Dragon6Client
    {
        private Dragon6DeveloperClient _developerClient;
        private readonly string _devKey;

        public Dragon6DemoClient()
        {
            _devKey = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? Environment.GetEnvironmentVariable("devKey", EnvironmentVariableTarget.User)
                : Environment.GetEnvironmentVariable("devKey");

            if (string.IsNullOrWhiteSpace(_devKey))
            {
#if DEBUG
                Console.WriteLine("No Developer Key Available, if you need one, please request one by creating an issue on the GitHub Repo");
#endif
                Environment.Exit(2);
            }
        }

        private Dragon6DeveloperClient DeveloperClient => _developerClient ??= new Dragon6DeveloperClient(_devKey);

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

        protected override TokenBase GetToken()
        {
            var token = DeveloperClient.GetDeveloperToken();

            //the developer key we have has a limited scope so the expiry is masked - abusing this system will result in an IP ban.
            //you MUST NOT use the API developer key for any personal projects. If you want one please open an issue or contact dragonfruit
            token.Expiry = DateTimeOffset.Now.AddMinutes(5);

            return token;
        }
    }
}
