// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public class ModernOperatorStatsRequest : ModernStatsRequest
    {
        protected override string RequestType => "operators";

        public ModernOperatorStatsRequest(AccountInfo account)
            : base(account)
        {
        }
    }
}
