// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    [JsonObject(MemberSerialization.OptIn)]
    [JsonConverter(typeof(JsonPathConverter))]
    public class ModernRoleStatsContainer<T>
    {
        public T this[OperatorType type] => type switch
        {
            OperatorType.Independent => AsAny,
            OperatorType.Attacker => AsAttacker,
            OperatorType.Defender => AsDefender,

            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        [JsonProperty("teamRoles.all")]
        public T AsAny { get; set; }

        [JsonProperty("teamRoles.attacker")]
        public T AsAttacker { get; set; }

        [JsonProperty("teamRoles.defender")]
        public T AsDefender { get; set; }
    }
}
