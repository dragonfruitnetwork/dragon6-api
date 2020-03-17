// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class AccountLoginInfoDeserializer
    {
        public static IEnumerable<AccountLoginInfo> DeserializeAccountLoginInfo(this JObject jObject)
        {
            var data = (JArray)jObject["applications"];
            var platformLookup = Endpoints.GameIds.ToDictionary(x => x.Value, x => x.Key);

            foreach (var jToken in data)
            {
                var entry = (JObject)jToken;
                yield return new AccountLoginInfo
                {
                    Guid = entry.GetString(LoginData.Guid),
                    Activity = new ActivityDateContainer
                    {
                        First = DateTimeOffset.Parse(entry.GetString(LoginData.FirstLogin), References.Culture),
                        Last = DateTimeOffset.Parse(entry.GetString(LoginData.LastLogin), References.Culture)
                    },
                    SessionCount = entry.GetUInt(LoginData.Sessions),
                    Platform = platformLookup[entry.GetString(LoginData.PlatformId)]
                };
            }
        }
    }
}
