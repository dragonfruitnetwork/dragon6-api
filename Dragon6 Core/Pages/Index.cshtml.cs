using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonFruit.Six.Core.Pages
{
    public class IndexModel : PageModel
    {
        public bool SellWindows { get; set; }
        public bool SellAndroid { get; set; }
        public async Task OnGet()
        {
            if(!Request.Cookies.ContainsKey("token"))
            {
                var Token = await DragonFruit.Six.Core.API.Interface.TokenStruct.GetToken();

                var option = new CookieOptions();
                option.Expires = Token.Expiry;

                Response.Cookies.Append("token", Token.Token, option);
            }

            SellWindows = API.DeviceOS.IsCompatibleWindows(HttpContext.Request);
            SellAndroid = API.DeviceOS.IsCompatibleAndroid(HttpContext.Request);

        }
    }
}