// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class AccountActivityDeserializer
    {
        public static ILookup<string, AccountActivity> DeserializeAccountLoginInfo(this JObject json)
        {
            var deserializedItems = json["applications"] is JArray data
                ? data.Cast<JObject>().Select(DeserializeInternal)
                : Enumerable.Empty<AccountActivity>();

            return deserializedItems.ToLookup(x => x.ProfileId);
        }

        private static AccountActivity DeserializeInternal(JObject data) => new()
        {
            ProfileId = data.GetString(Activity.Guid),
            SessionCount = data.GetUInt(Activity.Sessions),
            Platform = UbisoftIdentifiers.GameIds[data.GetString(Activity.PlatformId)],
            Activity = new ActivityDates
            {
                First = DateTimeOffset.Parse(data.GetString(Activity.FirstLogin), Dragon6Client.Culture),
                Last = DateTimeOffset.Parse(data.GetString(Activity.LastLogin), Dragon6Client.Culture)
            }
        };
    }
}
