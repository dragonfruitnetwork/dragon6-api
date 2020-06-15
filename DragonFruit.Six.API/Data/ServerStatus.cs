// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class ServerStatus
    {
        [JsonProperty("AppID ")] //dunno why ubi left a space...
        public string AppId { get; set; }

        [JsonProperty("SpaceID")]
        public string SpaceId { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Platform")]
        public string Platform { get; set; }

        [JsonProperty("Status")]
        internal string Status { get; set; }

        [JsonProperty("Maintenance")]
        internal bool? Maintenance { get; set; }

        [JsonIgnore]
        public ServerCondition Condition { get; set; }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            Condition = Maintenance == true
                ? ServerCondition.Maintenance
                : (ServerCondition)Enum.Parse(typeof(ServerCondition), Status, true);
        }
    }
}
