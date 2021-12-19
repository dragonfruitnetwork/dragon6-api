// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Interfaces;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class SeasonStats : StatsBase, IAssociatedWithAccount, IStandaloneUbisoftEntity
    {
        private RankInfo? _rankInfo, _maxRankInfo, _mmrRankInfo;

        [JsonProperty("profile")]
        internal string ProfileId { get; set; }

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

        public RankInfo RankInfo => _rankInfo ??= SeasonalRanks.GetRank(Rank, SeasonId);
        public RankInfo MaxRankInfo => _maxRankInfo ??= SeasonalRanks.GetRank(MaxRank, SeasonId);
        public RankInfo MMRRankInfo => _mmrRankInfo ??= SeasonalRanks.GetRank((int)MMR, SeasonId, true);

        public bool IsAssociatedWithAccount(UbisoftAccount account) => account.Identifiers.Profile.Equals(ProfileId);
    }
}
