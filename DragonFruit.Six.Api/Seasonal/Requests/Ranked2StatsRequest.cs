// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Seasonal.Requests
{
    public class Ranked2StatsRequest : UbiApiRequest
    {
        public override string Path => Platform.CrossPlatform.SpaceUrl(2) + "/title/r6s/skill/full_profiles";

        protected override UbisoftService? RequiredTokenSource => UbisoftService.RainbowSixClient;

        public Ranked2StatsRequest(IEnumerable<UbisoftAccount> accounts, PlatformGroup platforms)
        {
            Accounts = accounts;
            PlatformGroups = platforms;
        }

        public IEnumerable<UbisoftAccount> Accounts { get; set; }

        [QueryParameter("platform_families", EnumHandlingMode.StringLower)]
        public PlatformGroup PlatformGroups { get; set; }

        [QueryParameter("profile_ids", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> AccountIdentifiers => Accounts.Select(x => x.ProfileId);
    }
}
