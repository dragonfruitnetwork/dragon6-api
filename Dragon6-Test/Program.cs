using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using Dragon6.API.Stats;
using Dragon6.API.Verification;

namespace Dragon6.API.Test
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var client = new HttpClient();

            //YOU MUST GET PERMISSION BEFORE USING OUR SERVERS
            var setupVerificationTask = Task.Run(() => Server.Init("https://dragon6.dragonfruit.network/api/accountstatus/all"));
            string token = await client.GetAsync("https://dragon6.dragonfruit.network/api/token").Result.Content.ReadAsStringAsync(); 

            client.Dispose();
            await setupVerificationTask;

            var playerInfo = await AccountInfo.ReverseID_PC("14c01250-ef26-4a32-92ba-e04aa557d619", token);
            var generalStats = await General.GetStats(playerInfo, token);
            var seasonStats = await Season.GetSeason(playerInfo, "EMEA", token);
            var opStats = await Operator.GetOperatorStats(playerInfo, token);
            var weapons = await Weapon.GetWeaponStats(playerInfo, token);
            var level = await General.GetLevel(playerInfo, token);

            var account = new JObject()
            {
                {"PlayerInfo", JToken.FromObject(playerInfo)},
                {"Level", level},
                {"GeneralStats", JToken.FromObject(generalStats)},
                {"Ranked", JToken.FromObject(seasonStats)},
                {"Operator", JToken.FromObject(opStats)},
                {"Weapon", JToken.FromObject(weapons) }
            };

            Console.Write(JsonConvert.SerializeObject(account, Formatting.Indented));

            Environment.Exit(0);
        }
    }
}
