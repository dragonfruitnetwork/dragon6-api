// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Data.Strings;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class ClassicOperatorStatsRequest : ClassicStatsRequestBase
    {
        public ClassicOperatorStatsRequest(AccountInfo account, IEnumerable<ClassicOperatorStats> operators)
            : this(new[] { account }, operators)
        {
        }

        public ClassicOperatorStatsRequest(IEnumerable<AccountInfo> accounts, IEnumerable<ClassicOperatorStats> operators)
            : base(accounts)
        {
            Stats = operators.Select(x => x.OperatorActionId).Where(x => !string.IsNullOrWhiteSpace(x)).Concat(new[]
            {
                ClassicOperator.Kills,
                ClassicOperator.Deaths,

                ClassicOperator.Headshots,
                ClassicOperator.Downs,

                ClassicOperator.Wins,
                ClassicOperator.Losses,

                ClassicOperator.Rounds,
                ClassicOperator.Time,

                ClassicOperator.Experience
            });
        }
    }
}
