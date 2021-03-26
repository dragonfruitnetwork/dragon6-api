// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Tokens
{
    public abstract class TokenBase
    {
        private DateTimeOffset? _safeExpiry;

        public virtual string SessionId { get; set; }

        public abstract string Token { get; set; }
        public abstract DateTimeOffset Expiry { get; set; }

        [JsonIgnore]
        public bool Expired => InternalExpiry <= DateTimeOffset.Now;

        [JsonIgnore]
        private DateTimeOffset InternalExpiry => _safeExpiry ??= Expiry.AddMinutes(-5);
    }
}
