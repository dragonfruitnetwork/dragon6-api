using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon6.API.Verification
{
    public class Verification
    {
        [JsonProperty("Level")]
        public Level AccountLevel { get; set; }

        public string GUID { get; set; }

        [JsonProperty("YTLink")]
        public string YouTube { get; set; }

        [JsonProperty("TwitchLink")]
        public string Twitch { get; set; }

        [JsonProperty("ImageHeaderLink")]
        public string Image { get; set; }

        //dragon6 server specifics below
        public References.Platforms Platform { get; set; }
        public string UserName { get; set; }
        public string UID { get; set; }
        public List<string> OwnedSquads { get; set; }

        public Dictionary<string, object> ToDictionary() => new Dictionary<string, object>
        {
            {"Level", AccountLevel },
            {"Twitch", Twitch },
            {"YouTube", YouTube },
            {"uid", UID },
            {"username", UserName },
            {"squads", OwnedSquads },
            {"platform", Platform },
            {"img", Image }
        };

    }
}
