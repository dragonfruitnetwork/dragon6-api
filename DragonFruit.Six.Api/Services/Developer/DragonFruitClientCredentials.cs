// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Services.Developer
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class DragonFruitClientCredentials
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("expires_at")]
        public DateTime? ExpiresUtc { get; set; }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            ExpiresUtc ??= DateTime.UtcNow.AddSeconds(ExpiresIn);
        }
    }
}
