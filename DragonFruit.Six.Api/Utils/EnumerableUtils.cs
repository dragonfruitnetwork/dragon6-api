// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;

namespace DragonFruit.Six.Api.Utils
{
    internal static class EnumerableUtils
    {
        /// <summary>
        /// Yield returns a single item
        /// </summary>
        /// <exception cref="NullReferenceException"><see cref="item"/> was null</exception>
        public static IEnumerable<T> Yield<T>(this T item)
        {
            yield return item ?? throw new NullReferenceException();
        }
    }
}
