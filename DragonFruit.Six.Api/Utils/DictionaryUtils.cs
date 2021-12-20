// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;

namespace DragonFruit.Six.Api.Utils
{
    /// <summary>
    /// Utils to help retrieval of stats from their <see cref="ILookup{TKey,TElement}"/> containers
    /// </summary>
    public static class DictionaryUtils
    {
        /// <summary>
        /// Retrieves the first occurence of the specified key in the lookup.
        /// Returns null if not found
        /// </summary>
        public static T For<T>(this IReadOnlyDictionary<string, T> lookup, string id) where T : class
        {
            return lookup.TryGetValue(id, out var result) ? result : null;
        }

        /// <summary>
        /// Tries to retrieve the matching entity from the <see cref="IReadOnlyDictionary{TKey,TElement}"/>.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveFor<T>(this IReadOnlyDictionary<string, T> lookup, string id, out T output) where T : class
        {
            output = For(lookup, id);
            return output != null;
        }

        #region AccountInfo Overloads

        /// <summary>
        /// Retrieves the item with a reference to the user's profile id.
        /// Returns null if not found
        /// </summary>
        public static T For<T>(this IReadOnlyDictionary<string, T> lookup, UbisoftAccount account) where T : class
        {
            return For(lookup, account.ProfileId);
        }

        /// <summary>
        /// Tries to retrieve the item with the reference to the user's profile id.
        /// Returns a <c>bool</c> representing the success state of the operation
        /// </summary>
        public static bool TryRetrieveFor<T>(this IReadOnlyDictionary<string, T> lookup, UbisoftAccount account, out T output) where T : class
        {
            output = For(lookup, account);
            return output != null;
        }
        
        #endregion
    }
}
