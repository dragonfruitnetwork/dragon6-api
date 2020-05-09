// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Threading.Tasks;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Enums;
using DragonFruit.Six.API.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Demo
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
#if TESTING_TOKEN
            var authclient = new UbisoftAuthClient(Environment.GetEnvironmentVariable("Dragon6-Login", EnvironmentVariableTarget.User));
            authclient.GetToken();
#endif

            var d6Client = new Dragon6DemoClient();
            using var operatorInformationTask = Task.Run(() => OperatorData.FromUrl("https://d6static.dragonfruit.network/data/operators.json"));

            var playerInfo = d6Client.GetUser(Platform.PC, LookupMethod.PlatformId, "14c01250-ef26-4a32-92ba-e04aa557d619");

            var level = d6Client.GetLevel(playerInfo);
            var loginInfo = d6Client.GetLoginInfo(playerInfo);

            var seasonStats = d6Client.GetSeasonStats(playerInfo, "EMEA");

            var generalStats = d6Client.GetStats(playerInfo);
            var opStats = d6Client.GetOperatorStats(playerInfo, await operatorInformationTask);
            var weapons = d6Client.GetWeaponStats(playerInfo);

            var stats = new JObject
            {
                { "general", JToken.FromObject(generalStats) },
                { "ranked", JToken.FromObject(seasonStats) },
                { "operator", JToken.FromObject(opStats) },
                { "weapon", JToken.FromObject(weapons) }
            };

            var account = new JObject
            {
                { "account", JToken.FromObject(playerInfo) },
                { "login", JToken.FromObject(loginInfo) },
                { "level", JToken.FromObject(level) },
                { "stats", JToken.FromObject(stats) },
            };

            Console.Write(JsonConvert.SerializeObject(account, Formatting.Indented));

            Environment.Exit(0);
        }
    }
}
