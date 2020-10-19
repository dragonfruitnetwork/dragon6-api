// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Data.Strings
{
    public static class Seasonal
    {
        public static string Season => "season";
        public static string TimeUpdated => "update_time";

        public static string Kills => "kills";
        public static string Deaths => "deaths";

        public static string Wins => "wins";
        public static string Losses => "losses";
        public static string Abandons => "abandons";

        public static string Rank => "rank";
        public static string MaxRank => "max_rank";
        public static string TopRankPosition => "top_rank_position";

        public static string MMR => "mmr";
        public static string MaxMMR => "max_mmr";
        public static string NextRankMMR => "next_rank_mmr";
        public static string PreviousRankMMR => "previous_rank_mmr";

        public static string SkillMean => "skill_mean";
        public static string SkillUncertainty => "skill_stdev";

        public static string LastMatchResult => "last_match_result";
        public static string LastMatchMMRChange => "last_match_mmr_change";
        public static string LastMatchSkillChange => "last_match_skill_mean_change";
        public static string LastMatchSkillUncertaintyChange => "last_match_skill_stdev_change";
    }
}
