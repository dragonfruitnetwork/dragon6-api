// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Enums
{
    [Flags]
    public enum PlaylistType
    {
        Ranked,
        Casual,
        Unranked,

        All = Ranked | Casual | Unranked
    }
}
