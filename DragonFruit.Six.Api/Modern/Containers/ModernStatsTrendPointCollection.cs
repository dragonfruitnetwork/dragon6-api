// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Containers
{
    /// <summary>
    /// Represents a time-series collection of values
    /// </summary>
    public class ModernStatsTrendPointCollection
    {
        [JsonProperty("actuals")]
        public float[] Values { get; set; }

        [JsonProperty("trend")]
        public float[] Trend { get; set; }

        [JsonProperty("average")]
        public float Average { get; set; }

        [JsonProperty("high")]
        public float Max { get; set; }

        [JsonProperty("low")]
        public float Min { get; set; }
    }
}
