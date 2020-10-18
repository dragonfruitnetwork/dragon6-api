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
            "casualpvp_death",
            "casualpvp_kills",
            "casualpvp_matchlost",
            "casualpvp_matchplayed",
            "casualpvp_matchwon",
            "casualpvp_timeplayed",

            "rankedpvp_kills",
            "rankedpvp_death",
            "rankedpvp_matchlost",
            "rankedpvp_matchplayed",
            "rankedpvp_matchwon",
            "rankedpvp_timeplayed",

            "generalpve_death",
            "generalpve_kills",
            "generalpve_matchlost",
            "generalpve_matchplayed",
            "generalpve_matchwon",
            "generalpve_timeplayed",
            "generalpvp_barricadedeployed",
            "generalpvp_bulletfired",
            "generalpvp_bullethit",
            "generalpvp_dbno",
            "generalpvp_death",
            "generalpvp_gadgetdestroy",
            "generalpvp_headshot",
            "generalpvp_killassists",
            "generalpvp_kills",
            "generalpvp_matchlost",
            "generalpvp_matchplayed",
            "generalpvp_matchwon",
            "generalpvp_meleekills",
            "generalpvp_penetrationkills",
            "generalpvp_reinforcementdeploy",
            "generalpvp_revive",
            "generalpvp_revive",
            "generalpvp_suicide",
            "generalpvp_timeplayed",

            "plantbombpvp_bestscore",
            "plantbombpvp_matchlost",
            "plantbombpvp_matchplayed",
            "plantbombpvp_matchwon",
            "plantbombpvp_timeplayed",

            "rescuehostagepvp_bestscore",
            "rescuehostagepvp_matchlost",
            "rescuehostagepvp_matchplayed",
            "rescuehostagepvp_matchwon",
            "rescuehostagepvp_timeplayed",

            "secureareapvp_bestscore",
            "secureareapvp_matchlost",
            "secureareapvp_matchplayed",
            "secureareapvp_matchwon",
            "secureareapvp_timeplayed"
        };
    }
}
