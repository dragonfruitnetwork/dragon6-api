// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    /// <summary>
    /// Represents a DragonFruit-maintained operator info database entry
    /// </summary>
    /// <remarks>
    /// As of Y6S4, the database is no longer maintained due to Ubisoft no longer updating legacy operator stats
    /// </remarks>
    [Serializable]
    public class LegacyOperatorInfo
    {
        [JsonProperty("profile")]
        internal string ProfileId { get; set; }

        /// <summary>
        /// Operator name (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Operator Identifier (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("index")]
        public string Index { get; set; }

        /// <summary>
        /// Logical order (from datasheet/dictionary)
        /// </summary>
        [JsonProperty("ord")]
        public ushort Order { get; set; }

        /// <summary>
        /// Operator Icon (from datasheet)
        /// </summary>
        [JsonProperty("img")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// The name of the organisation the operator is from
        /// </summary>
        [JsonProperty("org")]
        public string Organisation { get; set; }

        /// <summary>
        /// The subtitle, as seen underneath the operator's name in game (from datasheet)
        /// </summary>
        [JsonProperty("sub")]
        public string Subtitle { get; set; }

        /// <summary>
        /// The operator's use, attacker/defender (from datasheet)
        /// </summary>
        [JsonProperty("type")]
        public OperatorType Type { get; set; }
    }
}
