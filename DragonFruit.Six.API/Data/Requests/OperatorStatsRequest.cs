// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class OperatorStatsRequest : BasicStatsRequest
    {
        public OperatorStatsRequest(AccountInfo account, IEnumerable<OperatorStats> operators)
            : this(new[] { account }, operators)
        {
        }

        public OperatorStatsRequest(IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators)
            : base(accounts)
        {
            Stats = operators.Select(x => x.Action).Where(x => !string.IsNullOrWhiteSpace(x)).Concat(new[]
            {
                "operatorpvp_kills",
                "operatorpvp_headshot",
                "operatorpvp_dbno",
                "operatorpvp_death",
                "operatorpvp_roundlost",
                "operatorpvp_roundplayed",
                "operatorpvp_roundwlratio",
                "operatorpvp_roundwon",
                "operatorpvp_timeplayed"
            });
        }
    }
}
