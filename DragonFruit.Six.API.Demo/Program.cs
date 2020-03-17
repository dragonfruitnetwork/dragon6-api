// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Six.API.Clients;
using DragonFruit.Six.API.Data.Extensions;
using DragonFruit.Six.API.Data.Tokens;
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
            var client = new HttpClient();
            var d6Client = new Dragon6Client();

            //YOU MUST GET PERMISSION BEFORE USING OUR SERVERS
            using var operatorInformationTask = Task.Run(async () => OperatorData.GetOperatorData(await client.GetStringAsync("https://d6static.dragonfruit.network/data/operators.json"), false));

            d6Client.Token = new Dragon6Token
            {
                Token = await client.GetStringAsync("https://dragon6.dragonfruit.network/api/token"),
                Expiry = DateTimeOffset.Now.AddHours(1)
            };

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
