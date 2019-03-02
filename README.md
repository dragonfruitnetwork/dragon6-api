# Dragon6
___
Dragon6 is a free to use family of products specialising in Rainbow Six Siege Stats.
> To build this, make sure that there a copy of `nuget.exe` is present in `C:\Windows`
## Dragon6 API
***
  - Easy to use
  - Full Async support
  - General Stats
  - Operator Specific Stats
  - Ranked Season Support
  - PC ID Reverse Engineer Support
 
## Usage
***
```C#
using Dragon6.API;

Token.SetCredentials("Email","Password");
var token = await Token.GetToken();
AccountInfo Player = await AccountInfo.GetFromName("Curry.",References.Platform.PC,token);
Console.WriteLine(player.GUID);
PlayerStats stats = PlayerStats.GetStats(Player,token);
Console.WriteLine($"Kills: {stats.Casual_Kills} Deaths: {stats.Casual_Deaths}");
```

## Dragon6 PC
***
If you want to see the API in action, download the Dragon6 PC app from the Microsoft Store

<a target="_blank" href='//www.microsoft.com/store/apps/9n88cqpkgs15?ocid=badge'><img src='https://assets.windowsphone.com/13484911-a6ab-4170-8b7e-795c1e8b4165/English_get_L_InvariantCulture_Default.png' alt='English badge' style='width: 127px; height: 52px;'/></a>