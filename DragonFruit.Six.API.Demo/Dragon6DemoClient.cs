// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data.Tokens;

namespace DragonFruit.Six.API.Demo
{
    public class Dragon6DemoClient : Dragon6Client
    {
        public string URL { get; }

        public Dragon6DemoClient(string url)
        {
            URL = url;
        }

        public override string AppId { get; set; } = "314d4fef-e568-454a-ae06-43e3bece12a6";

        protected override TokenBase GetToken()
        {
            using var client = new HttpClient();
            using var tokenTask = client.GetStringAsync(URL);

            tokenTask.Wait();

            return new Dragon6Token
            {
                Token = tokenTask.Result,
                Expiry = DateTimeOffset.Now.AddHours(1)
            };
        }
    }
}
