// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class PlayerLevelStatsDeserializer
    {
        public static IEnumerable<PlayerLevelStats> DeserializePlayerLevelStats(this JObject jObject)
        {
            foreach (var element in JArray.FromObject(jObject["player_profiles"]))
            {
                var result = element.ToObject<PlayerLevelStats>();
                result.Guid = (string)element["profile_id"];
                yield return result;
            }
        }
    }
}
