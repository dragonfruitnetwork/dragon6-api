// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Data.Tokens;
using Newtonsoft.Json;

namespace DragonFruit.Six.Developer.Objects
{
    public sealed class DeveloperToken : TokenBase
    {
        [JsonProperty("token")]
        public override string Token { get; set; }

        [JsonProperty("expiry")]
        public override DateTimeOffset Expiry { get; set; }
    }
}
