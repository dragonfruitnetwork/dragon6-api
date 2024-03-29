﻿// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    /// <summary>
    /// Represents a DragonFruit-maintained operator info database entry targeting the legacy stats api
    /// </summary>
    /// <remarks>
    /// As of Y6S4, the database is no longer maintained. It is recommended to begin migration to modern stats and consume <see cref="ModernOperatorInfo"/> instead
    /// </remarks>
    [Serializable]
    public class LegacyOperatorInfo
    {
        /// <summary>
        /// Operator name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Operator Identifier
        /// </summary>
        [JsonProperty("index")]
        public string OperatorId { get; set; }

        /// <summary>
        /// Logical order
        /// </summary>
        [JsonProperty("ord")]
        public ushort Order { get; set; }

        /// <summary>
        /// Operator Icon
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
