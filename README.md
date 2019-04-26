# Dragon6

[![Build Status](https://travis-ci.org/dragonfruitnetwork/Dragon6-API.svg?branch=master)](https://travis-ci.org/dragonfruitnetwork/Dragon6-API) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/44fea8a2da8a400aa25156b9c28423b4)](https://www.codacy.com/app/aspriddell/Dragon6-API?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=dragonfruitnetwork/Dragon6-API&amp;utm_campaign=Badge_Grade) [![NuGet](https://img.shields.io/nuget/v/Dragon6.API.svg?style=popout)](https://www.nuget.org/packages/Dragon6.API/)

Dragon6 is a free to use family of products specialising in Rainbow Six Siege Stats.

## Dragon6 API

  - Easy to use
  - Full Async support
  - General Stats
  - Operator Specific Stats
  - Ranked Season Support
  - PC ID Reverse Engineer Support
 
## Usage

```C#
using Dragon6.API;

Token.SetCredentials("Email","Password");
var token = await Token.GetToken(); //call this too many times and your account will be locked for 2 hours. Make sure you store this and set an expiry for one hour
AccountInfo Player = await AccountInfo.GetFromName("Curry.",References.Platform.PC,token);
Console.WriteLine(player.GUID);
PlayerStats stats = PlayerStats.GetStats(Player,token);
Console.WriteLine($"Kills: {stats.Casual_Kills} Deaths: {stats.Casual_Deaths}");
```

## In Production


- Dragon6 Web: [https://dragon6.me](https://dragon6.me)
- Dragon6 Mobile: [https://play.google.com/store/apps/details?id=com.dragon.six](https://play.google.com/store/apps/details?id=com.dragon.six)
- Dragon6 PC: [https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15](https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15)

## Contributing


Feel free to add an Issue if you discover one or if you're up to it, clone and make edits as you feel neccesarry. 

Contributors are awarded a verified profile on the Dragon6 Apps. If you have contributed and wish to claim yours, send an email to inbox@dragonfruit.network with your R6 Player Info and the twitch/YT links to add. You will also need to prove that you have actually contributed somehow.
