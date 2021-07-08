// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Tokens
{
    /// <summary>
    /// The most basic implementation of <see cref="TokenBase"/>.
    /// </summary>
    public class Dragon6Token : TokenBase
    {
        [JsonProperty("token")]
        public override string Token { get; set; }

        [JsonProperty("expiry")]
        public override DateTimeOffset Expiry { get; set; }

        [JsonProperty("session_id")]
        public override string SessionId { get; set; }

        /// <summary>
        /// Creates a <see cref="Dragon6Token"/> from a <see cref="UbisoftToken"/>
        /// </summary>
        public static explicit operator Dragon6Token(UbisoftToken token) => new()
        {
            Token = token.Token,
            Expiry = token.Expiry,
            SessionId = token.SessionId
        };
    }
}
