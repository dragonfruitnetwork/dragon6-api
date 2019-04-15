using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dragon6.API;
using Microsoft.AspNetCore.Http;

namespace DragonFruit.Six.Core.Pages.Stats
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public string Platform { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }
        
        public string Region { get; set; }

        private string Token { get; set; }

        public AccountInfo Info { get; set; }
        public PlayerStats Stats { get; set; }
        public List<OperatorStats> OPStats { get; set; }
        public SeasonalStats CurrentSeason { get; set; }
        public int PlayerLevel { get; set; }
        public bool IsVerified { get; set; }
        public AccountStatus Status { get; set; }

        //ASYNC TASKS
        private Task<PlayerStats> GeneralStatsTask;
        private Task<SeasonalStats> RankedStatsTask;
        private Task<List<OperatorStats>> OperatorStatsTask;
        private Task<int> GetLevelStatTask;

        public async Task OnGetAsync()
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

            //3. start all the tasks simultaneously
            OperatorStatsTask = Task.Run(async () => await OperatorStats.GetOperatorStats(Info, Token));
            GeneralStatsTask = Task.Run(async () => await PlayerStats.GetStats(Info, Token));
            RankedStatsTask = Task.Run(async () => await SeasonalStats.GetSeason(Info,-1,Region, Token));
            GetLevelStatTask = Task.Run(async () => await PlayerStats.GetLevel(Info, Token));

            //4. verified accounts
            Status = AccountStatus.GetStatus(Info.GUID);

            //5. collect stats for viewing
            PlayerLevel = await GetLevelStatTask;
            CurrentSeason = await RankedStatsTask;
            Stats = await GeneralStatsTask;
            OPStats = await OperatorStatsTask;
        }
    }
}