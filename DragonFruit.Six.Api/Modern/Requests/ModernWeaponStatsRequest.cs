// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Accounts.Entities;

namespace DragonFruit.Six.Api.Modern.Requests
{
    public class ModernWeaponStatsRequest : ModernStatsRequest
    {
        protected override string RequestType => "weapons";

        public ModernWeaponStatsRequest(UbisoftAccount account)
            : base(account)
        {
        }
    }
}
