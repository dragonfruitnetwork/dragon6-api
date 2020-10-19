// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class AccountActivityExtensions
    {
        public static AccountActivity GetLoginInfo<T>(this T client, AccountInfo account) where T : Dragon6Client
            => GetLoginInfo(client, new[] { account }).First();

        public static IEnumerable<AccountActivity> GetLoginInfo<T>(this T client, IEnumerable<AccountInfo> accounts) where T : Dragon6Client
        {
            var data = client.Perform<JObject>(new AccountActivityRequest(accounts));
            return data.DeserializeAccountLoginInfo();
        }
    }
}
