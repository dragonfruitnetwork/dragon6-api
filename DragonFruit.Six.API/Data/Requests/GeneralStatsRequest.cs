// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    public sealed class GeneralStatsRequest : BasicStatsRequest
    {
        public GeneralStatsRequest(AccountInfo account)
            : base(account)
        {
        }

        public GeneralStatsRequest(IEnumerable<AccountInfo> accounts)
            : base(accounts)
        {
        }

        public override IEnumerable<string> Stats { get; set; } = new[]
        {
            "rankedpvp_death",
            "rankedpvp_kdratio",
            "rankedpvp_kills",
            "rankedpvp_matchlost",
            "rankedpvp_matchplayed",
            "rankedpvp_matchwlratio",
            "rankedpvp_matchwon",
            "rankedpvp_timeplayed",
            "casualpvp_death",
            "casualpvp_kdratio",
            "casualpvp_kills",
            "casualpvp_matchlost",
            "casualpvp_matchplayed",
            "casualpvp_matchwlratio",
            "casualpvp_matchwon",
            "casualpvp_timeplayed",
            "generalpvp_barricadedeployed",
            "generalpvp_dbno",
            "generalpvp_death",
            "generalpvp_headshot",
            "generalpvp_killassists",
            "generalpvp_kills",
            "generalpvp_matchlost",
            "generalpvp_matchwlratio",
            "generalpvp_matchwon",
            "generalpvp_meleekills",
            "generalpvp_reinforcementdeploy",
            "generalpvp_revive",
            "generalpvp_suicide",
            "generalpvp_timeplayed",
            "generalpvp_revive",
            "generalpve_kills",
            "generalpve_death",
            "generalpve_matchwon",
            "generalpve_matchlost",
            "custompvp_timeplayed",
            "plantbombpvp_bestscore",
            "rescuehostagepvp_bestscore",
            "secureareapvp_bestscore",
            "casualpvp_timeplayed",
            "rankedpvp_timeplayed",
            "generalpve_timeplayed",
            "generalpvp_bulletfired",
            "generalpvp_penetrationkills",
            "generalpvp_bullethit"
        };
    }
}
