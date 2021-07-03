// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.ComponentModel;

namespace DragonFruit.Six.Api.Enums
{
    /// <summary>
    /// The categories a weapon can fall under
    /// </summary>
    public enum WeaponType
    {
        [Description("Assault Rifle")]
        AssaultRifle = 1,

        [Description("Submachine Gun")]
        SubmachineGun = 2,

        [Description("Light Machine Gun")]
        LightMachineGun = 3,

        [Description("Marksman Rifle")]
        MarksmanRifle = 4,

        [Description("Pistol")]
        Pistol = 5,

        [Description("Shotgun")]
        Shotgun = 6,

        [Description("Machine Pistol")]
        MachinePistol = 7,

        [Description("Shield")]
        Shield = 8,

        [Description("Launcher")]
        Launcher = 9,
    }
}
