// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;

namespace DragonFruit.Six.Api.Modern.Utils
{
    /// <summary>
    /// Marks a class as being able to be deserialized by path reference
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class JsonPathSerializableAttribute : Attribute
    {
    }
}
