// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System;

namespace DragonFruit.Common.Data.Parameters
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class QueryParameter : Attribute, IProperty
    {
        public QueryParameter(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}