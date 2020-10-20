// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Exceptions
{
    public class AccountPlatformException : Exception
    {
        public AccountPlatformException(IEnumerable<AccountInfo> accounts)
            : base("A platform-specific request was formed with accounts from multiple platforms.")
        {
            FoundPlatforms = accounts.Select(x => x.Platform).Distinct();
        }

        public IEnumerable<Platform> FoundPlatforms { get; set; }
    }
}
