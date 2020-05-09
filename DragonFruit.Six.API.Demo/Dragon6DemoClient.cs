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
        private Dragon6DeveloperClient _developerClient;
        private readonly string _devKey;

        public Dragon6DemoClient(string devKey)
        {
            _devKey = devKey;

            if (string.IsNullOrWhiteSpace(devKey))
            {
                Console.WriteLine("No Developer Key Available, if you need one, please request one by creating an issue on the GitHub Repo");
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

        protected override TokenBase GetToken() => DeveloperClient.GetDeveloperToken();
    }
}
