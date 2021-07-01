// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Parameters;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Requests.Base;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class AccountActivityRequest : UbiApiRequest
    {
        public override string Path => $"{Endpoints.IdServer}/applications";

        public AccountActivityRequest(AccountInfo profile)
            : this(profile.Yield())
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
        [QueryParameter("applicationIds", CollectionConversionMode.Concatenated)]
        public IEnumerable<string> AppIds { get; set; }

        /// <summary>
        /// A <see cref="IEnumerable{T}"/> of profile ids to use. If set, this will ignore the <see cref="Accounts"/> property
        /// </summary>
        public IEnumerable<string> Profiles { get; set; }

        /// <summary>
        /// The accounts to check against the activity logs for <see cref="AppIds"/>
        /// </summary>
        public IEnumerable<AccountInfo> Accounts { get; set; }

        [QueryParameter("profileIds", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> ProfileIdString => Profiles ?? Accounts.Select(x => x.Identifiers.Profile);
    }
}
