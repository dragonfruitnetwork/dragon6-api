// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Data.Requests.Base
{
    /// <summary>
    /// Base for requesting general stats from the main endpoint
    /// </summary>
    public class BasicStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Platform.StatsEndpoint();

        /// <summary>
        /// Initialises a <see cref="BasicStatsRequest"/> for a single <see cref="AccountInfo"/>
        /// </summary>
        public BasicStatsRequest(AccountInfo account)
            : base(new[] { account })
        {
        }

        /// <summary>
        /// Initialises a <see cref="BasicStatsRequest"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public BasicStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of stats to fetch (can be found in <see cref="Strings"/> namespace
        /// </summary>
        public virtual IEnumerable<string> Stats { get; set; }

        [QueryParameter("populations")]
        protected override string AccountIdString => base.AccountIdString;

        [QueryParameter("statistics")]
        public string CompiledStats => string.Join(",", Stats);
    }
}
