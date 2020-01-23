
# Dragon6 (API)

[![Build Status](https://travis-ci.org/dragonfruitnetwork/Dragon6-API.svg?branch=master)](https://travis-ci.org/dragonfruitnetwork/Dragon6-API) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/44fea8a2da8a400aa25156b9c28423b4)](https://www.codacy.com/app/aspriddell/Dragon6-API?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=dragonfruitnetwork/Dragon6-API&amp;utm_campaign=Badge_Grade) [![NuGet](https://img.shields.io/nuget/v/Dragon6.API.svg?style=popout)](https://www.nuget.org/packages/Dragon6.API/)

Dragon6 is a free to use family of products specialising in Rainbow Six Siege Stats.

## What's in the canister? (view the wiki for more info)

|Feature|Example|
|--|--|
|Casual Stats|`await GeneralStats.GetStats(accountInfo, token)`|
|Ranked Stats|`await Season.GetSeason(accountInfo, "EMEA", token)`|
|Operator Stats|`await Operator.GetOperatorStats(accountInfo, token, operatorDict);`|
|Weapon Stats|`await WeaponStats.GetWeaponStats(accountInfo, token);`|
|Token Downloader|`await await GetToken();`|
|Account Search (by Name)|`await AccountInfo.GetUser(Platforms.PC, LookupMethod.Name, "Curry.", token);`|
|Account Search (by User Id)|`await AccountInfo.GetUser(Platforms.PC, LookupMethod.UserId, "21d95808-d692-4bf3-b825-f5ad3396d079", token);`|
|Account Search (by Platform Id)|`await AccountInfo.GetUser(Platforms.PSN, LookupMethod.PlatformId, "7729747787525340203", token);`|


## In Production


- Dragon6 Web: [https://dragon6.dragonfruit.network](https://dragon6.dragonfruit.network)
- Dragon6 Mobile: [https://play.google.com/store/apps/details?id=com.dragon.six](https://play.google.com/store/apps/details?id=com.dragon.six)
- Dragon6 PC: [https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15](https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15)

## Contributing


Feel free to add an issue if you discover one or if you're up to it, clone and make edits as you feel neccesarry. 

Contributors can claim a verified profile on the Dragon6 Apps. This gives you access to beta features, including custom backgrounds on your profile. If you have contributed and wish to claim yours, send an email to inbox@dragonfruit.network with your R6 Player Info.
