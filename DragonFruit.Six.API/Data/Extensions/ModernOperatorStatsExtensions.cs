// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class ModernOperatorStatsExtensions
    {
        public static IReadOnlyDictionary<PlaylistType, ModernOperatorStatsContainer> GetModernOperatorStatsFor<T>(this T client, AccountInfo account) where T : Dragon6Client
        {
            var request = new ModernOperatorStatsRequest(account);
            return client.Perform<JObject>(request).DeserializeModernOperatorStatsFor(account);
        }
    }
}
