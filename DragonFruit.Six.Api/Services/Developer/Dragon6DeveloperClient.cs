// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Basic;
using DragonFruit.Six.Api.Tokens;

namespace DragonFruit.Six.Api.Services.Developer
{
    public class Dragon6DeveloperClient : Dragon6Client
    {
        internal const string BaseEndpoint = "https://dragon6.dragonfruit.network/api/v2";

        public Dragon6DeveloperClient(string key)
        {
            Authorization = $"Dragon6-Api {key}";
        }

        protected override TokenBase GetToken() => Perform<Dragon6Token>(new BasicApiRequest($"{BaseEndpoint}/dev/token"));
    }
}
