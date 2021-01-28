// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class PlayerLevelStatsDeserializer
    {
        public static IEnumerable<PlayerLevelStats> DeserializePlayerLevelStats(this JObject jObject)
        {
            var profiles = jObject["player_profiles"];

            if (profiles == null)
                yield break;

            foreach (var profile in JArray.FromObject(profiles))
            {
                var result = profile.ToObject<PlayerLevelStats>();

                // todo do we need a null check?
                result!.Guid = (string)profile["profile_id"];
                yield return result;
            }
        }
    }
}
