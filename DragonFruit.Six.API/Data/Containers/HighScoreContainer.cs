// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class HighScoreContainer
    {
        [JsonProperty("hostage")]
        public int Hostage { get; set; }

        [JsonProperty("bomb")]
        public int Bomb { get; set; }

        [JsonProperty("secure")]
        public int Secure { get; set; }
    }
}
