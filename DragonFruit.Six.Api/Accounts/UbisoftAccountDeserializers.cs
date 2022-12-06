// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using Newtonsoft.Json.Linq;

#pragma warning disable CS0618

namespace DragonFruit.Six.Api.Accounts
{
    public static class UbisoftAccountDeserializers
    {
        public static IEnumerable<UbisoftAccount> DeserializeUbisoftAccounts(this JObject json)
        {
            var data = json.RemoveContainer<JArray>();
            return data.ToObject<IEnumerable<UbisoftAccount>>();
        }

        public static IReadOnlyDictionary<string, UbisoftAccountActivity> DeserializeUbisoftAccountActivity(this JObject json)
        {
            var data = json.RemoveContainer<JArray>().ToObject<IEnumerable<UbisoftAccountActivity>>() ?? Enumerable.Empty<UbisoftAccountActivity>();
            return data.ToDictionary(x => x.ProfileId);
        }

        /// <summary>
        /// Removes the container the data is stored behind without knowing the key
        /// </summary>
        internal static T RemoveContainer<T>(this JObject json) where T : JToken => json.Children().SingleOrDefault().Value<JProperty>()?.Value as T;
    }
}
