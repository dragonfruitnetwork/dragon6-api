// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Enums;

namespace DragonFruit.Six.Api.Services.Developer
{
    public class Dragon6TokenRequest : Dragon6DeveloperApiRequest
    {
        public override string Path => "https://dragon6.dragonfruit.network/api/v3/token/raw";

        public Dragon6TokenRequest(UbisoftService service)
        {
            Service = service;
        }

        [QueryParameter("appid", EnumHandlingMode.StringLower)]
        public UbisoftService Service { get; }
    }
}
