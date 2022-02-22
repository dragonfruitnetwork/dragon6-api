// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernSeasonalStatsRequest : ModernStatsRequest
    {
        protected override string RequestCategory => "seasonal";
        protected override string RequestType => "summary";

        public ModernSeasonalStatsRequest(UbisoftAccount account)
            : base(account)
        {
        }

        public override DateTimeOffset StartDate
        {
            get => default;
            set => throw new NotSupportedException();
        }

        public override DateTimeOffset EndDate
        {
            get => default;
            set => throw new NotSupportedException();
        }

        public override OperatorType OperatorType
        {
            get => default;
            set => throw new NotSupportedException();
        }

        protected override string FormattedStartDate => null;
        protected override string FormattedEndDate => null;
        protected override string OperatorTypeNames => null;
    }
}
