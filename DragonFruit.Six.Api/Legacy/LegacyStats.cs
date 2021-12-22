// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Legacy
{
    [Flags]
    public enum LegacyStats
    {
        Overall = 1 << 0,
        General = 1 << 1,
        Casual = 1 << 2,
        Ranked = 1 << 3,
        Training = 1 << 4,

        Weapons = 1 << 5,
        Operators = 1 << 6,
        Playlists = 1 << 7,

        All = Overall | General | Casual | Ranked | Training | Weapons | Operators | Playlists
    }
}
