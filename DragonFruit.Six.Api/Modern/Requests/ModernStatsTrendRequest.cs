// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Modern.Enums;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernStatsTrendRequest : ModernStatsRequest
    {
        private TrendSpan? _trendSpan;

        protected override string RequestType => "movingpoint";

        public ModernStatsTrendRequest(UbisoftAccount account)
            : base(account)
        {
        }

        public TrendSpan TrendSpan
        {
            get => _trendSpan ??= TrendSpan.Weekly;
            set => _trendSpan = value;
        }

        [QueryParameter("trendType")]
        protected string TrendType => TrendSpan.ToString().ToLowerInvariant();
    }
}
