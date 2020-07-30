// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class AccountLoginInfoExtensions
    {
        public static AccountLoginInfo GetLoginInfo(this Dragon6Client client, AccountInfo account) =>
            GetLoginInfo(client, new[] { account }).First();

        public static IEnumerable<AccountLoginInfo> GetLoginInfo(this Dragon6Client client, IEnumerable<AccountInfo> accounts)
        {
            var data = client.Perform<JObject>(new AccountLoginInfoRequest(Endpoints.GameIds.Select(x => x.Value), accounts));
            return data.DeserializeAccountLoginInfo();
        }
    }
}
