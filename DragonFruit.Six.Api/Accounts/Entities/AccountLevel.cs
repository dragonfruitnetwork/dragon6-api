// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Accounts.Entities
{
    public class AccountLevel
    {
        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("xp")]
        public int XP { get; set; }
    }
}
