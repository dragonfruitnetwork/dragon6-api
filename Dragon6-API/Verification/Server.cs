using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dragon6.API.Verification
{
    public class Server
    {
        internal static IEnumerable<Verification> Users { get; private set; }

        private static bool IsInit = false;

        public static async Task Init(string endpoint)
        {
            Users = JsonConvert.DeserializeObject<IEnumerable<Verification>>(await new HttpClient().GetAsync(endpoint).Result.Content.ReadAsStringAsync());
            IsInit = true;
        }

        public static Verification GetUser(string GUID)
        {
            return IsInit ? Users.SingleOrDefault(x => x.GUID.Equals(GUID, StringComparison.OrdinalIgnoreCase)) : new Verification()
            {
                GUID = GUID,
                AccountLevel = Level.Normal
            };
        }
    }
}
