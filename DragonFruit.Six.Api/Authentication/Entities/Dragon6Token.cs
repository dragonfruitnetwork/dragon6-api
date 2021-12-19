// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    /// <summary>
    /// A <see cref="IUbisoftToken"/> containing minimal data
    /// </summary>
    public class Dragon6Token : IUbisoftToken
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiry")]
        public DateTimeOffset Expiry { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Creates a <see cref="Dragon6Token"/> from a <see cref="UbisoftToken"/>
        /// </summary>
        public static Dragon6Token From(UbisoftToken token) => new()
        {
            Token = token.Token,
            Expiry = token.Expiry,
            SessionId = token.SessionId
        };
    }
}
