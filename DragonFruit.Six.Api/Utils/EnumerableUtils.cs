// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;

namespace DragonFruit.Six.Api.Utils
{
    public static class EnumerableUtils
    {
        /// <summary>
        /// Wraps an item in an <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <exception cref="NullReferenceException"><see cref="item"/> was null</exception>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item ?? throw new NullReferenceException();
        }
    }
}
