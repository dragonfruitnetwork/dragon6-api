// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Modern.Containers;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Utils
{
    internal static class JsonUtils
    {
        /// <summary>
        /// Abstracts a ubisoft stats response to present the data required
        /// </summary>
        public static ModernModeStatsContainer<T> ProcessData<T>(this JObject source, ModernStatsRequest request, ModernDragon6Client client)
        {
            var data = source?["platforms"]?[request.Account.Platform.ModernName()];
            return data?.ToObject<ModernModeStatsContainer<T>>();
        }
    }
}
