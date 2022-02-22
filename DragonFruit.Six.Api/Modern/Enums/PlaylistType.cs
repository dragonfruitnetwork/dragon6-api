// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Enums
{
    [Flags]
    public enum PlaylistType
    {
        Casual = 1 << 0,
        Ranked = 1 << 1,
        Unranked = 1 << 2,

        All = 1 << 3
    }
}
