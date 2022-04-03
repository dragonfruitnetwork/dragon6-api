// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Modern.Entities
{
    /// <summary>
    /// Represents a DragonFruit-maintained operator info database entry, compatible with the modern stats api
    /// </summary>
    [Serializable]
    public class ModernOperatorInfo
    {
        /// <summary>
        /// Operator Identifier
        /// </summary>
        [JsonProperty("id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// Operator name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Numeric value representing the relative release order of the operator
        /// </summary>
        [JsonProperty("ord")]
        public ushort Order { get; set; }

        /// <summary>
        /// Fully qualified operator icon url
        /// </summary>
        [JsonProperty("img")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        [JsonProperty("org")]
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game
        /// </summary>
        [JsonProperty("sub")]
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender
        /// </summary>
        [JsonProperty("type")]
        public OperatorType Type { get; set; }
    }
}
