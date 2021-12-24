// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Services.Status
{
    /// <summary>
    /// Describes the current state of the Rainbow Six infrastructure
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// Server is online
        /// </summary>
        Online,

        /// <summary>
        /// Server may experience some unexpected issues
        /// </summary>
        Interrupted,

        /// <summary>
        /// Server is offline or may have severe difficulty connecting
        /// </summary>
        Degraded,

        /// <summary>
        /// Scheduled to be deactivated for maintenance reasons
        /// </summary>
        Maintenance
    }
}
