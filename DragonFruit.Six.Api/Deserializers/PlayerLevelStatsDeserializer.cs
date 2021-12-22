// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class PlayerLevelStatsDeserializer
    {
        public static IReadOnlyDictionary<string, PlayerLevelStats> DeserializePlayerLevelStats(this JObject json)
        {
            var data = json["player_profiles"] is JArray profiles
                ? profiles.Select(x => x.ToObject<PlayerLevelStats>())
                : Enumerable.Empty<PlayerLevelStats>();

            // extra where check there because rider was saying something about a NRE
            return data.Where(x => x != null).ToDictionary(x => x.ProfileId);
        }
    }
}
