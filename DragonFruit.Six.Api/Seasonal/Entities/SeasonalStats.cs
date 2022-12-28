// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Seasonal.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SeasonalStats
    {
        private RankInfo? _rankInfo, _maxRankInfo, _mmrRankInfo;

        [JsonProperty("season")]
        public int SeasonId { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("board_id")]
        public BoardType Board { get; set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("update_time")]
        public DateTime? TimeUpdated { get; set; }

        [JsonProperty("last_match_result")]
        public MatchResult LastMatchResult { get; set; }

        #region WL/KD

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("abandons")]
        public int Abandons { get; set; }

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        public float Kd => RatioUtils.RatioOf(Kills, Deaths);
        public float Wl => RatioUtils.RatioOf(Wins, Losses + Abandons);

        #endregion

        #region Rank

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("max_rank")]
        public int MaxRank { get; set; }

        [JsonProperty("top_rank_position")]
        public uint? TopRankPosition { get; set; }

        #endregion

        #region MMR & Skill

        [JsonProperty("mmr")]
        public double MMR { get; set; }

        [JsonProperty("max_mmr")]
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

        public RankInfo RankInfo => _rankInfo ??= Ranks.GetRank(Rank, SeasonId);
        public RankInfo MaxRankInfo => _maxRankInfo ??= Ranks.GetRank(MaxRank, SeasonId);
        public RankInfo MMRRankInfo => _mmrRankInfo ??= Ranks.GetRank((int)MMR, SeasonId, true);

        public override string ToString() => $"S{SeasonId}/{Board}: {ProfileId}";
    }
}
