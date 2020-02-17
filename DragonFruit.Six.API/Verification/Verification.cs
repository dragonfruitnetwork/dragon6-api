// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Verification
{
    public class Verification
    {
        [JsonProperty("Level")]
        public Level AccountLevel { get; set; }

        [JsonProperty("Guid")]
        public string GUID { get; set; }

        [JsonProperty("YTLink")]
        public string YouTube { get; set; }

        [JsonProperty("TwitchLink")]
        public string Twitch { get; set; }

        [JsonProperty("ImageHeaderLink")]
        public string Image { get; set; }

        [JsonProperty("CustomText")]
        public string CustomLevelText { get; set; }

        [JsonProperty("CustomIcon")]
        public string CustomLevelIcon { get; set; }

        [JsonProperty("CustomColour")]
        public string CustomLevelColour { get; set; }

        //dragon6 server specifics below
        public string UID { get; set; }

        public Dictionary<string, object> ToDictionary() =>
            new Dictionary<string, object>
            {
                { "Level", AccountLevel },
                { "Twitch", Twitch },
                { "YouTube", YouTube },
                { "uid", UID },
                { "img", Image },
                { "role", CustomLevelText },
                { "icon", CustomLevelIcon },
                { "colour", CustomLevelColour }
            };
    }
}
