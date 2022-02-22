// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Runtime.CompilerServices;

namespace DragonFruit.Six.Api.Modern.Utils
{
    public static class ValueUtils
    {
        /// <summary>
        /// Attempts to apply a nullable value to a field using an <see cref="Action"/>
        /// </summary>
        /// <param name="value">The value to set</param>
        /// <param name="setter">The <see cref="Action"/> to invoke to set the value</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ApplyValue<T>(T? value, Action<T> setter) where T : struct
        {
            if (value.HasValue)
            {
                setter(value.Value);
            }
        }
    }
}
