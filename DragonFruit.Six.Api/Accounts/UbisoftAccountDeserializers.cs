// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Accounts
{
    public static class UbisoftAccountDeserializers
    {
        public static IEnumerable<UbisoftAccount> DeserializeUbisoftAccounts(this JObject json)
        {
            return json.RemoveContainer().ToObject<IEnumerable<UbisoftAccount>>();
        }

        public static IReadOnlyDictionary<string, UbisoftAccountActivity> DeserializeUbisoftAccountActivity(this JObject json)
        {
            var data = json.RemoveContainer().ToObject<IEnumerable<UbisoftAccountActivity>>() ?? Enumerable.Empty<UbisoftAccountActivity>();
            return data.ToDictionary(x => x.ProfileId);
        }

        /// <summary>
        /// Removes the container the data is stored behind without knowing the key
        /// </summary>
        internal static JObject RemoveContainer(this JObject json) => json.Children<JObject>().SingleOrDefault();
    }
}
