// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data.Serializers.Newtonsoft;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Authentication.Entities;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Exceptions;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class TokenDeserializer
    {
        public static UbisoftToken DeserializeToken(this JObject json)
        {
            var token = json.ToObject<UbisoftToken>() ?? throw new TokenDeserializationException();

            token.Account = new UbisoftAccount
            {
                Platform = PlatformParser.PlatformEnumFor(json.GetString(Accounts.PlatformIdentifier, "uplay")),
                Username = json.GetString(Accounts.Name),
                Identifiers = new UserIdentifiers
                {
                    Platform = json.GetString(Accounts.ProfileIdentifier)
                }
            };

            return token;
        }
    }
}
