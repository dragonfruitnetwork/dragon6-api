// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Developer.Objects
{
    public sealed class PublicToken
    {
        public PublicToken()
        {
        }

        public PublicToken(string eToken)
        {
            EncryptedToken = eToken;
        }

        [JsonProperty("eToken")]
        public string EncryptedToken { get; set; }
    }
}
