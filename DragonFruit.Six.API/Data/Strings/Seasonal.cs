// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data.Strings
{
    public static class Seasonal
    {
        public static readonly string Season = "season";
        public static readonly string TimeUpdated = "update_time";

        public static readonly string Kills = "kills";
        public static readonly string Deaths = "deaths";

        public static readonly string Wins = "wins";
        public static readonly string Losses = "losses";
        public static readonly string Abandons = "abandons";

        public static readonly string Rank = "rank";
        public static readonly string MaxRank = "max_rank";
        public static readonly string TopRankPosition = "top_rank_position";

        public static readonly string MMR = "mmr";
        public static readonly string MaxMMR = "max_mmr";
        public static readonly string NextRankMMR = "next_rank_mmr";
        public static readonly string PreviousRankMMR = "previous_rank_mmr";

        public static readonly string SkillMean = "skill_mean";
        public static readonly string SkillUncertainty = "skill_stdev";

        public static readonly string LastMatchResult = "last_match_result";
        public static readonly string LastMatchMMRChange = "last_match_mmr_change";
        public static readonly string LastMatchSkillChange = "last_match_skill_mean_change";
        public static readonly string LastMatchSkillUncertaintyChange = "last_match_skill_stdev_change";
    }

}
