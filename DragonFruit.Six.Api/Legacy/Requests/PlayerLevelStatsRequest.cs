// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;

namespace DragonFruit.Six.Api.Legacy.Requests
{
    public class PlayerLevelStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Platform.ProfileStatsEndpoint();

        public PlayerLevelStatsRequest(IEnumerable<UbisoftAccount> accounts)
            : base(accounts)
        {
        }

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        protected override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
