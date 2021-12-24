// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Legacy.Requests;

namespace DragonFruit.Six.Api.Legacy.Utils
{
    /// <summary>
    /// Marks a class of static strings as a default collection of metrics for a <see cref="LegacyStatsRequest"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class DefaultStatsAttribute : Attribute
    {
        public DefaultStatsAttribute(LegacyStatTypes targetCategory)
        {
            TargetCategory = targetCategory;
        }

        public LegacyStatTypes TargetCategory { get; }
    }
}
