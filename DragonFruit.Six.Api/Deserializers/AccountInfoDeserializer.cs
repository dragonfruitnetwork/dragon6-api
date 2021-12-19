// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class AccountInfoDeserializer
    {
        public static IEnumerable<UbisoftAccount> DeserializeAccountInfo(this JObject json) => json[Misc.Profile] is JArray accountsJson
            ? accountsJson.Cast<JObject>().Select(DeserializeInternal)
            : Enumerable.Empty<UbisoftAccount>();

        private static UbisoftAccount DeserializeInternal(JObject data) => new()
        {
            Username = data.GetString(Accounts.Name),
            Platform = PlatformParser.PlatformEnumFor(data.GetString(Accounts.Platform)),
            Identifiers = new UserIdentifiers
            {
                Profile = data.GetString(Accounts.ProfileIdentifier),
                Platform = data.GetString(Accounts.PlatformIdentifier),
                Ubisoft = data.GetString(Accounts.UserIdentifier)
            }
        };
    }
}
