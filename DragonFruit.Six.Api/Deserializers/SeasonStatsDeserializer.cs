// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class SeasonStatsDeserializer
    {
        public static ILookup<string, SeasonStats> DeserializeSeasonStats(this JObject json)
        {
            var results = (json[Misc.Players] as JObject)?.Properties().Select(DeserializeInternal);
            results ??= Enumerable.Empty<SeasonStats>();

            return results.ToLookup(x => x.ProfileId);
        }

        private static SeasonStats DeserializeInternal(JProperty data)
        {
            var property = (JObject)data.Value;

            return new SeasonStats
            {
                ProfileId = data.Name,

                TimeUpdated = DateTime.Parse(property.GetString(Seasonal.TimeUpdated, DateTime.Now.ToString(Dragon6Client.Culture)), Dragon6Client.Culture),
                SeasonId = property.GetByte(Seasonal.Season),

                Kills = property.GetUInt(Seasonal.Kills),
                Deaths = property.GetUInt(Seasonal.Deaths),

                Wins = property.GetUInt(Seasonal.Wins),
                Losses = property.GetUInt(Seasonal.Losses),
                Abandons = property.GetUInt(Seasonal.Abandons),

                Rank = property.GetInt(Seasonal.Rank),
                MaxRank = property.GetInt(Seasonal.MaxRank),
                TopRankPosition = property.GetUInt(Seasonal.TopRankPosition),

                MMR = property.GetDouble(Seasonal.MMR),
                MaxMMR = property.GetDouble(Seasonal.MaxMMR),
                NextRankMMR = property.GetDouble(Seasonal.NextRankMMR),
                PreviousRankMMR = property.GetDouble(Seasonal.PreviousRankMMR),

                SkillMean = property.GetDouble(Seasonal.SkillMean),
                SkillUncertainty = property.GetDouble(Seasonal.SkillUncertainty),

                LastMatchResult = (MatchResult)property.GetInt(Seasonal.LastMatchResult),
                LastMatchMMRChange = property.GetDouble(Seasonal.LastMatchMMRChange),
                LastMatchSkillChange = property.GetDouble(Seasonal.LastMatchSkillChange),
                LastMatchSkillUncertaintyChange = property.GetDouble(Seasonal.LastMatchSkillUncertaintyChange),
            };
        }
    }
}
