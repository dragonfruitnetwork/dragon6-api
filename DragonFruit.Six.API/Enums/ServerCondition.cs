// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Enums
{
    public enum ServerCondition
    {
        /// <summary>
        ///     Server is online
        /// </summary>
        Online,

        /// <summary>
        ///     Server may experience some unexpected issues
        /// </summary>
        Interrupted,

        /// <summary>
        ///     Server is offline or may have severe difficulty connecting
        /// </summary>
        Degraded,

        /// <summary>
        ///     Scheduled to be deactivated for maintenance reasons
        /// </summary>
        Maintenance
    }
}
