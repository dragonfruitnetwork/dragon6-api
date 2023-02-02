// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DragonFruit.Six.Api.Accounts.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Platform
    {
        [EnumMember(Value = UbisoftPlatforms.PC)]
        PC = 1,

        [EnumMember(Value = UbisoftPlatforms.PLAYSTATION)]
        PSN = 2,

        [EnumMember(Value = UbisoftPlatforms.XBOX)]
        XB1 = 3,

        [EnumMember(Value = UbisoftPlatforms.CROSSPLAY)]
        CrossPlatform = 4
    }
}
