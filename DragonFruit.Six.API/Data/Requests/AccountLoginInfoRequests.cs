// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Helpers;

namespace DragonFruit.Six.API.Data.Requests
{
    public class AccountLoginInfoRequest : UbiApiRequest
    {
        public AccountLoginInfoRequest(AccountInfo profile)
            : this(new[] { profile })
        {
        }

        public AccountLoginInfoRequest(IEnumerable<AccountInfo> profiles)
        {
            Accounts = profiles;
            AppIds = UbisoftIdentifiers.GameIds.Values;
        }

        public override string Path => $"{Endpoints.IdServer}/applications";

        public IEnumerable<string> AppIds { get; set; }

        public IEnumerable<AccountInfo> Accounts { get; set; }

        [QueryParameter("applicationIds")]
        public string AppIdString => string.Join(",", AppIds);

        [QueryParameter("profileIds")]
        public string ProfileIdString => string.Join(",", Accounts.Select(x => x.Identifiers.Profile));
    }
}
