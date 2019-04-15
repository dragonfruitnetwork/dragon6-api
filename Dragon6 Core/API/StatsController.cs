using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Core.API
{
    [Route("api/stats/{platform=PC}/{user}/")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        [HttpGet("general")]
        public async Task<IActionResult> GeneralStats(string platform,string user)
        {
            var token = (await Interface.TokenStruct.GetToken()).Token;
            var userInf = await Dragon6.API.AccountInfo.GetFromName(user, (Dragon6.API.References.Platforms)Enum.Parse(typeof(Dragon6.API.References.Platforms), platform, true), token);
            return Content(JsonConvert.SerializeObject(await Dragon6.API.PlayerStats.GetStats(userInf, token),Formatting.Indented));
        }

        [HttpGet("ranked/{region=emea}/{season=-1}")]
        public async Task<IActionResult> RankedStats(string platform, string user, string region, int season)
        {
            var token = (await Interface.TokenStruct.GetToken()).Token;
            var userInf = await Dragon6.API.AccountInfo.GetFromName(user, (Dragon6.API.References.Platforms)Enum.Parse(typeof(Dragon6.API.References.Platforms), platform, true), token);
            return Content(JsonConvert.SerializeObject(await Dragon6.API.SeasonalStats.GetSeason(userInf,season,region, token), Formatting.Indented));
        }

        [HttpGet("operators")]
        public async Task<IActionResult> OperatorStats(string platform,string user)
        {
            var token = (await Interface.TokenStruct.GetToken()).Token;
            var userInf = await Dragon6.API.AccountInfo.GetFromName(user, (Dragon6.API.References.Platforms)Enum.Parse(typeof(Dragon6.API.References.Platforms), platform, true), token);
            return Content(JsonConvert.SerializeObject(await Dragon6.API.OperatorStats.GetOperatorStats(userInf, token), Formatting.Indented));
        }

        [HttpGet("info")]
        public async Task<IActionResult> AccountInfo(string platform,string user)
        {
            var token = (await Interface.TokenStruct.GetToken()).Token;
            var userInf = await Dragon6.API.AccountInfo.GetFromName(user, (Dragon6.API.References.Platforms)Enum.Parse(typeof(Dragon6.API.References.Platforms), platform, true), token);
            var InfoObject = new JObject
            {
                {"Username",userInf.PlayerName },
                {"Image",userInf.Image },
                {"Platform",userInf.Platform.ToString() },
                {"iD",userInf.GUID }
            };
            return Content(JsonConvert.SerializeObject(InfoObject, Formatting.Indented));
        }

        [HttpGet]
        public async Task<IActionResult> AllStats(string platform,string user)
        {
            var token = (await Interface.TokenStruct.GetToken()).Token;
            var userInf = await Dragon6.API.AccountInfo.GetFromName(user, (Dragon6.API.References.Platforms)Enum.Parse(typeof(Dragon6.API.References.Platforms), platform, true), token);
            var InfoObject = new JObject
            {
                {"Username",userInf.PlayerName },
                {"Image",userInf.Image },
                {"Platform",userInf.Platform.ToString() },
                {"iD",userInf.GUID },
                {"Level", JToken.FromObject(await Dragon6.API.PlayerStats.GetLevel(userInf, token))},
                {"GeneralStats", JToken.FromObject(await Dragon6.API.PlayerStats.GetStats(userInf, token)) },
                {"OperatorStats", JToken.FromObject(await Dragon6.API.OperatorStats.GetOperatorStats(userInf, token))}
            };
            return Content(JsonConvert.SerializeObject(InfoObject, Formatting.Indented));

        }
    }
}