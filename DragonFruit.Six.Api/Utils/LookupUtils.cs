// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Interfaces;

namespace DragonFruit.Six.Api.Utils
{
    /// <summary>
    /// Utils to help retrieval of stats from their <see cref="ILookup{TKey,TElement}"/> containers
    /// </summary>
    public static class LookupUtils
    {
        /// <summary>
        /// Retrieves the first occurence of the specified key in the lookup.
        /// Returns null if not found
        /// </summary>
        public static T For<T>(this ILookup<string, T> lookup, string id) where T : IStatsResponse => lookup[id].FirstOrDefault();

        /// <summary>
        /// Retrieves all occurances for the specified key in the lookup.
        /// Returns null if no entries were found
        /// </summary>
        public static IEnumerable<T> AllFor<T>(this ILookup<string, T> lookup, string id) where T : IMultiElementStatsResponse => lookup[id];

        /// <summary>
        /// Tries to retrieve the matching entity from the <see cref="ILookup{TKey,TElement}"/>.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, string id, out T output) where T : IStatsResponse
        {
            output = For(lookup, id);
            return output != null;
        }

        /// <summary>
        /// Tries to retrieve all matching entities from the <see cref="ILookup{TKey,TElement}"/>.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveAllFor<T>(this ILookup<string, T> lookup, string id, out IEnumerable<T> output) where T : IMultiElementStatsResponse
        {
            output = AllFor(lookup, id);
            return output != null;
        }

        #region AccountInfo Overloads

        /// <summary>
        /// Retrieves the item with a reference to the user's profile id.
        /// Returns null if not found
        /// </summary>
        public static T For<T>(this ILookup<string, T> lookup, AccountInfo account) where T : IStatsResponse => For(lookup, account.Identifiers.Profile);

        /// <summary>
        /// Retrieves any item with a reference to the user's profile id.
        /// Returns null if not found
        /// </summary>
        public static IEnumerable<T> AllFor<T>(this ILookup<string, T> lookup, AccountInfo account) where T : IMultiElementStatsResponse => AllFor(lookup, account.Identifiers.Profile);

        /// <summary>
        /// Tries to retrieve the item with the reference to the user's profile id.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, AccountInfo account, out T output) where T : IStatsResponse
        {
            output = For(lookup, account);
            return output != null;
        }

        /// <summary>
        /// Tries to retrieve all items with a reference to the user's profile id.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveAllFor<T>(this ILookup<string, T> lookup, AccountInfo account, out IEnumerable<T> output) where T : IMultiElementStatsResponse
        {
            output = AllFor(lookup, account);
            return output != null;
        }

        #endregion
    }
}
