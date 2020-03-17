// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class RankedSeasonStatsDeserializer
    {
        public static RankedSeasonStats DeserializeRankedSeasonStatsFor(this JObject jObject, string guid)
        {
            var json = (JObject)jObject[Misc.Players][guid];

            return new RankedSeasonStats
            {
                Guid = guid,
                TimeUpdated = DateTime.Parse(json.GetString(SeasonalRanked.TimeUpdated, DateTime.Now.ToString(References.Culture)), References.Culture),
                SeasonId = json.GetByte(SeasonalRanked.Season),

                Kills = json.GetUInt(SeasonalRanked.Kills),
                Deaths = json.GetUInt(SeasonalRanked.Deaths),
                KD = json.GetFloat(SeasonalRanked.Kills, 1) / json.GetFloat(SeasonalRanked.Deaths, 1),

                Wins = json.GetUInt(SeasonalRanked.Wins),
                Losses = json.GetUInt(SeasonalRanked.Losses),
                Abandons = json.GetUInt(SeasonalRanked.Abandons),
                WL = json.GetFloat(SeasonalRanked.Wins, 1) / json.GetFloat(SeasonalRanked.Losses, 1),

                Rank = json.GetUInt(SeasonalRanked.Rank),
                MaxRank = json.GetUInt(SeasonalRanked.MaxRank),
                TopRankPosition = json.GetUInt(SeasonalRanked.TopRankPosition),

                MMR = json.GetDouble(SeasonalRanked.MMR),
                MaxMMR = json.GetDouble(SeasonalRanked.MaxMMR),
                NextRankMMR = json.GetDouble(SeasonalRanked.NextRankMMR),
                PreviousRankMMR = json.GetDouble(SeasonalRanked.PreviousRankMMR),

                SkillMean = json.GetDouble(SeasonalRanked.SkillMean),
                SkillUncertainty = json.GetDouble(SeasonalRanked.SkillUncertainty),

                LastMatchResult = (MatchResult)json.GetUInt(SeasonalRanked.LastMatchResult),
                LastMatchMMRChange = json.GetDouble(SeasonalRanked.LastMatchMMRChange),
                LastMatchSkillChange = json.GetDouble(SeasonalRanked.LastMatchSkillChange),
                LastMatchSkillUncertaintyChange = json.GetDouble(SeasonalRanked.LastMatchSkillUncertaintyChange),
            };
        }
    }
}
