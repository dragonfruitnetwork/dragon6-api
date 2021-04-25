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
        public bool Expired => GetSkewedExpiry() <= DateTimeOffset.Now;

        private DateTimeOffset GetSkewedExpiry()
        {
            if (!_safeExpiry.HasValue)
            {
                // if the ticks equals zero timespan is set to +8hrs, asking for the UtcTicks will cause an ArgumentOutOfRangeException
                // 3000000000 ticks = 5 mins
                var skewedTimeTicks = Math.Max(Expiry.UtcTicks - 3000000000, 0);
                _safeExpiry = new DateTimeOffset(skewedTimeTicks, TimeSpan.Zero);
            }

            return _safeExpiry.Value;
        }
    }
}
