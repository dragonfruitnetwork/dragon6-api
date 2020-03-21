// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Containers;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class GeneralStats
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("overall")]
        public ModeStatsContainer Overall { get; set; }

        [JsonProperty("casual")]
        public ModeStatsContainer Casual { get; set; }

        [JsonProperty("ranked")]
        public ModeStatsContainer Ranked { get; set; }

        [JsonProperty("training")]
        public ModeStatsContainer Training { get; set; }

        [JsonProperty("highscores")]
        public HighScoreContainer Highscores { get; set; }

        [JsonProperty("barricades")]
        public uint Barricades { get; set; }

        [JsonProperty("reinforcements")]
        public uint Reinforcements { get; set; }

        [JsonProperty("downs")]
        public uint Downs { get; set; }

        [JsonProperty("revives")]
        public uint Revives { get; set; }

        [JsonProperty("suicides")]
        public uint Suicides { get; set; }

        [JsonProperty("headshots")]
        public uint Headshots { get; set; }

        [JsonProperty("penetrations")]
        public uint Penetrations { get; set; }

        [JsonProperty("melee")]
        public uint Knifes { get; set; }

        [JsonProperty("assists")]
        public uint Assists { get; set; }

        [JsonProperty("shots_fired")]
        public long ShotsFired { get; set; }

        [JsonProperty("shots_connected")]
        public long ShotsConnected { get; set; }
    }
}
