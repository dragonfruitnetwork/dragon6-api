// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class SeasonStatsDeserializer
    {
        public static SeasonStats DeserializeSeasonStatsFor(this JObject jObject, string guid)
        {
            var json = jObject[Misc.Players]?[guid] as JObject;

            if (json == null)
                return null;

            return new SeasonStats
            {
                Guid = guid,
                TimeUpdated = DateTime.Parse(json.GetString(Seasonal.TimeUpdated, DateTime.Now.ToString(Dragon6Client.Culture)), Dragon6Client.Culture),
                SeasonId = json.GetByte(Seasonal.Season),

                Kills = json.GetUInt(Seasonal.Kills),
                Deaths = json.GetUInt(Seasonal.Deaths),

                Wins = json.GetUInt(Seasonal.Wins),
                Losses = json.GetUInt(Seasonal.Losses),
                Abandons = json.GetUInt(Seasonal.Abandons),

                Rank = json.GetInt(Seasonal.Rank),
                MaxRank = json.GetInt(Seasonal.MaxRank),
                TopRankPosition = json.GetUInt(Seasonal.TopRankPosition),

                MMR = json.GetDouble(Seasonal.MMR),
                MaxMMR = json.GetDouble(Seasonal.MaxMMR),
                NextRankMMR = json.GetDouble(Seasonal.NextRankMMR),
                PreviousRankMMR = json.GetDouble(Seasonal.PreviousRankMMR),

                SkillMean = json.GetDouble(Seasonal.SkillMean),
                SkillUncertainty = json.GetDouble(Seasonal.SkillUncertainty),

                LastMatchResult = (MatchResult)json.GetUInt(Seasonal.LastMatchResult),
                LastMatchMMRChange = json.GetDouble(Seasonal.LastMatchMMRChange),
                LastMatchSkillChange = json.GetDouble(Seasonal.LastMatchSkillChange),
                LastMatchSkillUncertaintyChange = json.GetDouble(Seasonal.LastMatchSkillUncertaintyChange),
            };
        }
    }
}
