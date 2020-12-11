// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;

namespace DragonFruit.Six.API.Data.Requests.Base
{
    /// <summary>
    /// Base for requesting general stats from the main endpoint
    /// </summary>
    public class StatsRequestBase : PlatformSpecificRequest
    {
        public override string Path => Platform.StatsEndpoint();

        /// <summary>
        /// Initialises a <see cref="StatsRequestBase"/> for a single <see cref="AccountInfo"/>
        /// </summary>
        public StatsRequestBase(AccountInfo account)
            : base(new[] { account })
        {
        }

        /// <summary>
        /// Initialises a <see cref="StatsRequestBase"/> for an array of <see cref="AccountInfo"/>s
        /// </summary>
        public StatsRequestBase(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of stats to fetch (can be found in <see cref="Strings"/> namespace
        /// </summary>
        [QueryParameter("statistics", CollectionConversionMode.Concatenated)]
        public virtual IEnumerable<string> Stats { get; set; }

        /// <inheritdoc />
        [QueryParameter("populations", CollectionConversionMode.Concatenated)]
        internal override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
