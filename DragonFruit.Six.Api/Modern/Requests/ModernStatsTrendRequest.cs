// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Modern.Enums;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernStatsTrendRequest : ModernStatsRequest
    {
        private TrendSpan? _trendSpan;

        protected override string RequestType => "trend";

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
        protected string TrendType => TrendSpan == TrendSpan.Weekly ? "weeks" : throw new ArgumentOutOfRangeException();
    }
}
