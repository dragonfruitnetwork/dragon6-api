// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Developer.Requests;

namespace DragonFruit.Six.API.Developer.Extensions
{
    public static class DeveloperClientExtensions
    {
        public static TokenBase GetDeveloperToken(this Dragon6DeveloperClient client) => client.Perform<Dragon6Token>(new DeveloperTokenRequest());
    }
}
