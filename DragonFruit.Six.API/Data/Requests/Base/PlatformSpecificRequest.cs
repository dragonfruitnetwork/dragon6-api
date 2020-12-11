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
        private IEnumerable<string> _accountIds;

        protected override bool RequireAuth => true;

        protected PlatformSpecificRequest(IEnumerable<AccountInfo> accounts)
        {
            Accounts = accounts.ToArray();
            Platform = Accounts.First().Platform;

            if (Accounts.Any(x => x.Platform != Platform))
            {
                throw new AccountPlatformException(Accounts);
            }
        }

        /// <summary>
        /// The platform the accounts belong to
        /// </summary>
        public Platform Platform { get; }

        /// <summary>
        /// The accounts to perform a lookup on
        /// </summary>
        public AccountInfo[] Accounts { get; }

        /// <summary>
        /// The profile ids to lookup
        /// </summary>
        internal virtual IEnumerable<string> AccountIds => _accountIds ??= Accounts.Select(x => x.Identifiers.Profile);
    }
}
