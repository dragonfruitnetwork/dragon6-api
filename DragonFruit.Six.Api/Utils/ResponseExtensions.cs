// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DragonFruit.Six.Api.Accounts.Entities;

namespace DragonFruit.Six.Api.Utils
{
    /// <summary>
    /// Utils to help retrieval of stats from their <see cref="ILookup{TKey,TElement}"/> containers
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Retrieves the <see cref="T"/> tied to the specified <see cref="id"/> in the <see cref="IReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <returns>The <see cref="T"/> or <c>null</c> if the <see cref="id"/> was not present</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T For<T>(this IReadOnlyDictionary<string, T> lookup, string id) where T : class => lookup.TryGetValue(id, out var result) ? result : null;

        /// <summary>
        /// Retrieves the first occurence of the specified <see cref="id"/> in the <see cref="IReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of entities, or <c>null</c> if the <see cref="id"/> was not present</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> For<T>(this ILookup<string, T> lookup, string id) where T : class => lookup[id];

        /// <summary>
        /// Attempts to retrieve the matching <see cref="id"/> from the <see cref="IReadOnlyDictionary{TKey,TElement}"/>.
        /// </summary>
        /// <returns>
        /// A <c>bool</c> representing the success state of the operation and the <see cref="output"/> variable
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRetrieveFor<T>(this IReadOnlyDictionary<string, T> lookup, string id, out T output) where T : class
        {
            output = For(lookup, id);
            return output is null;
        }

        /// <summary>
        /// Attempts to retrieve the matching <see cref="id"/> from the <see cref="IReadOnlyDictionary{TKey,TElement}"/>.
        /// </summary>
        /// <returns>
        /// A <c>bool</c> representing the success state of the operation and the <see cref="output"/> variable
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, string id, out IEnumerable<T> output) where T : class
        {
            output = For(lookup, id);
            return output is null;
        }

        #region AccountInfo Overloads

        /// <summary>
        /// Retrieves the data linked to the specified <see cref="UbisoftAccount"/> in the <see cref="IReadOnlyDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <returns>The <see cref="T"/> or <c>null</c> if the <see cref="account"/> was not present</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T For<T>(this IReadOnlyDictionary<string, T> lookup, UbisoftAccount account) where T : class => For(lookup, account.ProfileId);

        /// <summary>
        /// Retrieves the data linked to the specified <see cref="UbisoftAccount"/> in the <see cref="ILookup{TKey,TValue}"/>.
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of entities, or <c>null</c> if the <see cref="account"/> was not present</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> For<T>(this ILookup<string, T> lookup, UbisoftAccount account) where T : class => For(lookup, account.ProfileId);

        /// <summary>
        /// Attempts to retrieve the matching <see cref="account"/>'s identifier from the <see cref="IReadOnlyDictionary{TKey,TElement}"/>.
        /// </summary>
        /// <returns>
        /// A <c>bool</c> representing the success state of the operation and the <see cref="output"/> variable
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRetrieveFor<T>(this IReadOnlyDictionary<string, T> lookup, UbisoftAccount account, out T output) where T : class
        {
            output = For(lookup, account);
            return output != null;
        }

        /// <summary>
        /// Attempts to retrieve the matching <see cref="account"/>'s identifier from the <see cref="ILookup{TKey,TElement}"/>.
        /// </summary>
        /// <returns>
        /// A <c>bool</c> representing the success state of the operation and the <see cref="output"/> variable
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, UbisoftAccount account, out IEnumerable<T> output) where T : class
        {
            output = For(lookup, account);
            return output != null;
        }

        #endregion
    }
}
