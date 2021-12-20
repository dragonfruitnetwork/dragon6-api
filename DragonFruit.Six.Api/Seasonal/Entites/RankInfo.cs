// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entites
{
    public struct RankInfo : IEquatable<RankInfo>, IEquatable<int>
    {
        internal RankInfo(byte id, string name, string iconUrl, int? minMMR, int? maxMMR)
        {
            Id = id;
            Name = name;
            IconUrl = iconUrl;

            MinMMR = minMMR;
            MaxMMR = maxMMR;
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

        /// <summary>
        /// The lower MMR boundary for this rank
        /// </summary>
        [JsonProperty("mmr_min")]
        public int? MinMMR { get; set; }

        /// <summary>
        /// The upper MMR boudary for this rank
        /// </summary>
        [JsonProperty("mmr_max")]
        public int? MaxMMR { get; set; }

        public bool Equals(int other) => Id == other;
        public bool Equals(RankInfo other) => Equals(other.Id);
    }
}
