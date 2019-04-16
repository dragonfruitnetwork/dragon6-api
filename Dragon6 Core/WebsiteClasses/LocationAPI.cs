using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core.WebsiteClasses
{
    public class LocationAPI
    {
        public static async Task<string> GetRegionAsync(HttpContext Context,IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                return "emea";
            string ip = Context.Connection.RemoteIpAddress.ToString();

            try
            {
                ip = Context.Request.Headers.ContainsKey("X-Forwarded-For") ? Context.Request.Headers["X-Forwarded-For"] : Context.Request.Headers["x-appengine-user-ip"];
                if (ip == null || ip == "null")
                    ip = Context.Connection.RemoteIpAddress.ToString();
            }
            catch { }

            string region =
                JObject.Parse(await new HttpClient().GetAsync($"http://api.ipstack.com/{ip}?access_key=b71ef5e1564ab15d9f7644366c148c3e").Result.Content.ReadAsStringAsync())
                ["continent_code"].ToString();

            if (region == "EU" || region == "AF")
                return "emea";
            if (region == "NA" || region == "SA")
                return "ncsa";
            if (region == "AS" || region == "OC")
                return "apac";
            else
                return "nsca";

        }
    }
}
