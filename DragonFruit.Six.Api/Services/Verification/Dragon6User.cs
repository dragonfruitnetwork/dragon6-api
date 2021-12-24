// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Services.Verification
{
    /// <summary>
    /// Publicly-exposed data about a user's verified account (on the dragon6 site)
    /// </summary>
    public class Dragon6User
    {
        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("role")]
        public AccountRole AccountRole { get; set; }

        [JsonProperty("cover_img")]
        public string Image { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_icon")]
        public string TitleIcon { get; set; }

        [JsonProperty("title_colour")]
        public string TitleColour { get; set; }
    }
}
