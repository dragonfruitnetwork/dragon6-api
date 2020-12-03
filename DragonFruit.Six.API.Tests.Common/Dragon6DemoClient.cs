// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Developer;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Exceptions;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Tests.Common
{
    /// <summary>
    /// Dragon6 Client For API Testing. Should NOT be used outside of this repo.
    /// </summary>
    public class Dragon6DemoClient : Dragon6DeveloperClient
    {
        // This is a limited access key. If you want one for your own app contact DragonFruit. If we detect this key has been abused it will be reset
        // If you're going to make an app it's likely you will need a server anyway - it's not hard to add your own token system
        public Dragon6DemoClient()
            : base(2, "obN8C3Hgi16twnv9S8LJ1Sdkieh7Hyx7qnXmoHkn6Y")
        {
        }

        protected override T ValidateAndProcess<T>(HttpResponseMessage response, HttpRequestMessage request) where T : class
        {
            try
            {
                return base.ValidateAndProcess<T>(response, request);
            }
            catch (UbisoftErrorException)
            {
                //pretend to be ubisoft club and try again
                AppId = UbisoftService.UbisoftClub.AppId();
                return Perform<T>(request);
            }
        }

        protected override TokenBase GetToken()
        {
            var token = base.GetToken();

            // the developer key we have has a limited scope so the expiry is masked - abusing this system will result in an IP ban.
            // you MUST NOT use the API developer key for any personal projects. If you want one please open an issue or contact dragonfruit
            token.Expiry = DateTimeOffset.Now.AddMinutes(5);

            return token;
        }
    }
}
