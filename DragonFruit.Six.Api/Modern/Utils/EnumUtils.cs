// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace DragonFruit.Six.Api.Modern.Utils
{
    internal static class EnumUtils
    {
        /// <summary>
        /// Converts a bitwise flag into a comma-separated string
        /// </summary>
        public static string Expand<T>(this T enumValue) where T : unmanaged, Enum
        {
            return string.Join(",", Enum.GetValues(typeof(T))
                                        .Cast<T>()
                                        .Where(x => enumValue.HasFlagFast(x))
                                        .Select(x => x.ToString().ToLower()));
        }

        /// <summary>
        /// Checks whether a specific flag is present.
        /// </summary>
        [Pure]
        internal static unsafe bool HasFlagFast<T>(this T enumValue, T flag) where T : unmanaged, Enum
        {
            switch (sizeof(T))
            {
                case 1:
                {
                    var value1 = Unsafe.As<T, byte>(ref enumValue);
                    var value2 = Unsafe.As<T, byte>(ref flag);
                    return (value1 & value2) == value2;
                }

                case 2:
                {
                    var value1 = Unsafe.As<T, short>(ref enumValue);
                    var value2 = Unsafe.As<T, short>(ref flag);
                    return (value1 & value2) == value2;
                }

                case 4:
                {
                    var value1 = Unsafe.As<T, int>(ref enumValue);
                    var value2 = Unsafe.As<T, int>(ref flag);
                    return (value1 & value2) == value2;
                }

                case 8:
                {
                    var value1 = Unsafe.As<T, long>(ref enumValue);
                    var value2 = Unsafe.As<T, long>(ref flag);
                    return (value1 & value2) == value2;
                }

                default:
                {
                    throw new ArgumentException($"Invalid enum type provided: {typeof(T)}.");
                }
            }
        }
    }
}
