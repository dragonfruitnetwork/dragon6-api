// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Services.Verification
{
    /// <summary>
    /// Publicly-exposed data about a user's verified account (on the dragon6 site)
    /// </summary>
    public class Dragon6AccountInfo
    {
        [JsonProperty("Level")]
        public AccountRole AccountRole { get; set; }

        [JsonProperty("Guid")]
        public string ProfileId { get; set; }

        [JsonProperty("youtube")]
        public string YouTube { get; set; }

        [JsonProperty("twitch")]
        public string Twitch { get; set; }

        [JsonProperty("ImageHeaderLink")]
        public string Image { get; set; }

        [JsonProperty("CustomText")]
        public string CustomTitle { get; set; }

        [JsonProperty("CustomIcon")]
        public string CustomIcon { get; set; }

        [JsonProperty("CustomColour")]
        public string CustomColour { get; set; }
    }
}
