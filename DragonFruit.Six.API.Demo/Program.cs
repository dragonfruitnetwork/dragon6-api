// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Threading.Tasks;
using DragonFruit.Six.API.Stats;
using DragonFruit.Six.API.Verification;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Demo
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            //YOU MUST GET PERMISSION BEFORE USING OUR SERVERS
            using var setupVerificationTask = Task.Run(() => Server.Init("https://dragon6.dragonfruit.network/api/accountstatus/all"));
            string token = await client.GetStringAsync("https://dragon6.dragonfruit.network/api/token");

            await setupVerificationTask;

            var playerInfo = await AccountInfo.GetUser(Platforms.PC, LookupMethod.PlatformId, "14c01250-ef26-4a32-92ba-e04aa557d619", token);
            var generalStats = await GeneralStats.GetStats(playerInfo, token);
            var seasonStats = await Season.GetSeason(playerInfo, "EMEA", token);
            var opStats = await Operator.GetOperatorStats(playerInfo, token, null, null);
            var weapons = await WeaponStats.GetWeaponStats(playerInfo, token);
            var level = await PlayerLevel.GetLevel(playerInfo, token);

            var account = new JObject
            {
                { "PlayerInfo", JToken.FromObject(playerInfo) },
                { "Level", JToken.FromObject(level) },
                { "GeneralStats", JToken.FromObject(generalStats) },
                { "Ranked", JToken.FromObject(seasonStats) },
                { "Operator", JToken.FromObject(opStats) },
                { "Weapon", JToken.FromObject(weapons) }
            };

            Console.Write(JsonConvert.SerializeObject(account, Formatting.Indented));

            Environment.Exit(0);
        }
    }
}
