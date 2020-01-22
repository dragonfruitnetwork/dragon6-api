// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;

namespace DragonFruit.Six.API
{
    public static class Endpoints
    {
        private const string BaseEndpoint = "https://public-ubiservices.ubi.com";
        internal const string OperatorMapping = "https://dragon6-224813.firebaseapp.com/operatorinfo.json";

        private const string StatsBase = BaseEndpoint + "/v1/spaces/";
        public static readonly string IdServer = BaseEndpoint + "/v3/profiles";
        public static readonly string TokenServer = IdServer + "/sessions";

        public static readonly Dictionary<References.Platforms, string> Stats =
            new Dictionary<References.Platforms, string>
            {
                [References.Platforms.PSN] =
                    StatsBase + "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/playerstats2/statistics",

                [References.Platforms.XB1] =
                    StatsBase + "98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/playerstats2/statistics",

                [References.Platforms.PC] =
                    StatsBase + "5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/playerstats2/statistics"
            };

        public static readonly Dictionary<References.Platforms, string> RankedStats =
            new Dictionary<References.Platforms, string>
            {
                [References.Platforms.PSN] =
                    StatsBase + "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6karma/players",

                [References.Platforms.XB1] =
                    StatsBase + "98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6karma/players",

                [References.Platforms.PC] =
                    StatsBase + "5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6karma/players"
            };

        public static readonly Dictionary<References.Platforms, string> ProfileInfo =
            new Dictionary<References.Platforms, string>
            {
                [References.Platforms.PSN] =
                    StatsBase + "05bfb3f7-6c21-4c42-be1f-97a33fb5cf66/sandboxes/OSBOR_PS4_LNCH_A/r6playerprofile/playerprofile/progressions",

                [References.Platforms.XB1] =
                    StatsBase + "98a601e5-ca91-4440-b1c5-753f601a2c90/sandboxes/OSBOR_XBOXONE_LNCH_A/r6playerprofile/playerprofile/progressions",

                [References.Platforms.PC] =
                    StatsBase + "5172a557-50b5-4665-b7db-e3f2e8c5041d/sandboxes/OSBOR_PC_LNCH_A/r6playerprofile/playerprofile/progressions"
            };
    }
}
