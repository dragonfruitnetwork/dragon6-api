// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Diagnostics.CodeAnalysis;

namespace DragonFruit.Six.Api.Seasonal.Enums
{
    /// <summary>
    /// Represents the ranked regions used in-game
    /// </summary>
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum Region
    {
        EMEA = 1,
        NCSA = 2,
        APAC = 4
    }
}
