// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;

namespace DragonFruit.Six.API.Verification
{
    public class LevelInfo
    {
        public static readonly Dictionary<Level, string> Name = new Dictionary<Level, string>
        {
            { Level.Blocked, "Data Blocked by Request" },
            { Level.Normal, "Standard User" },
            { Level.Verified, "Verified User" },
            { Level.Beta, "Beta Tester" },
            { Level.Translator, "Dragon6 Translator" },
            { Level.Supporter, "Dragon6 Supporter" },
            { Level.Developer, "Dragon6 Admin" }
        };

        public static readonly Dictionary<Level, string> Icon = new Dictionary<Level, string>
        {
            { Level.Blocked, "explore_off" },
            { Level.Normal, "face" },
            { Level.Verified, "check" },
            { Level.Beta, "bug_report" },
            { Level.Translator, "translate" },
            { Level.Supporter, "favorite" },
            { Level.Developer, "verified_user" }
        };

        public static readonly Dictionary<Level, string> Color = new Dictionary<Level, string>
        {
            { Level.Blocked, "#bd1818" },
            { Level.Normal, "#ffffff" },
            { Level.Verified, "#20B2AA" },
            { Level.Beta, "#FFA500" },
            { Level.Translator, "#8A2BE2" },
            { Level.Supporter, "#FFB6C1" },
            { Level.Developer, "#90EE90" }
        };
    }
}
