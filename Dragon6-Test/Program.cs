using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using Dragon6.API.Stats;

namespace Dragon6.API.Test
{
    class Program
    {
        async static Task Main(string[] args)
        {
            string token = await new HttpClient().GetAsync("https://dragon6.dragonfruit.network/api/token").Result.Content.ReadAsStringAsync(); //YOU MUST GET PERMISSION BEFORE USING OUR TOKEN SERVER
            var PlayerInfo = await AccountInfo.ReverseID_PC("14c01250-ef26-4a32-92ba-e04aa557d619", token);

            var GeneralStats = await General.GetStats(PlayerInfo, token);
            var SeasonStats = await Season.GetSeason(PlayerInfo, "EMEA", token);
            var OPStats = await Operator.GetOperatorStats(PlayerInfo, token);
            var Weapons = await Weapon.GetWeaponStats(PlayerInfo, token);
            var Level = await General.GetLevel(PlayerInfo, token);

            var Account = new JObject()
            {
                {"PlayerInfo",JToken.FromObject(PlayerInfo)},
                {"Level",Level},
                {"GeneralStats",JToken.FromObject(GeneralStats)},
                {"Ranked",JToken.FromObject(SeasonStats)},
                {"Operator",JToken.FromObject(OPStats)},
                {"Weapon", JToken.FromObject(Weapons) }
            };

            Console.WriteLine(JsonConvert.SerializeObject(Account, Formatting.Indented));

            Environment.Exit(0);
        }
    }
}
