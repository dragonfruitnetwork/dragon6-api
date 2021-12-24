// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy.Utils;

namespace DragonFruit.Six.Api.Legacy.Requests
{
    /// <summary>
    /// Base for requesting general stats from the main endpoint
    /// </summary>
    public class LegacyStatsRequest : PlatformSpecificRequest
    {
        private IEnumerable<string> _stats;

        public override string Path => Platform.StatsEndpoint();

        /// <summary>
        /// Initialises a <see cref="LegacyStatsRequest"/> for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public LegacyStatsRequest(IEnumerable<UbisoftAccount> accounts, LegacyStatTypes stats)
            : base(accounts)
        {
            Types = stats;
        }

        /// <summary>
        /// The <see cref="LegacyStatTypes"/> to retrieve with this request
        /// </summary>
        public LegacyStatTypes Types { get; set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> of stats to fetch (can be found in <see cref="Strings"/> namespace)
        /// </summary>
        /// <remarks>
        /// If unset, this will use the <see cref="Types"/> property and resolve the default stats
        /// </remarks>
        [QueryParameter("statistics", CollectionConversionMode.Concatenated)]
        public virtual IEnumerable<string> StatsKeys
        {
            get => _stats ?? Types.GetDefaultStats();
            set => _stats = value;
        }

        [QueryParameter("populations", CollectionConversionMode.Concatenated)]
        protected override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
