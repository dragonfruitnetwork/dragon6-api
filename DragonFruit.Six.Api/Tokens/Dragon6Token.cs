// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Tokens
{
    /// <summary>
    /// The most basic implimentation of <see cref="TokenBase"/>. Useful for storing the components that are actually needed
    /// </summary>
    public class Dragon6Token : TokenBase
    {
        public Dragon6Token()
        {
        }

        public Dragon6Token(UbisoftToken tokenBase)
        {
            Token = tokenBase.Token;
            Expiry = tokenBase.Expiry;
            SessionId = tokenBase.SessionId;
        }

        [JsonProperty("token")]
        public override string Token { get; set; }

        [JsonProperty("expiry")]
        public override DateTimeOffset Expiry { get; set; }

        [JsonProperty("session_id")]
        public override string SessionId { get; set; }
    }
}
