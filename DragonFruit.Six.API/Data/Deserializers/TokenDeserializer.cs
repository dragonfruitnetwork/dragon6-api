// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Helpers;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class TokenDeserializer
    {
        public static UbisoftToken DeserializeToken(this JObject jObject)
        {
            var token = jObject.ToObject<UbisoftToken>();
            token.Account = new AccountInfo
            {
                Guid = jObject.GetString(Accounts.ProfileIdentifier),
                Platform = PlatformParser.PlatformEnumFor(jObject.GetString(Accounts.PlatformIdentifier, "uplay")),
                PlayerName = jObject.GetString(Accounts.Name),
            };

            return token;
        }
    }
}
