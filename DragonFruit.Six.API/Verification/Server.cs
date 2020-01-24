// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Helpers;

namespace DragonFruit.Six.API.Verification
{
    public static class Server
    {
        internal static IEnumerable<Verification> Users { get; private set; }

        public static void Init(string endpoint)
        {
            Users = d6WebRequest.GetWebObject<IEnumerable<Verification>>(endpoint);
        }

        public static Verification GetUser(string guid)
        {
            try
            {
                return Users.Single(x => x.GUID.Equals(guid, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return new Verification
                {
                    GUID = guid,
                    AccountLevel = Level.Normal
                };
            }
        }
    }
}
