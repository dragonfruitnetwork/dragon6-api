// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Seasonal.Enums
{
    /// <summary>
    /// Represents the seasonal ranking boards available for querying
    /// </summary>
    [Flags]
    public enum BoardType
    {
        Ranked = 1,
        Casual = 2
    }
}
