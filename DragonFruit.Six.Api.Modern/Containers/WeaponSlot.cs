// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(JsonPathConverter))]
    public class WeaponSlot
    {
        [JsonProperty("weaponSlots.primaryWeapons.weaponTypes")]
        public IEnumerable<WeaponGroup> Primary { get; set; }

        [JsonProperty("weaponSlots.secondaryWeapons.weaponTypes")]
        public IEnumerable<WeaponGroup> Secondary { get; set; }
    }
}
