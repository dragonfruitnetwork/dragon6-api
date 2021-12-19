// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Accounts.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UbisoftAccount : IEquatable<UbisoftAccount>
    {
        [JsonProperty("nameOnPlatform")]
        public string Username { get; set; }

        /// <summary>
        /// Platform this user was looked up on
        /// </summary>
        [JsonProperty("platformType")]
        public Platform Platform { get; set; }

        /// <summary>
        /// 256x256px avatar image url
        /// </summary>
        public string Image => $"https://ubisoft-avatars.akamaized.net/{UbisoftId}/default_256_256.png";

        /// <summary>
        /// Unique identifier for the platform-specific account used to get stats.
        /// This may not match the <see cref="UbisoftId"/> if the user's first platform is not <see cref="Platform.PC"/>
        /// </summary>
        [JsonProperty("profileId")]
        public string ProfileId { get; set; }

        /// <summary>
        /// Ubisoft account id that is non-specific to a platform.
        /// (one account can have multiple profiles across different platforms)
        /// </summary>
        [JsonProperty("userId")]
        public string UbisoftId { get; set; }

        /// <summary>
        /// The platform-specific identifier
        /// </summary>
        [JsonProperty("idOnPlatform")]
        public string PlatformId { get; set; }

        public bool Equals(UbisoftAccount other) => ProfileId == other?.ProfileId;

        public override string ToString() => $"{Username} ({UbisoftId} - {Platform})";
    }
}
