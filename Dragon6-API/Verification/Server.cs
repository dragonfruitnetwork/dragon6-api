using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dragon6.API.Helpers;

namespace Dragon6.API.Verification
{
    public class Server
    {
        internal static IEnumerable<Verification> Users { get; private set; }

        public static async Task Init(string endpoint)
        {
            Users = d6WebRequest.GetWebObject<IEnumerable<Verification>>(endpoint);
        }

        public static Verification GetUser(string GUID)
        {
            try
            {
                return Users.Single(x => x.GUID.Equals(GUID, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
            }

            return new Verification
            {
                GUID = GUID,
                AccountLevel = Level.Normal
            };
        }
    }
}