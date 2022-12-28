// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DragonFruit.Six.Api.Seasonal.Enums
{
    /// <summary>
    /// Represents the seasonal ranking boards available for querying
    /// </summary>
    [Flags]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BoardType
    {
        [EnumMember(Value = "pvp_ranked")]
        Ranked = 1,

        [EnumMember(Value = "pvp_casual")]
        Casual = 2,

        [EnumMember(Value = "pvp_warmup")]
        Warmup = 4,

        [EnumMember(Value = "pvp_event")]
        Event = 8,

        All = Ranked | Casual | Warmup | Event
    }
}
