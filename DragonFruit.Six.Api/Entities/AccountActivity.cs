// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Interfaces;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Entities
{
    public class AccountActivity : IAssociatedWithAccount, IStatsResponse
    {
        [JsonProperty("profile")]
        internal string ProfileId { get; set; }

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

        public bool IsAssociatedWithAccount(AccountInfo account) => account.Identifiers.Profile.Equals(ProfileId);
    }
}
