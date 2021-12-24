# Dragon6 API

![NuGet Publishing](https://github.com/dragonfruitnetwork/dragon6-api/workflows/Publish/badge.svg)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/b9aeacb9dd754f4a8bc50fb3498958ab)](https://www.codacy.com/gh/dragonfruitnetwork/dragon6-api)
[![NuGet](https://img.shields.io/nuget/v/DragonFruit.Six.Api)](https://www.nuget.org/packages/DragonFruit.Six.Api/)
[![Nuget](https://img.shields.io/nuget/dt/DragonFruit.Six.Api)](https://www.nuget.org/packages/DragonFruit.Six.Api/)
[![DragonFruit Discord](https://img.shields.io/discord/482528405292843018?label=Discord)](https://dragon6.dragonfruit.network/discord)

### Overview

The Dragon6 API is the backbone of the website and apps with the same name, providing an easy-to-use platform for
retrieving publicly-available data about other Ubisoft Accounts and their Rainbow Six | Siege Stats.

This API supports:

- Ubisoft Account Authentication
- Ubisoft Account Searches (by name and ubisoft id)
- Ubisoft Account Activity Tracking (for R6)
- Legacy Stats (lifetime account stats)
- Seasonal Stats (ranked and unranked/casual stats per-season)
- Modern Stats (the stats currently found on the official Ubisoft tracker) (coming soon)
- Ubisoft Toolkits (IP geolocation, Rainbow Six Server Status)

## Usage

1. Download the package from by clicking the NuGet badge at the top of this document, and follow the instructions there
   for your environment
2. Create a class inside your project, naming it what you want to call your client type (for example `StatsClient`)
    ```c#
   using System;
   using System.IO;
   using System.Threading.Tasks;
   using DragonFruit.Data;
   using DragonFruit.Data.Serializers.Newtonsoft;
   using DragonFruit.Six.Api;
   using DragonFruit.Six.Api.Authentication;
   
   public class StatsClient : Dragon6Client
    {
        // change this to whatever you want
        private readonly string _tokenFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DragonFruit Network", "ubi.token");
        
        static StatsClient()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_tokenFile));
        }

        /// <summary>
        /// Tells the Dragon6 Client how to get a token in the case of a restart or expiration
        /// </summary>
        protected override IUbisoftToken GetToken()
        {
            if (File.Exists(_tokenFile))
            {
                // if we have a file with some potentially valid keys, try that first
                var token = FileServices.ReadFile<UbisoftToken>(_tokenFile);

                if (!token.Expired)
                    return token;
            }

            // store logins somewhere that is NOT in the code
            var username = "username";
            var password = "password";
            var newToken = this.GetUbiToken(username, password);

            // write new token to disk (non-blocking)
            _ = Task.Run(() => FileServices.WriteFile(_tokenFile, newToken));
            
            // return to keep going
            return newToken;
        }
    }
    ```
3. Create an instance of the class you just defined in either a `static` location or as a `Singleton` (if you're using a
   dependency container)
4. Add some using statements where you want to consume the class:

```c#
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Seasonal;
using DragonFruit.Six.Api.Accounts;
using DragonFruit.Six.Api.Modern;
```

5. Check out the extension methods available to you using IntelliSense (type the client name followed by the dot and
   browse the extensions):

```c#
var myAccount = await statsClient.GetAccountAsync("PaPa.Curry", Platform.PC, IdentifierType.Name);
```

## Official Apps

- Dragon6 Web: [https://dragon6.dragonfruit.network](https://dragon6.dragonfruit.network)
- Dragon6 Discord: [Discord](https://dragon6.dragonfruit.network/discord)
- Dragon6
  Mobile: [https://play.google.com/store/apps/details?id=com.dragon.six](https://play.google.com/store/apps/details?id=com.dragon.six)
- Dragon6
  PC: [https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15](https://www.microsoft.com/en-us/p/dragon6/9n88cqpkgs15)

## Contributing

Refer to [CONTRIBUTING.md](https://github.com/dragonfruitnetwork/Dragon6-API/blob/master/CONTRIBUTING.md) for more
information
