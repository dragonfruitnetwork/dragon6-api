// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using JetBrains.Annotations;

namespace DragonFruit.Six.Api.Accounts.Requests
{
    public class AccountLevelRequest : UbiApiRequest
    {
        public override string Path => Platform.CrossPlatform.SpaceUrl(1) + "/title/r6s/rewards/public_profile";

        public AccountLevelRequest(UbisoftAccount account)
        {
            Account = account;
        }

        public UbisoftAccount Account { get; }

        [UsedImplicitly]
        [QueryParameter("profile_id")]
        private string ProfileId => Account.ProfileId;
    }
}
