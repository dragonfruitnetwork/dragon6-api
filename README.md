# Dragon6 API

![NuGet Publishing](https://github.com/dragonfruitnetwork/Dragon6-API/workflows/Publish/badge.svg)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/b9aeacb9dd754f4a8bc50fb3498958ab)](https://www.codacy.com/gh/dragonfruitnetwork/dragon6-api)
[![NuGet](https://img.shields.io/nuget/v/Dragon6.API)](https://www.nuget.org/packages/Dragon6.API/)
[![Nuget](https://img.shields.io/nuget/dt/Dragon6.API)](https://www.nuget.org/packages/Dragon6.API/)
![GitHub](https://img.shields.io/github/license/dragonfruitnetwork/Dragon6-API)
[![DragonFruit Discord](https://img.shields.io/discord/482528405292843018?label=Discord)](https://dragon6.dragonfruit.network/discord)

### Overview

Dragon6 is a free to use family of products specialising in Rainbow Six Siege Stats.

Looking to get started? Check out the Wiki!

## What's in the canister?

|Feature|Example|
|--|--|
|Access Token Request|`d6Client.GetUbiToken("username", "password");`|
|Casual Stats|`d6Client.GetClassicStats(accountInfo)`|
|Ranked Stats|`d6Client.GetSeasonStats(accountInfo)`|
|Operator Stats|`d6Client.GetClassicOperatorStats(accountInfo, operatorData);`|
|Weapon Stats|`d6Client.GetClassicWeaponStats(accountInfo);`|
|Account Search (by Name)|`d6Client.GetUser(Platforms.PC, LookupMethod.Name, "PaPa.Curry");`|
|Account Search (by User Id)|`d6Client.GetUser(Platforms.PC, LookupMethod.UserId, "21d95808-d692-4bf3-b825-f5ad3396d079");`|
|Account Search (by Platform Id)|`d6Client.GetUser(Platforms.PSN, LookupMethod.PlatformId, "7729747787525340203");`|

## Usages of Dragon6.API

- Dragon6 Web: [https://dragon6.dragonfruit.network](https://dragon6.dragonfruit.network)
- Dragon6 Discord: [Discord](https://dragon6.dragonfruit.network/discord)
- Dragon6 Mobile: [https://play.google.com/store/apps/details?id=com.dragon.six](https://play.google.com/store/apps/details?id=com.dragon.six)
- Dragon6 PC: [https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15](https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15)

## Contributing

Refer to [CONTRIBUTING.md](https://github.com/dragonfruitnetwork/Dragon6-API/blob/master/CONTRIBUTING.md) for more information
