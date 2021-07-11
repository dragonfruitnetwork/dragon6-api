// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DragonFruit.Six.Api.Requests.Base;

namespace DragonFruit.Six.Api.Utils
{
    internal static class StatsStringsUtils
    {
        private const BindingFlags TargetProperties = BindingFlags.Static | BindingFlags.Public;

        public static IEnumerable<string> GetDefaultStats(this BasicStatsRequest request)
        {
            var type = request.GetType();
            return type.Assembly.GetTypes().Where(x =>
            {
                var attr = x.GetCustomAttribute<DefaultStats>();
                return attr is not null && attr.TargetRequest == type;
            }).SelectMany(x => x.GetProperties(TargetProperties).Select(y => y.GetValue(null)).Cast<string>());
        }
    }

    /// <summary>
    /// Marks a class of static strings as a default collection of metrics for a <see cref="BasicStatsRequest"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class DefaultStats : Attribute
    {
        public DefaultStats(Type targetRequest)
        {
            TargetRequest = targetRequest;
        }

        public Type TargetRequest { get; }
    }
}
