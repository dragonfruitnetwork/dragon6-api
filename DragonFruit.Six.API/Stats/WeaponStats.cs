// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;

namespace DragonFruit.Six.API.Stats
{
    public class WeaponStats
    {
        public string Guid { get; set; }

        public string ClassName { get; set; }

        public byte ClassID { get; set; }

        public uint Kills { get; set; }

        public uint Headshots { get; set; }

        public uint ShotsFired { get; set; }

        public uint ShotsLanded { get; set; }

        public static async Task<IEnumerable<WeaponStats>> GetWeaponStats(AccountInfo account, string token) => (await GetWeaponStats(new[] { account }, token).ConfigureAwait(false)).First();

        public static async Task<IEnumerable<IEnumerable<WeaponStats>>> GetWeaponStats(IEnumerable<AccountInfo> accounts, string token)
        {
            var results = new List<IEnumerable<WeaponStats>>();

            await foreach (var result in GetWeaponStatsAsync(accounts, token))
                results.Add(result);

            return results;
        }

        public static async IAsyncEnumerable<IEnumerable<WeaponStats>> GetWeaponStatsAsync(IEnumerable<AccountInfo> accounts, string token)
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var ids = group.Select(x => x.Guid);
                var rawData = await Task.Run(() => d6WebRequest.GetWebObject(d6WebRequest.FormStatsUrl(group.Key, ids,
                    "weapontypepvp_kills,weapontypepvp_headshot,weapontypepvp_bulletfired,weapontypepvp_bullethit"), token));

                foreach (var id in ids)
                    yield return rawData.ToWeaponStats(id);
            }
        }
    }
}
