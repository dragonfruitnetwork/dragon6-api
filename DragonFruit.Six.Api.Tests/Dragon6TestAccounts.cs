// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Accounts.Enums;

namespace DragonFruit.Six.Api.Tests
{
    public class Dragon6TestAccounts : IEnumerable<UbisoftAccount>
    {
        public UbisoftAccount this[string id] => _accounts.FirstOrDefault(x => x.UbisoftId == id);

        public IEnumerator<UbisoftAccount> GetEnumerator() => _accounts.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private readonly IReadOnlyList<UbisoftAccount> _accounts = new[]
        {
            new UbisoftAccount
            {
                Username = "PaPa.Curry",
                Platform = Platform.PC,
                ProfileId = "14c01250-ef26-4a32-92ba-e04aa557d619",
                PlatformId = "14c01250-ef26-4a32-92ba-e04aa557d619",
                UbisoftId = "14c01250-ef26-4a32-92ba-e04aa557d619"
            },
            new UbisoftAccount
            {
                Username = "ITFC_max",
                Platform = Platform.PC,
                ProfileId = "45c0cccb-a1a8-4433-b3d8-52aaa40d16d2",
                UbisoftId = "45c0cccb-a1a8-4433-b3d8-52aaa40d16d2",
                PlatformId = "45c0cccb-a1a8-4433-b3d8-52aaa40d16d2"
            },
            new UbisoftAccount
            {
                Username = "P9-",
                Platform = Platform.PC,
                ProfileId = "d0cc86e3-f3b8-493c-bb36-c9416183477a",
                UbisoftId = "d0cc86e3-f3b8-493c-bb36-c9416183477a",
                PlatformId = "d0cc86e3-f3b8-493c-bb36-c9416183477a"
            },
            new UbisoftAccount
            {
                Username = "TheOnePistolGuy-",
                Platform = Platform.PSN,
                ProfileId = "18255d23-8073-440e-9011-1b9b8faa15fe",
                UbisoftId = "5e992dc8-7d93-4f28-9690-08b4d6788cc8",
                PlatformId = "1678314272891637227"
            },
            new UbisoftAccount
            {
                Username = "TheKoreanKoala",
                Platform = Platform.PSN,
                ProfileId = "be982999-2adb-4fbe-b2a5-3cbc4b7a79bf",
                UbisoftId = "a5e7c9c4-a225-4d8e-810f-0c529d829a34",
                PlatformId = "7729747787525340203"
            },
            new UbisoftAccount
            {
                Username = "Charr._",
                Platform = Platform.PC,
                ProfileId = "a5e7c9c4-a225-4d8e-810f-0c529d829a34",
                UbisoftId = "a5e7c9c4-a225-4d8e-810f-0c529d829a34",
                PlatformId = "a5e7c9c4-a225-4d8e-810f-0c529d829a34"
            },
            new UbisoftAccount
            {
                Username = "Jancer",
                Platform = Platform.XB1,
                ProfileId = "6c5b5c77-a7db-4c5f-8802-de797ce529a8",
                UbisoftId = "b6c8e00a-00f9-44fb-b83e-eb9135933b91",
                PlatformId = "2535444832986122"
            },
            new UbisoftAccount
            {
                Username = "MeatyMarley",
                Platform = Platform.PC,
                ProfileId = "603fc6ba-db16-4aba-81b2-e9f9601d7d24",
                UbisoftId = "603fc6ba-db16-4aba-81b2-e9f9601d7d24",
                PlatformId = "603FC6BA-DB16-4ABA-81B2-E9F9601D7D24"
            },
            new UbisoftAccount
            {
                Username = "Revilo_333",
                Platform = Platform.PC,
                ProfileId = "e76672be-1269-4afd-a1f5-d2ec6f5a2c7f",
                UbisoftId = "e76672be-1269-4afd-a1f5-d2ec6f5a2c7f",
                PlatformId = "e76672be-1269-4afd-a1f5-d2ec6f5a2c7f"
            },
            new UbisoftAccount
            {
                Username = string.Empty,
                Platform = Platform.PC,
                ProfileId = "9b1918ce-a45b-4140-b1d8-7e00965fbf92",
                UbisoftId = "9b1918ce-a45b-4140-b1d8-7e00965fbf92",
                PlatformId = "9b1918ce-a45b-4140-b1d8-7e00965fbf92"
            },
            new UbisoftAccount
            {
                Username = "Unique.Enough",
                Platform = Platform.PC,
                ProfileId = "3dc3cd27-8eb7-4fe0-8774-1006a8f509a2",
                UbisoftId = "3dc3cd27-8eb7-4fe0-8774-1006a8f509a2",
                PlatformId = "3DC3CD27-8EB7-4FE0-8774-1006A8F509A2"
            }
        };
    }
}
