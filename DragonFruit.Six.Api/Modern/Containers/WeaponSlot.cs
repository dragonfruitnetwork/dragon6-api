// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonPathSerializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class WeaponSlot
    {
        [JsonProperty("primary")]
        [JsonPath("weaponSlots.primaryWeapons.weaponTypes")]
        public IEnumerable<WeaponGroup> Primary { get; set; }

        [JsonProperty("secondary")]
        [JsonPath("weaponSlots.secondaryWeapons.weaponTypes")]
        public IEnumerable<WeaponGroup> Secondary { get; set; }
    }
}
