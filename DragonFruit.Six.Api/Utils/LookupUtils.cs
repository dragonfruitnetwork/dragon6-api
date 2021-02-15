// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Linq;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Interfaces;

namespace DragonFruit.Six.Api.Utils
{
    public static class LookupUtils
    {
        public static T For<T>(this ILookup<string, T> lookup, string id) where T : IAssociatedWithAccount
        {
            return lookup[id].FirstOrDefault();
        }

        public static T For<T>(this ILookup<string, T> lookup, AccountInfo account) where T : IAssociatedWithAccount
        {
            return For(lookup, account.Identifiers.Profile);
        }

        public static bool TryRetrieve<T>(this ILookup<string, T> lookup, string id, out T output) where T : IAssociatedWithAccount
        {
            output = For(lookup, id);
            return output != null;
        }

        public static bool TryRetrieve<T>(this ILookup<string, T> lookup, AccountInfo account, out T output) where T : IAssociatedWithAccount
        {
            output = For(lookup, account);
            return output != null;
        }
    }
}
