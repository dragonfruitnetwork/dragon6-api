﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Data.Containers;
using DragonFruit.Six.Api.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Data
{
    public class AccountActivity
    {
        /// <summary>
        /// User profile id
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        /// <summary>
        /// Number of times the game has been opened
        /// </summary>
        [JsonProperty("sessions")]
        public uint SessionCount { get; set; }

        /// <summary>
        /// Dates of the first and last time logged in
        /// </summary>
        [JsonProperty("activity")]
        public ActivityDates Activity { get; set; }
    }
}
