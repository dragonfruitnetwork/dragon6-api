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
    public static class OperatorStatsDeserializer
    {
        public static IEnumerable<OperatorStats> DeserializeOperatorStatsFor(this JObject jObject, string guid, IEnumerable<OperatorStats> data)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var op in data.Select(x => x.Clone()))
            {
                op.Guid = guid;

                op.Kills = json.GetUInt(Operator.Kills.ToIndexedStatsKey(op.Index));
                op.Deaths = json.GetUInt(Operator.Deaths.ToIndexedStatsKey(op.Index));

                op.Wins = json.GetUInt(Operator.Wins.ToIndexedStatsKey(op.Index));
                op.Losses = json.GetUInt(Operator.Losses.ToIndexedStatsKey(op.Index));

                op.RoundsPlayed = json.GetUInt(Operator.Rounds.ToIndexedStatsKey(op.Index));
                op.Duration = json.GetUInt(Operator.Time.ToIndexedStatsKey(op.Index));

                op.Headshots = json.GetUInt(Operator.Headshots.ToIndexedStatsKey(op.Index));
                op.Downs = json.GetUInt(Operator.Downs.ToIndexedStatsKey(op.Index));

                op.Experience = json.GetUInt(Operator.Experience.ToIndexedStatsKey(op.Index));
                op.ActionCount = json.GetUInt(op.OperatorActionResultId);

                yield return op;
            }
        }
    }
}
