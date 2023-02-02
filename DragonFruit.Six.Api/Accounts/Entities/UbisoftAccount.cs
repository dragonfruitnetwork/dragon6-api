// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Accounts.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Accounts.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class UbisoftAccount : IEquatable<UbisoftAccount>
    {
        [JsonProperty("nameOnPlatform")]
        public string Username { get; set; }

        [JsonProperty("platformType")]
        public string PlatformName { get; set; }

        /// <summary>
        /// 256x256px avatar image url
        /// </summary>
        public string Image => $"https://ubisoft-avatars.akamaized.net/{UbisoftId}/default_256_256.png";

        /// <summary>
        /// Platform this user profile targets. If the platform is not available, <see cref="Platform.CrossPlatform"/> will be returned
        /// </summary>
        public Platform Platform => PlatformName switch
        {
            UbisoftPlatforms.PC => Platform.PC,
            UbisoftPlatforms.XBOX => Platform.XB1,
            UbisoftPlatforms.PLAYSTATION => Platform.PSN,

            _ => Platform.CrossPlatform
        };

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
