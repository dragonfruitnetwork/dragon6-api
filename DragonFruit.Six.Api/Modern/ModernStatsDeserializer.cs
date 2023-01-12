// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern
{
    public static class ModernStatsDeserializer
    {
        /// <summary>
        /// Abstracts a ubisoft stats response to present the data required
        /// </summary>
        public static ModernModeStatsContainer<T> ProcessData<T>(this JObject source)
        {
            var container = (JProperty)source?["profileData"].First;
            var platformContainer = (JProperty)container?.Value["platforms"]!.First;

            return platformContainer?.Value.ToObject<ModernModeStatsContainer<T>>(new JsonSerializer
            {
                Converters = { new JsonPathConverter() }
            });
        }
    }
}
