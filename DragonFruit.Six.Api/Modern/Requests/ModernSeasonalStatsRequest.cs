// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Requests;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Utils;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernSeasonalStatsRequest : ModernStatsRequest, IRequestExecutingCallback
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

        void IRequestExecutingCallback.OnRequestExecuting(ApiClient client)
        {
            var platformQuery = !PlatformGroup.HasValue
                ? new KeyValuePair<string, string>("platform", Account.Platform.ModernName())
                : new KeyValuePair<string, string>("platformGroup", PlatformGroup.ToString());

            Queries.Clear();
            Queries.Add(platformQuery);
        }
    }
}
