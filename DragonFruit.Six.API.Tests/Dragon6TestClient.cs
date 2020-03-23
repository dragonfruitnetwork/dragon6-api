// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Exceptions;
using DragonFruit.Six.API.Helpers;

namespace DragonFruit.Six.API.Tests
{
    public class Dragon6TestClient : Dragon6Client
    {
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
            using var client = new HttpClient();
            using var tokenTask = client.GetStringAsync("https://dragon6.dragonfruit.network/api/token");

            tokenTask.Wait();

            return new Dragon6Token
            {
                Token = tokenTask.Result,
                Expiry = DateTimeOffset.Now.AddHours(1)
            };
        }
    }
}
