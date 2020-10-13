// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Exceptions;

namespace DragonFruit.Six.API.Data.Requests.Base
{
    /// <summary>
    /// Request type where components are specific to a <see cref="Enums.Platform"/>
    /// </summary>
    public abstract class PlatformSpecificRequest : UbiApiRequest
    {
        protected override bool RequireAuth => true;

        protected PlatformSpecificRequest(IEnumerable<AccountInfo> accounts)
        {
            Platform = accounts.First().Platform;

            if (accounts.Any(x => x.Platform != Platform))
                throw new AccountPlatformException(accounts);

            Accounts = accounts;
        }

        public Platform Platform { get; }

        public IEnumerable<AccountInfo> Accounts { get; }

        public IEnumerable<string> AccountIds => Accounts.Select(x => x.Identifiers.Profile);

        public virtual string AccountIdString => string.Join(",", AccountIds);
    }
}
