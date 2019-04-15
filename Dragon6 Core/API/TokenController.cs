using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DragonFruit.Six.Core.API
{
    [Route("api/token/")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Token()
        {
            return Content((await Interface.TokenStruct.GetToken()).Token);
        }

        [HttpGet("offline")]
        public async Task<IActionResult> OfflineToken()
        {
            return Content(JsonConvert.SerializeObject(await Interface.TokenStruct.GetToken()));
        }

    }
}