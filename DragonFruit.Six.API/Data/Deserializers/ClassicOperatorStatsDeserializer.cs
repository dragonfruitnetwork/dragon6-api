// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class ClassicOperatorStatsDeserializer
    {
        public static IEnumerable<ClassicOperatorStats> DeserializeClassicOperatorStatsFor(this JObject jObject, string guid, IEnumerable<ClassicOperatorStats> data)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var op in data.Select(x => x.Clone()))
            {
                op.Guid = guid;

                op.Kills = json.GetUInt(ClassicOperator.Kills.ToIndexedStatsKey(op.Index));
                op.Deaths = json.GetUInt(ClassicOperator.Deaths.ToIndexedStatsKey(op.Index));

                op.Wins = json.GetUInt(ClassicOperator.Wins.ToIndexedStatsKey(op.Index));
                op.Losses = json.GetUInt(ClassicOperator.Losses.ToIndexedStatsKey(op.Index));

                op.RoundsPlayed = json.GetUInt(ClassicOperator.Rounds.ToIndexedStatsKey(op.Index));
                op.Duration = json.GetUInt(ClassicOperator.Time.ToIndexedStatsKey(op.Index));

                op.Headshots = json.GetUInt(ClassicOperator.Headshots.ToIndexedStatsKey(op.Index));
                op.Downs = json.GetUInt(ClassicOperator.Downs.ToIndexedStatsKey(op.Index));

                op.Experience = json.GetUInt(ClassicOperator.Experience.ToIndexedStatsKey(op.Index));
                op.ActionCount = (uint?)json[op.OperatorActionResultId];

                yield return op;
            }
        }
    }
}