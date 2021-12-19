// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Authentication.Entities
{
    /// <summary>
    /// An implementation of <see cref="IUbisoftToken"/> representing a direct response from the Ubisoft servers
    /// </summary>
    public class UbisoftToken : IUbisoftToken
    {
        [JsonProperty("expiration")]
        public DateTimeOffset Expiry { get; set; }

        [JsonProperty("ticket")]
        public string Token { get; set; }

        [JsonProperty("sessionId")]
        public string SessionId { get; set; }

        [JsonProperty("clientIp")]
        public string ClientIP { get; set; }

        [JsonProperty("clientIpCountry")]
        public string ClientCountry { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("spaceId")]
        public string SpaceId { get; set; }

        [JsonProperty("sessionKey")]
        public string SessionKey { get; set; }

        [JsonProperty("account")]
        public AccountInfo Account { get; set; }
    }
}
