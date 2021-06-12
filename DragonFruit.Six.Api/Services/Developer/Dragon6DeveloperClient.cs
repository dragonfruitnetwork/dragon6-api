// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Tokens;
using DragonFruit.Six.Api.Services.Developer.Auth;

namespace DragonFruit.Six.Api.Services.Developer
{
    public class Dragon6DeveloperClient : Dragon6Client
    {
        public Dragon6DeveloperClient(string key)
        {
            Authorization = $"Dragon6-Api {key}";
        }

        protected override TokenBase GetToken() => Perform<Dragon6Token>(new DeveloperTokenRequest());
    }
}
