using System;
using System.Collections.Generic;
using System.Text;

namespace Dragon6.API.Http
{
    public class Endpoints
    {
        public static readonly Dictionary<References.Platforms, string> Stats = new Dictionary<References.Platforms, string>
        {
            { References.Platforms.PSN, "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics" },
            { References.Platforms.XB1, "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics" },
            { References.Platforms.PC, "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics" }
        };

        public static readonly Dictionary<References.Platforms, string> RankedStats = new Dictionary<References.Platforms, string>
        {
            { References.Platforms.PSN, "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players" },
            { References.Platforms.XB1, "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players" },
            { References.Platforms.PC, "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players" }
        };

        public static readonly Dictionary<References.Platforms, string> ProfileInfo = new Dictionary<References.Platforms, string>
        {
            { References.Platforms.PSN, "https://public-ubiservices.ubi.com/v1/spaces/05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions" },
            { References.Platforms.XB1, "https://public-ubiservices.ubi.com/v1/spaces/98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions" },
            { References.Platforms.PC, "https://public-ubiservices.ubi.com/v1/spaces/5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions" }
        };

        public const string TokenServer = "https://uplayconnect.ubi.com/ubiservices/v2/profiles/sessions";
        public const string UplayIDServer = "https://public-ubiservices.ubi.com/v2/profiles";
    }
}
