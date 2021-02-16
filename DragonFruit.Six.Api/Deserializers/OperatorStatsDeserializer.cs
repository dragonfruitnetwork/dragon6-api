// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class OperatorStatsDeserializer
    {
        public static ILookup<string, OperatorStats> DeserializeOperatorStats(this JObject jObject, IEnumerable<OperatorStats> data)
        {
            var results = jObject[Misc.Results]?.ToObject<Dictionary<string, JObject>>();
            var enumeratedResults = results?.SelectMany(x => DeserializeInternal(x, data)) ?? Enumerable.Empty<OperatorStats>();

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static IEnumerable<OperatorStats> DeserializeInternal(KeyValuePair<string, JObject> data, IEnumerable<OperatorStats> operators)
        {
            foreach (var op in operators.Select(x => x.Clone()))
            {
                op.ProfileId = data.Key;

                op.Kills = data.Value.GetUInt(Operator.Kills.ToIndexedStatsKey(op.Index));
                op.Deaths = data.Value.GetUInt(Operator.Deaths.ToIndexedStatsKey(op.Index));

                op.Wins = data.Value.GetUInt(Operator.Wins.ToIndexedStatsKey(op.Index));
                op.Losses = data.Value.GetUInt(Operator.Losses.ToIndexedStatsKey(op.Index));

                op.RoundsPlayed = data.Value.GetUInt(Operator.Rounds.ToIndexedStatsKey(op.Index));
                op.Duration = data.Value.GetUInt(Operator.Time.ToIndexedStatsKey(op.Index));

                op.Headshots = data.Value.GetUInt(Operator.Headshots.ToIndexedStatsKey(op.Index));
                op.Downs = data.Value.GetUInt(Operator.Downs.ToIndexedStatsKey(op.Index));

                op.Experience = data.Value.GetUInt(Operator.Experience.ToIndexedStatsKey(op.Index));
                op.ActionCount = (uint?)data.Value[op.OperatorActionResultId];

                yield return op;
            }
        }

        public static IEnumerable<OperatorStats> DeserializeOperatorTrainingStatsFor(this JObject jObject, string guid, IEnumerable<OperatorStats> data)
        {
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                yield break;

            foreach (var op in data.Select(x => x.Clone()))
            {
                op.Guid = guid;

                op.Kills = json.GetUInt(Operator.KillsTraining.ToIndexedStatsKey(op.Index));
                op.Deaths = json.GetUInt(Operator.DeathsTraining.ToIndexedStatsKey(op.Index));

                op.Wins = json.GetUInt(Operator.WinsTraining.ToIndexedStatsKey(op.Index));
                op.Losses = json.GetUInt(Operator.LossesTraining.ToIndexedStatsKey(op.Index));

                op.RoundsPlayed = json.GetUInt(Operator.RoundsTraining.ToIndexedStatsKey(op.Index));
                op.Duration = json.GetUInt(Operator.TimeTraining.ToIndexedStatsKey(op.Index));

                op.Headshots = json.GetUInt(Operator.HeadshotsTraining.ToIndexedStatsKey(op.Index));
                op.Downs = json.GetUInt(Operator.DownsTraining.ToIndexedStatsKey(op.Index));

                op.Experience = json.GetUInt(Operator.ExperienceTraining.ToIndexedStatsKey(op.Index));
                op.ActionCount = (uint?)json[op.OperatorActionResultId];

                yield return op;
            }
        }
    }
}
