// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;

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
        [EnumMember(Value = "all")]
        Independent = 0,

        /// <summary>
        /// Attacking Operator
        /// </summary>
        [EnumMember(Value = "attacker")]
        Attacker = 1,

        /// <summary>
        /// Defending Operator
        /// </summary>
        [EnumMember(Value = "defender")]
        Defender = 2,

        /// <summary>
        /// Attackers, Defenders and totals
        /// </summary>
        All = Attacker | Defender | Independent
    }
}
