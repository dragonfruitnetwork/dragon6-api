// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class RankedSeasonStats
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("update_time")]
        public DateTime TimeUpdated { get; set; }

        [JsonProperty("id")]
        public byte SeasonId { get; set; }

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("kd")]
        public float KD { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("wl")]
        public float WL { get; set; }

        [JsonProperty("abandons")]
        public uint Abandons { get; set; }

        [JsonProperty("maxrank")]
        public uint MaxRank { get; set; }

        [JsonProperty("rank")]
        public uint Rank { get; set; }

        [JsonProperty("top_rank_position")]
        public uint TopRankPosition { get; set; }

        [JsonProperty("mmr")]
        public double MMR { get; set; }

        [JsonProperty("maxmmr")]
        public double MaxMMR { get; set; }

        [JsonProperty("next_rank_mmr")]
        public double NextRankMMR { get; set; }

        [JsonProperty("previous_rank_mmr")]
        public double PreviousRankMMR { get; set; }

        [JsonProperty("skill_mean")]
        public double SkillMean { get; set; }

        [JsonProperty("skill_stdev")]
        public double SkillUncertainty { get; set; }

        [JsonProperty("last_match_result")]
        public MatchResult LastMatchResult { get; set; }

        [JsonProperty("last_match_mmr_change")]
        public double LastMatchMMRChange { get; set; }

        [JsonProperty("last_match_skill_mean_change")]
        public double LastMatchSkillChange { get; set; }

        [JsonProperty("last_match_skill_stdev_change")]
        public double LastMatchSkillUncertaintyChange { get; set; }
    }
}
