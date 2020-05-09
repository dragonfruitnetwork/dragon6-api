// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Developer.Clients;
using DragonFruit.Six.Developer.Objects;
using DragonFruit.Six.Developer.Requests;

namespace DragonFruit.Six.Developer.Extensions
{
    public static class DeveloperClientExtensions
    {
        public static DeveloperToken GetDeveloperToken(this Dragon6DeveloperClient client) => client.Perform<DeveloperToken>(new DeveloperTokenRequest());
    }
}
