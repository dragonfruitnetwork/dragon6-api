// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DragonFruit.Common.Storage.Shared;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Processing;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Stats
{
public class LoginInfo
{
    public string Guid {
        get;
        set;
    }

    public Platforms Platform {
        get;
        set;
    }

    public uint SessionCount {
        get;
        set;
    }

    public DateTime FirstLogin {
        get;
        set;
    }

    public DateTime LastLogin {
        get;
        set;
    }

    public static async Task<LoginInfo> GetLoginInfo(AccountInfo account, string token) => (await GetLoginInfo(new[] { account }, token)).First();

    public static async Task<IEnumerable<LoginInfo>> GetLoginInfo(IEnumerable<AccountInfo> accounts, string token)
    {
        var results = new List<LoginInfo>();

        await foreach (var result in GetLoginInfoAsync(accounts, token))
            results.Add(result);

        return results;
    }

    public static async IAsyncEnumerable<LoginInfo> GetLoginInfoAsync(IEnumerable<AccountInfo> accounts, string token)
    {
        var url = $"{Endpoints.IdServer}/applications?applicationIds={string.Join(',', References.GameIds.Select(x => x.Value))}&profileIds={string.Join(',', accounts.Select(x => x.Guid))}";
        var parseCulture = new CultureInfo("en-us");
        var platformLookup = References.GameIds.ToDictionary(x => x.Value, x => x.Key);

        var data = (JArray)(await Task.Run(() => d6WebRequest.GetWebObject(url, token)))["applications"];

        foreach (var jToken in data)
        {
            var entry = (JObject)jToken;
            yield return new LoginInfo
            {
                Guid = entry.GetString(LoginData.Guid),
                FirstLogin = DateTime.Parse(entry.GetString(LoginData.FirstLogin), parseCulture),
                LastLogin = DateTime.Parse(entry.GetString(LoginData.LastLogin), parseCulture),
                SessionCount = entry.GetUInt(LoginData.Sessions),
                Platform = platformLookup[entry.GetString(LoginData.PlatformId)]
            };
        }
    }
}
}
