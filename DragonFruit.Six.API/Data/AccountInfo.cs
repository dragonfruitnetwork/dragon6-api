// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class AccountInfo
    {
        /// <summary>
        /// The Player's Username (Formatted)
        /// </summary>
        [JsonProperty("name")]
        public string PlayerName { get; set; }

        /// <summary>
        /// URL to Player's Avatar
        /// </summary>
        [JsonProperty("image")]
        public string Image => $"https://ubisoft-avatars.akamaized.net/{Guid}/default_256_256.png";

        /// <summary>
        /// User Platform
        /// </summary>
        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        /// <summary>
        /// User's Profile Id - the one used to get stats
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// Original platform identifier
        /// </summary>
        [JsonProperty("platformid")]
        public string PlatformId { get; set; }

        /// <summary>
        /// Ubisoft identifier
        /// </summary>
        [JsonProperty("userid")]
        public string UbisoftId { get; set; }
    }
}
