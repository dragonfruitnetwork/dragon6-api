// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using DragonFruit.Six.Api.Accounts.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SeasonalStatsResponse
    {
        [JsonProperty("players")]
        private Dictionary<string, SeasonalStats> Data { get; set; }

        public IReadOnlyDictionary<string, SeasonalStats> Stats => Data;
        public SeasonalStats For(UbisoftAccount account) => For(account.ProfileId);
        public SeasonalStats For(string profileId) => Data.TryGetValue(profileId, out var data) ? data : null;
    }
}
