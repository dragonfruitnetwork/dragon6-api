using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DragonFruit.Six.Core.Pages.Info
{
    public class IndexModel : PageModel
    {
        public List<Dragon6.API.AccountInfo> Developers { get; set; }
        public async Task OnGetAsync()
        {
            string token = (await API.Interface.TokenStruct.GetToken()).Token;
            Developers = new List<Dragon6.API.AccountInfo>()
            {
                { await Dragon6.API.AccountInfo.ReverseID_PC("14c01250-ef26-4a32-92ba-e04aa557d619",token) },
                { await Dragon6.API.AccountInfo.ReverseID_PC("d38ade45-e581-4d63-a5f0-0ab61445e5ab",token) }
            };
        }
    }
}