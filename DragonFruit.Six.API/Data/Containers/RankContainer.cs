// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class RankContainer
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        public RankContainer(uint id, string name, string iconUrl)
        {
            Id = id;
            Name = name;
            IconUrl = iconUrl;
        }
    }
}
