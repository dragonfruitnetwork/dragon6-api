// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
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
        public static ILookup<string, SeasonStats> DeserializeSeasonStats(this JObject jObject)
        {
            var results = jObject[Misc.Players]?.ToObject<Dictionary<string, JObject>>();
            var enumeratedResults = results?.Select(DeserializeInternal) ?? Enumerable.Empty<SeasonStats>();

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static SeasonStats DeserializeInternal(KeyValuePair<string, JObject> data) => new()
        {
            ProfileId = data.Key,

            TimeUpdated = DateTime.Parse(data.Value.GetString(Seasonal.TimeUpdated, DateTime.Now.ToString(Dragon6Client.Culture)), Dragon6Client.Culture),
            SeasonId = data.Value.GetByte(Seasonal.Season),

            Kills = data.Value.GetUInt(Seasonal.Kills),
            Deaths = data.Value.GetUInt(Seasonal.Deaths),

            Wins = data.Value.GetUInt(Seasonal.Wins),
            Losses = data.Value.GetUInt(Seasonal.Losses),
            Abandons = data.Value.GetUInt(Seasonal.Abandons),

            Rank = data.Value.GetInt(Seasonal.Rank),
            MaxRank = data.Value.GetInt(Seasonal.MaxRank),
            TopRankPosition = data.Value.GetUInt(Seasonal.TopRankPosition),

            MMR = data.Value.GetDouble(Seasonal.MMR),
            MaxMMR = data.Value.GetDouble(Seasonal.MaxMMR),
            NextRankMMR = data.Value.GetDouble(Seasonal.NextRankMMR),
            PreviousRankMMR = data.Value.GetDouble(Seasonal.PreviousRankMMR),

            SkillMean = data.Value.GetDouble(Seasonal.SkillMean),
            SkillUncertainty = data.Value.GetDouble(Seasonal.SkillUncertainty),

            LastMatchResult = (MatchResult)data.Value.GetUInt(Seasonal.LastMatchResult),
            LastMatchMMRChange = data.Value.GetDouble(Seasonal.LastMatchMMRChange),
            LastMatchSkillChange = data.Value.GetDouble(Seasonal.LastMatchSkillChange),
            LastMatchSkillUncertaintyChange = data.Value.GetDouble(Seasonal.LastMatchSkillUncertaintyChange),
        };
    }
}
