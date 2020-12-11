// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class OperatorStatsRequest : StatsRequestBase
    {
        public OperatorStatsRequest(AccountInfo account, IEnumerable<OperatorStats> operators)
            : this(new[] { account }, operators)
        {
        }

        public OperatorStatsRequest(IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators)
            : base(accounts)
        {
            Stats = operators.Select(x => x.OperatorActionId).Where(x => !string.IsNullOrWhiteSpace(x)).Concat(new[]
            {
                Operator.Kills,
                Operator.Deaths,

                Operator.Headshots,
                Operator.Downs,

                Operator.Wins,
                Operator.Losses,

                Operator.Rounds,
                Operator.Time,

                Operator.Experience
            });
        }
    }
}
