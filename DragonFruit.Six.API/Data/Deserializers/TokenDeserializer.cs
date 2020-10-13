// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class TokenDeserializer
    {
        public static UbisoftToken DeserializeToken(this JObject jObject)
        {
            var token = jObject.ToObject<UbisoftToken>();

            if (token == null)
                return null;

            token.Account = new AccountInfo
            {
                Platform = PlatformParser.PlatformEnumFor(jObject.GetString(Accounts.PlatformIdentifier, "uplay")),
                PlayerName = jObject.GetString(Accounts.Name),
                Identifiers = new UserIdentifierContainer
                {
                    Platform = jObject.GetString(Accounts.ProfileIdentifier)
                }
            };

            return token;
        }
    }
}
