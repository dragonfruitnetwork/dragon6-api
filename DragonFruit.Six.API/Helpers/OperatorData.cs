// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Common.Data.Services;
using DragonFruit.Six.API.Data;
using DragonFruit.Six.API.Enums;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Helpers
{
    public static class OperatorData
    {
        public static IEnumerable<OperatorStats> GetOperatorDataFromFile(string location) =>
            GetOperatorData(FileServices.ReadFile<JArray>(location));

        public static IEnumerable<OperatorStats> GetOperatorDataFromUrl(string location) =>
            GetOperatorData(WebServices.StreamObject<JArray>(location));

        public static IEnumerable<OperatorStats> GetOperatorData(JArray data)
        {
            foreach (var jToken in data)
            {
                var element = (JObject)jToken;
                yield return new OperatorStats
                {
                    ImageURL = element.GetString("img"),
                    Name = element.GetString("name"),
                    Organisation = element.GetString("org"),
                    Index = element.GetString("index"),
                    Subtitle = element.GetString("sub"),
                    Type = (OperatorType)element.GetInt("type"),
                    OperatorActionId = element.GetString("actn"),
                    Action = element.GetString("phrase"),
                };
            }
        }
    }
}
