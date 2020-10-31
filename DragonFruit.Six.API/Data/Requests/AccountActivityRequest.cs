// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.API.Data.Requests.Base;
using DragonFruit.Six.API.Utils;

namespace DragonFruit.Six.API.Data.Requests
{
    public class AccountActivityRequest : UbiApiRequest
    {
        public override string Path => $"{Endpoints.IdServer}/applications";

        public AccountActivityRequest(AccountInfo profile)
            : this(new[] { profile })
        {
        }

        public AccountActivityRequest(IEnumerable<AccountInfo> profiles)
        {
            Accounts = profiles;
            AppIds = UbisoftIdentifiers.GameIds.Keys;
        }

        /// <summary>
        /// The ids of the apps to check activity for
        /// </summary>
        public IEnumerable<string> AppIds { get; set; }

        /// <summary>
        /// The accounts to check against the activity logs for <see cref="AppIds"/>
        /// </summary>
        public IEnumerable<AccountInfo> Accounts { get; set; }

        [QueryParameter("applicationIds")]
        protected string AppIdString => string.Join(",", AppIds);

        [QueryParameter("profileIds")]
        protected string ProfileIdString => string.Join(",", Accounts.Select(x => x.Identifiers.Profile));
    }
}
