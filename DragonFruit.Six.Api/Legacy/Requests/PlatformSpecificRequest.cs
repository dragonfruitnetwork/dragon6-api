// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;
using DragonFruit.Six.Api.Exceptions;

namespace DragonFruit.Six.Api.Legacy.Requests
{
    /// <summary>
    /// A request involving <see cref="Accounts"/> where the <see cref="T:Platform"/> must be the same for all accounts
    /// </summary>
    public abstract class PlatformSpecificRequest : UbiApiRequest
    {
        private IEnumerable<string> _accountIds;

        protected override bool RequireAuth => true;

        protected PlatformSpecificRequest(IEnumerable<UbisoftAccount> accounts)
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
        public UbisoftAccount[] Accounts { get; }

        /// <summary>
        /// The profile ids to lookup
        /// </summary>
        protected virtual IEnumerable<string> AccountIds => _accountIds ??= Accounts.Select(x => x.ProfileId);
    }
}
