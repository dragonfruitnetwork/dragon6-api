// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Seasonal.Entites;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Seasonal
{
    public static class SeasonalStatsDeserializer
    {
        public static IReadOnlyDictionary<string, SeasonalStats> DeserializeSeasonalStats(this JObject json)
        {
            return json.DeserializeDictionariedStats<SeasonalStats>();
        }
    }
}
