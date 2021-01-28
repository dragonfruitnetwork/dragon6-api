// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Tokens
{
    public abstract class TokenBase
    {
        public abstract string Token { get; set; }

        public abstract DateTimeOffset Expiry { get; set; }

        public virtual string SessionId { get; set; }

        [JsonIgnore]
        public bool Expired => DateTimeOffset.Compare(DateTimeOffset.Now, Expiry) >= 0;
    }
}
