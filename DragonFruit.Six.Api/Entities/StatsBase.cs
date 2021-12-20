// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class StatsBase : IHasKd, IHasWl
    {
        private float? _kd, _wl;

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);
    }
}
