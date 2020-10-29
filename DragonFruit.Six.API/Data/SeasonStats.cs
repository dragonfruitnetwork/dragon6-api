// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data
{
    public class SeasonStats : StatsBase
    {
        private RankInfo _rankInfo;
        private RankInfo _maxRankInfo;

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("id")]
        public byte SeasonId { get; set; }

        [JsonProperty("update_time")]
        public DateTime? TimeUpdated { get; set; }

        [JsonProperty("last_match_result")]
        public MatchResult LastMatchResult { get; set; }

        [JsonProperty("abandons")]
        public uint Abandons { get; set; }

        #region Rank

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("maxrank")]
        public int MaxRank { get; set; }

        [JsonProperty("top_rank_position")]
        public uint? TopRankPosition { get; set; }

        #endregion

        #region MMR & Skill

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

        [JsonProperty("last_match_mmr_change")]
        public double LastMatchMMRChange { get; set; }

        [JsonProperty("last_match_skill_mean_change")]
        public double LastMatchSkillChange { get; set; }

        [JsonProperty("last_match_skill_stdev_change")]
        public double LastMatchSkillUncertaintyChange { get; set; }

        #endregion

        [JsonIgnore]
        public RankInfo RankInfo => _rankInfo ??= Rank > 14 ? SeasonalRanks.Rank(Rank) : SeasonalRanks.Legacy(Rank);

        [JsonIgnore]
        public RankInfo MaxRankInfo => _maxRankInfo ??= Rank > 14 ? SeasonalRanks.Rank(MaxRank) : SeasonalRanks.Legacy(MaxRank);
    }
}
