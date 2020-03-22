// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Data.Requests.Base
{
    /// <summary>
    /// Base for requesting stats from the main endpoint
    /// </summary>
    public class BasicStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Endpoints.Stats[Accounts.First().Platform];

        public BasicStatsRequest(AccountInfo account)
            : base(new[] { account })
        {
        }

        public BasicStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public virtual IEnumerable<string> Stats { get; set; }

        [QueryParameter("populations")]
        public override string AccountIdString => base.AccountIdString;

        [QueryParameter("statistics")]
        public string CompiledStats => string.Join(',', Stats);
    }
}
