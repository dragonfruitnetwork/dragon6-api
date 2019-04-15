using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dragon6.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonFruit.Six.Core.Pages.Stats
{
    public class RankedModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Platform { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        [BindProperty(SupportsGet =true)]
        public string Year { get; set; }
        public string Region { get; set; }
        private string Token { get; set; }
        public AccountStatus Status { get; set; }
        public bool IsVerified { get; set; }
        public AccountInfo Info { get; set; }

        public List<SeasonalStats> Stats;

        public List<API.RankedCards> Cards;
        public async Task OnGet()
        {
            //1a. token
            if (!Request.Cookies.ContainsKey("token"))
            {
                var token = await DragonFruit.Six.Core.API.Interface.TokenStruct.GetToken();

                var option = new CookieOptions();
                option.Expires = token.Expiry;

                Response.Cookies.Append("token", token.Token, option);
                Token = token.Token;
            }
            else
                Token = Request.Cookies["token"];

            //1b. region
            if (!Request.Cookies.ContainsKey("region"))
                Region = "emea";
            else
                Region = Request.Cookies["region"];


            //2. get account info
            Info = await AccountInfo.GetFromName(UserName, (References.Platforms)Enum.Parse(typeof(References.Platforms), Platform, true), Token);

            //3. start tasks
            Cards = API.RankedCards.GetCardsByYear(int.Parse(Year));
            Stats = new List<SeasonalStats>();
            foreach(var x in Cards)
            {
                Stats.Add(await SeasonalStats.GetSeason(Info, x.id, Region, Token));
            }
        }
    }
}