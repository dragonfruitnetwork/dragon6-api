// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;

namespace DragonFruit.Six.Api.Modern.Enums
{
    [Flags]
    public enum PlaylistType
    {
        [EnumMember(Value = "all")]
        Independent = 0,

        [EnumMember(Value = "casual")]
        Casual = 1,

        [EnumMember(Value = "ranked")]
        Ranked = 2,

        [EnumMember(Value = "unranked")]
        Unranked = 3,

        All = Casual | Ranked | Unranked | Independent
    }
}
