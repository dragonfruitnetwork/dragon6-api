// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.API.Data.Requests
{
    public class OperatorDataRequest : ApiFileRequest
    {
        public override string Path => "https://github.com/dragonfruitnetwork/Dragon6-Assets/raw/master/public/data/operators.json";
        public override string Destination { get; }

        public OperatorDataRequest(string destination)
        {
            Destination = destination;
        }
    }
}
