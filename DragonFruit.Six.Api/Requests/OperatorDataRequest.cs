// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Data;

namespace DragonFruit.Six.Api.Requests
{
    public class OperatorDataRequest : ApiFileRequest
    {
        public override string Path => "https://raw.githubusercontent.com/dragonfruitnetwork/Dragon6-Assets/master/public/data/operators.json";
        public override string Destination { get; }

        public OperatorDataRequest(string destination)
        {
            Destination = destination;
        }
    }
}
