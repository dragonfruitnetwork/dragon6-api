// DragonFruit.Common Copyright 2020 DragonFruit Network
// Licensed under the MIT License. Please refer to the LICENSE file at the root of this project for details

using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DragonFruit.Common.Data.Serializers
{
    public interface ISerializer
    {
        StringContent Serialize<T>(T input) where T : ApiRequest;

        T Deserialize<T>(Task<Stream> input) where T : class;
    }
}