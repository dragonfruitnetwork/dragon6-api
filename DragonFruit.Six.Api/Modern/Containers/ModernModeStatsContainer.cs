// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonPathSerializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class ModernModeStatsContainer<T>
    {
        [JsonProperty("all")]
        [JsonPath("gameModes.all")]
        public ModernRoleStatsContainer<T> AllModes { get; set; }

        [JsonProperty("casual")]
        [JsonPath("gameModes.casual")]
        public ModernRoleStatsContainer<T> Casual { get; set; }

        [JsonProperty("ranked")]
        [JsonPath("gameModes.ranked")]
        public ModernRoleStatsContainer<T> Ranked { get; set; }

        [JsonProperty("unranked")]
        [JsonPath("gameModes.unranked")]
        public ModernRoleStatsContainer<T> Unranked { get; set; }
    }
}
