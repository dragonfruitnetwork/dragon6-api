// Dragon6 API Copyright 2019 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dragon6.API.Verification
{
    public class Verification
    {
        [JsonProperty("Level")] public Level AccountLevel { get; set; }

        public string GUID { get; set; }

        [JsonProperty("YTLink")] public string YouTube { get; set; }

        [JsonProperty("TwitchLink")] public string Twitch { get; set; }

        [JsonProperty("ImageHeaderLink")] public string Image { get; set; }

        //dragon6 server specifics below
        public string UID { get; set; }

        public Dictionary<string, object> ToDictionary() =>
            new Dictionary<string, object>
            {
                {"Level", AccountLevel},
                {"Twitch", Twitch},
                {"YouTube", YouTube},
                {"uid", UID},
                {"img", Image}
            };
    }
}