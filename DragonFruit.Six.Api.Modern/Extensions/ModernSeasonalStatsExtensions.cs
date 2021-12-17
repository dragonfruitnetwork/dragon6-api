// Dragon6 API Copyright 2020-2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern.Extensions
{
    public static class ModernSeasonalStatsExtensions
    {
        public static ModernModeStatsContainer<IEnumerable<ModernSeasonStats>> GetModernSeasonStatsFor<T>(this T client, AccountInfo account, PlaylistType playlistType = PlaylistType.All)
            where T : ModernDragon6Client
        {
            var request = new ModernSeasonalStatsRequest(account)
            {
                Playlist = playlistType
            };

            return client.Perform<JObject>(request)
                         .ProcessData<IEnumerable<ModernSeasonStats>>(request, client);
        }
    }
}
