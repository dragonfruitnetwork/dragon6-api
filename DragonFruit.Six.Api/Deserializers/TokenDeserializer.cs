// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Tokens;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class TokenDeserializer
    {
        public static UbisoftToken DeserializeToken(this JObject json)
        {
            var token = json.ToObject<UbisoftToken>();

            if (token == null)
                return null;

            token.Account = new AccountInfo
            {
                Platform = PlatformParser.PlatformEnumFor(json.GetString(Accounts.PlatformIdentifier, "uplay")),
                PlayerName = json.GetString(Accounts.Name),
                Identifiers = new UserIdentifiers
                {
                    Platform = json.GetString(Accounts.ProfileIdentifier)
                }
            };

            return token;
        }
    }
}
