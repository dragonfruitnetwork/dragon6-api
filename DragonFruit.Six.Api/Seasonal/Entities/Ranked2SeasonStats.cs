// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class Ranked2SeasonStats
    {
        [JsonProperty("board_id")]
        public BoardType Board { get; set; }

        [JsonProperty("id")]
        public string ProfileId { get; set; }

        [JsonProperty("season_id")]
        public int SeasonId { get; set; }

        [JsonProperty("platform_family")]
        public PlatformGroup Platform { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("rank_points")]
        public int RankPoints { get; set; }

        [JsonProperty("top_rank_position")]
        public int TopRankPosition { get; set; }

        [JsonProperty("max_rank")]
        public int MaxRank { get; set; }

        [JsonProperty("max_rank_points")]
        public int MaxRankPoints { get; set; }

        public RankInfo RankInfo => Ranks.GetFromId(Rank);

        public RankInfo MaxRankInfo => Ranks.GetFromId(MaxRank);

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("match_outcomes")]
        public Ranked2SeasonMatchStats Matches { get; set; }

        public float KD => RatioUtils.RatioOf(Kills, Deaths);
    }
}
