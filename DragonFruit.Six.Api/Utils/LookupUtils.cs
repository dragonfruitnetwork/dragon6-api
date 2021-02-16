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
        public static T For<T>(this ILookup<string, T> lookup, string id) where T : IStatsResponse => lookup[id].FirstOrDefault();

        public static IEnumerable<T> AllFor<T>(this ILookup<string, T> lookup, string id) where T : IMultiElementStatsResponse => lookup[id];

        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, string id, out T output) where T : IStatsResponse
        {
            output = For(lookup, id);
            return output != null;
        }

        public static bool TryRetrieveAllFor<T>(this ILookup<string, T> lookup, string id, out IEnumerable<T> output) where T : IMultiElementStatsResponse
        {
            output = AllFor(lookup, id);
            return output != null;
        }

        #region AccountInfo Overloads

        public static T For<T>(this ILookup<string, T> lookup, AccountInfo account) where T : IStatsResponse => For(lookup, account.Identifiers.Profile);

        public static IEnumerable<T> AllFor<T>(this ILookup<string, T> lookup, AccountInfo account) where T : IMultiElementStatsResponse => AllFor(lookup, account.Identifiers.Profile);

        public static bool TryRetrieveFor<T>(this ILookup<string, T> lookup, AccountInfo account, out T output) where T : IStatsResponse
        {
            output = For(lookup, account);
            return output != null;
        }

        public static bool TryRetrieveAllFor<T>(this ILookup<string, T> lookup, AccountInfo account, out IEnumerable<T> output) where T : IMultiElementStatsResponse
        {
            output = AllFor(lookup, account);
            return output != null;
        }

        #endregion
    }
}
