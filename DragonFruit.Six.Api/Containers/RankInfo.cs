// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Containers
{
    public class RankInfo
    {
        internal RankInfo(byte id, string name, string iconUrl)
        {
            Id = id;
            Name = name;
            IconUrl = iconUrl;
        }

        /// <summary>
        /// The Id of the rank (0-23)
        /// </summary>
        [JsonProperty("id")]
        public byte Id { get; set; }

        /// <summary>
        /// Name of the rank (Copper 5-Champion)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Url stub to SVG icon (/rank/v2/0.svg)
        /// </summary>
        [JsonProperty("icon")]
        public string IconUrl { get; set; }
    }
}
