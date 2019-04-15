using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Core.API
{
    [Route("/api/ranked/regions/locate")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRegion()
        {
            string ip = HttpContext.Connection.RemoteIpAddress.ToString();

            try
            {
                ip = HttpContext.Request.Headers.ContainsKey("X-Forwarded-For") ? HttpContext.Request.Headers["X-Forwarded-For"] : HttpContext.Request.Headers["x-appengine-user-ip"];
            }
            catch { }

            string region =
                JObject.Parse(await new HttpClient().GetAsync($"http://api.ipstack.com/{ip}?access_key=b71ef5e1564ab15d9f7644366c148c3e").Result.Content.ReadAsStringAsync())
                ["continent_code"].ToString();

            if (region == "EU" || region == "AF")
                return Content("emea");
            if (region == "NA" || region == "SA")
                return Content("ncsa");
            if (region == "AS" || region == "OC")
                return Content("apac");
            return NotFound();
        }
    }
}