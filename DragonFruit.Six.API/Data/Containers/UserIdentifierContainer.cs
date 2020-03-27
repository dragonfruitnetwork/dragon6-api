// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class UserIdentifierContainer
    {
        public UserIdentifierContainer()
        {
        }

        public UserIdentifierContainer(string id)
        {
            Profile = id;
            Ubisoft = id;
            Platform = id;
        }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("ubisoft")]
        public string Ubisoft { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }
    }
}
