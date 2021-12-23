﻿// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

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

        public SeasonalStats this[UbisoftAccount account] => this[account.ProfileId];
        public SeasonalStats this[string profileId] => Data.TryGetValue(profileId, out var data) ? data : null;
    }
}
