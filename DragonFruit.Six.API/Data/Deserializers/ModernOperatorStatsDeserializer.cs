// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class ModernOperatorStatsDeserializer
    {
        public static IReadOnlyDictionary<PlaylistType, ModernOperatorStatsContainer> DeserializeModernOperatorStatsFor(this JObject jObject, AccountInfo account)
        {
            // todo this will not work for psn/xb1 (the platform bit)
            var data = jObject["platforms"]?[account.Platform.ToString()]?["gameModes"];

            if (data == null)
            {
                return null;
            }

            var results = new Dictionary<PlaylistType, ModernOperatorStatsContainer>(4);

            foreach (var mode in Enum.GetValues(typeof(PlaylistType)).Cast<PlaylistType>())
            {
                if (data[mode.ToString().ToLower()] is JObject playlistData)
                {
                    results.Add(mode, GetModeContainerFor(playlistData));
                }
            }

            return results;
        }

        private static ModernOperatorStatsContainer GetModeContainerFor(JObject host)
        {
            if (!(host["teamRoles"] is JToken data))
            {
                return null;
            }

            var container = new ModernOperatorStatsContainer();

            if (data["attacker"] is JArray attackerInfo)
            {
                container.Attackers = attackerInfo.Select(x => x.ToObject<ModernOperatorStats>());
            }

            if (data["defender"] is JArray defenderInfo)
            {
                container.Defenders = defenderInfo.Select(x => x.ToObject<ModernOperatorStats>());
            }

            return container;
        }
    }
}
