// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Accounts.Entities
{
    [Serializable]
    public class UbisoftAccountActivity : IEquatable<UbisoftAccount>
    {
        [JsonProperty("profileId")]
        internal string ProfileId { get; set; }

        /// <summary>
        /// Number of times the game has been opened
        /// </summary>
        [JsonProperty("sessionsCount")]
        public uint SessionCount { get; set; }

        /// <summary>
        /// The <see cref="DateTime"/> of the user's first session (in UTC)
        /// </summary>
        [JsonProperty("firstSessionDate")]
        public DateTime FirstSession { get; set; }

        /// <summary>
        /// The <see cref="DateTime"/> the user last logged in (in UTC)
        /// </summary>
        [JsonProperty("lastSessionDate")]
        public DateTime LastSession { get; set; }

        public bool Equals(UbisoftAccount other) => string.Equals(ProfileId, other?.ProfileId, StringComparison.OrdinalIgnoreCase);
    }
}
