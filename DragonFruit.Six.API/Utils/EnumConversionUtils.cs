// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;

namespace DragonFruit.Six.API.Utils
{
    internal static class EnumConversionUtils
    {
        /// <summary>
        /// Converts a bitwise flag into a comma-separated string
        /// </summary>
        public static string Expand<T>(this T enumValue) where T : Enum
        {
            return string.Join(",", Enum.GetValues(typeof(T))
                                        .Cast<T>()
                                        .Where(x => enumValue.HasFlag(x))
                                        .Select(x => x.ToString().ToLower()));
        }
    }
}
