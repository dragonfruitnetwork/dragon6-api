// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Enums
{
    /// <summary>
    /// Describes the side the operator is on.
    /// </summary>
    /// <remarks>
    /// Used in the Dragon6 Datasets
    /// </remarks>
    [Flags]
    public enum OperatorType
    {
        /// <summary>
        /// Attacker or Defender (i.e. Recruit)
        /// </summary>
        Independent = 0,

        /// <summary>
        /// Attacking Operator
        /// </summary>
        Attacker = 1,

        /// <summary>
        /// Defending Operator
        /// </summary>
        Defender = 2
    }
}
