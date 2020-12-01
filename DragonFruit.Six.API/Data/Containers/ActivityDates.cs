// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class ActivityDates
    {
        [JsonProperty("first")]
        public DateTimeOffset First { get; set; }

        [JsonProperty("last")]
        public DateTimeOffset Last { get; set; }
    }
}
