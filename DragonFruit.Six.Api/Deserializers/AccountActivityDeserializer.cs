// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class AccountActivityDeserializer
    {
        public static IEnumerable<AccountActivity> DeserializeAccountLoginInfo(this JObject jObject)
        {
            var data = jObject["applications"] as JArray;

            if (data == null)
                yield break;

            foreach (var jToken in data)
            {
                var entry = (JObject)jToken;
                yield return new AccountActivity
                {
                    Guid = entry.GetString(Activity.Guid),
                    SessionCount = entry.GetUInt(Activity.Sessions),
                    Platform = UbisoftIdentifiers.GameIds[entry.GetString(Activity.PlatformId)],
                    Activity = new ActivityDates
                    {
                        First = DateTimeOffset.Parse(entry.GetString(Activity.FirstLogin), Dragon6Client.Culture),
                        Last = DateTimeOffset.Parse(entry.GetString(Activity.LastLogin), Dragon6Client.Culture)
                    }
                };
            }
        }
    }
}
