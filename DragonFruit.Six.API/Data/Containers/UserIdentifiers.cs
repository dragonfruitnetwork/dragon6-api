// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class UserIdentifiers
    {
        public UserIdentifiers()
        {
        }

        public UserIdentifiers(string id)
        {
            Profile = id;
            Ubisoft = id;
            Platform = id;
        }

        /// <summary>
        /// Game-specific user identifier
        /// </summary>
        /// <remarks>
        /// This id can differ to <see cref="Ubisoft"/> because an account can have a copy of siege on both PC and PSN
        /// </remarks>
        [JsonProperty("profile")]
        public string Profile { get; set; }

        /// <summary>
        /// Ubisoft account identifier
        /// </summary>
        [JsonProperty("ubisoft")]
        public string Ubisoft { get; set; }

        /// <summary>
        /// Platform-specific identifier (i.e. PSN id)
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }
    }
}
