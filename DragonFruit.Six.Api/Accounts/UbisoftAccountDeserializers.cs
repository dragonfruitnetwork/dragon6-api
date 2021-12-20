// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Interfaces;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Accounts
{
    public static class UbisoftAccountDeserializers
    {
        public static IEnumerable<UbisoftAccount> DeserializeUbisoftAccounts(this JObject json)
        {
            return json.RemoveContainer().ToObject<IEnumerable<UbisoftAccount>>();
        }

        public static ILookup<string, UbisoftAccountActivity> DeserializeUbisoftAccountActivity(this JObject json)
        {
            var data = json.RemoveContainer().ToObject<IEnumerable<UbisoftAccountActivity>>() ?? Enumerable.Empty<UbisoftAccountActivity>();
            return data.ToLookup(x => x.ProfileId);
        }

        /// <summary>
        /// Removes the container the data is stored behind without knowing the key
        /// </summary>
        internal static JToken RemoveContainer(this JObject json) => json.Children().SingleOrDefault();

        // todo move to own class
        internal static ILookup<string, T> DeserializeTo<T>(this JObject json) where T : IAssociatedWithProfile, IHasSingleLevelContainer
        {
            // this removes the padding (.results) and converts each property into the requested type,
            // setting the ProfileId to the property name
            var data = json.Children<JObject>().SingleOrDefault()?.Properties().Select(x =>
            {
                var obj = x.Value.ToObject<T>();

                // in this case the property name is the profile we looked up
                obj.ProfileId = x.Name;

                return obj;
            });

            // this kinda builds an internal dictionary, so ToArray() is not needed
            return data.ToLookup(x => x.ProfileId);
        }
    }
}
