// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class PlayerLevelStatsRequest : PlatformSpecificRequest
    {
        public override string Path => Platform.ProfileStatsEndpoint();

        public PlayerLevelStatsRequest(UbisoftAccount account)
            : this(account.Yield())
        {
        }

        public PlayerLevelStatsRequest(IEnumerable<UbisoftAccount> accounts)
            : base(accounts)
        {
        }

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        protected override IEnumerable<string> AccountIds => base.AccountIds;
    }
}
