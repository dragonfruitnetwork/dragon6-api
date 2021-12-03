// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Tokens
{
    /// <summary>
    /// A token model used to authenticate requests against the ubisoft api
    /// </summary>
    public abstract class TokenBase
    {
        private DateTimeOffset? _skewedExpiry;

        public virtual string SessionId { get; set; }

        public abstract string Token { get; set; }
        public abstract DateTimeOffset Expiry { get; set; }

        [JsonIgnore]
        public DateTimeOffset ExpiryOffset => GetSkewedExpiry();

        [JsonIgnore]
        public bool Expired => GetSkewedExpiry() <= DateTimeOffset.Now;

        private DateTimeOffset GetSkewedExpiry()
        {
            if (!_skewedExpiry.HasValue)
            {
                // we knock off 5 mins (3000000000 ticks) to allow clock skew.
                // if the ticks equals zero when the timespan is positive (UTC)
                // asking for the UtcTicks will cause an ArgumentOutOfRangeException
                var skewedTimeTicks = Math.Max(Expiry.UtcTicks - 3000000000, 0);
                _skewedExpiry = new DateTimeOffset(skewedTimeTicks, TimeSpan.Zero);
            }

            return _skewedExpiry.Value;
        }
    }
}
