// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Modern.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WeaponGroup
    {
        [JsonProperty("weaponType")]
        public string Type { get; set; }

        [JsonProperty("weapons")]
        public IEnumerable<ModernWeaponStats> Weapons { get; set; }
    }
}
