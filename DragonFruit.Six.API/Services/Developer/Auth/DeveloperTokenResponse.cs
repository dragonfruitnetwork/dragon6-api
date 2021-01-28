// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Data.Tokens;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Services.Developer.Auth
{
    public class DeveloperTokenResponse : TokenBase
    {
        [JsonProperty("access_token")]
        public override string Token { get; set; }

        [JsonProperty("expiry")]
        public override DateTimeOffset Expiry { get; set; }
    }
}
