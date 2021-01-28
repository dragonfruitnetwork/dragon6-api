// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Enums
{
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
