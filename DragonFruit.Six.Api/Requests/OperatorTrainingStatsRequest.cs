// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public sealed class OperatorTrainingStatsRequest : OperatorStatsRequest
    {
        public OperatorTrainingStatsRequest(UbisoftAccount account, IEnumerable<OperatorStats> operators)
            : this(account.Yield(), operators)
        {
        }

        public OperatorTrainingStatsRequest(IEnumerable<UbisoftAccount> accounts, IEnumerable<OperatorStats> operators)
            : base(accounts, operators)
        {
        }
    }
}
