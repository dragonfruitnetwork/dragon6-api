// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Data.Containers;
using DragonFruit.Six.Api.Data.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Data.Deserializers
{
    public static class AccountInfoDeserializer
    {
        public static IEnumerable<AccountInfo> DeserializeAccountInfo(this JObject jObject)
        {
            var accountsJson = jObject[Misc.Profile];

            if (accountsJson == null)
                yield break;

            foreach (var jToken in JArray.FromObject(accountsJson))
            {
                var item = (JObject)jToken;
                yield return new AccountInfo
                {
                    PlayerName = item.GetString(Accounts.Name),
                    Platform = PlatformParser.PlatformEnumFor(item.GetString(Accounts.Platform)),
                    Identifiers = new UserIdentifiers
                    {
                        Profile = item.GetString(Accounts.ProfileIdentifier),
                        Platform = item.GetString(Accounts.PlatformIdentifier),
                        Ubisoft = item.GetString(Accounts.UserIdentifier)
                    }
                };
            }
        }
    }
}
