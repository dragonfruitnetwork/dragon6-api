// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class AccountLoginInfoRequest : UbiApiRequest
    {
        public AccountLoginInfoRequest()
        {
        }

        public AccountLoginInfoRequest(string appId, AccountInfo profileId)
            : this(new[] { appId }, new[] { profileId })
        {
        }

        public AccountLoginInfoRequest(string appId, IEnumerable<AccountInfo> profileIds)
            : this(new[] { appId }, profileIds)
        {
        }

        public AccountLoginInfoRequest(IEnumerable<string> appIds, AccountInfo profileId)
            : this(appIds, new[] { profileId })
        {
        }

        public AccountLoginInfoRequest(IEnumerable<string> appIds, IEnumerable<AccountInfo> profileIds)
        {
            AppIds = appIds;
            Accounts = profileIds;
        }

        public override string Path => $"{Endpoints.IdServer}/applications";

        public IEnumerable<string> AppIds { get; set; }

        public IEnumerable<AccountInfo> Accounts { get; set; }

        [QueryParameter("applicationIds")]
        public string AppIdString => string.Join(',', AppIds);

        [QueryParameter("profileIds")]
        public string ProfileIdString => string.Join(',', Accounts.Select(x => x.Identifiers.Profile));
    }
}
