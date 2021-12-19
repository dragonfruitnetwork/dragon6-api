// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Accounts
{
    public static class UbisoftAccountDeserializers
    {
        public static IEnumerable<UbisoftAccount> DeserializeUbisoftAccounts(this JObject json)
        {
            return json["profiles"].ToObject<IEnumerable<UbisoftAccount>>();
        }

        public static ILookup<string, UbisoftAccountActivity> DeserializeUbisoftAccountActivity(this JObject json)
        {
            return json["applications"].ToObject<IEnumerable<UbisoftAccountActivity>>().ToLookup(x => x.ProfileId);
        }
    }
}
