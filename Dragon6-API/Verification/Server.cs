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

        public static async Task Init(string endpoint)
        {
            Users = JsonConvert.DeserializeObject<IEnumerable<Verification>>(await new HttpClient().GetAsync(endpoint).Result.Content.ReadAsStringAsync());
        }

        public static Verification GetUser(string GUID)
        {
            try
            {
                return Users.Single(x => x.GUID.Equals(GUID, StringComparison.OrdinalIgnoreCase));
            }
            catch { }

            return new Verification()
            {
                GUID = GUID,
                AccountLevel = Level.Normal
            };
        }
    }
}
