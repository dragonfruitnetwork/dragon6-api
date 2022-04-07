// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Utils
{
    /// <summary>
    /// Indicates the attributed property has a custom JPath that should be deserialized from
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class JsonPathAttribute : Attribute
    {
        public JsonPathAttribute(string path)
        {
            Path = path;
        }

        public string Path { get; }
    }
}
