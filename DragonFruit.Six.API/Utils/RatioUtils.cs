// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.API.Utils
{
    public static class RatioUtils
    {
        /// <summary>
        /// Convert two <see cref="object"/>s to a ratio
        /// </summary>
        public static float RatioOf<T>(T value, T against) where T : struct
        {
            // convert
            var value1 = Convert.ToSingle(value);
            var value2 = Convert.ToSingle(against);

            // eliminate any invalids (zeros)
            value1 = value1 == 0 ? 1 : value1;
            value2 = value2 == 0 ? 1 : value2;

            // calculate
            return value1 / value2;
        }
    }
}
