// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        [Column("id")]
        [JsonProperty("id")]
        public string OperatorId { get; set; }

        /// <summary>
        /// Operator name
        /// </summary>
        [Column("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Numeric value representing the relative release order of the operator
        /// </summary>
        [Column("ord")]
        [JsonProperty("ord")]
        public ushort Order { get; set; }

        /// <summary>
        /// Fully qualified operator icon url
        /// </summary>
        [Column("img")]
        [JsonProperty("img")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        [Column("org")]
        [JsonProperty("org")]
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game
        /// </summary>
        [Column("sub")]
        [JsonProperty("sub")]
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender
        /// </summary>
        [Column("type")]
        [JsonProperty("type")]
        public OperatorType Type { get; set; }
    }
}
