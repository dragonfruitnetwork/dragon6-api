// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonPathSerializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernRoleStatsContainer<T>
    {
        [JsonProperty("all")]
        [JsonPath("teamRoles.all")]
        public T AsAny { get; set; }

        [JsonProperty("attacker")]
        [JsonPath("teamRoles.attacker")]
        public T AsAttacker { get; set; }

        [JsonProperty("defender")]
        [JsonPath("teamRoles.defender")]
        public T AsDefender { get; set; }
    }
}
