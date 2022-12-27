// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    /// <summary>
    /// A <see cref="IUbisoftToken"/> containing minimal data
    /// </summary>
    public class Dragon6Token : IUbisoftToken
    {
        /// <summary>
        /// App-Id must be set client side.
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiry")]
        public DateTime Expiry { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        /// <summary>
        /// Creates a <see cref="Dragon6Token"/> from a <see cref="UbisoftToken"/>
        /// </summary>
        public static Dragon6Token From(UbisoftToken token) => new()
        {
            AppId = token.AppId,
            Token = token.Token,
            Expiry = token.Expiry,
            SessionId = token.SessionId
        };
    }
}
