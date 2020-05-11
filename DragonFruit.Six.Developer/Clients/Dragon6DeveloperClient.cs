// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Six.Developer.Objects;
using DragonFruit.Six.Developer.Requests;

namespace DragonFruit.Six.Developer.Clients
{
    public class Dragon6DeveloperClient : ApiClient
    {
        private DeveloperAuthorization _sessionAuthorization;
        private readonly ApiClient _serviceClient;
        private readonly string _devKey;

        public Dragon6DeveloperClient(string devKey)
            : this(new ApiClient(), devKey)
        {
        }

        public Dragon6DeveloperClient(ApiClient serviceClient, string devKey)
        {
            _serviceClient = serviceClient;
            _devKey = devKey;
        }

        private DeveloperAuthorization SessionAuthorization
        {
            get
            {
                if (_sessionAuthorization != null || (_sessionAuthorization?.Expired).GetValueOrDefault(true))
                {
                    return _sessionAuthorization = _serviceClient.Perform<DeveloperAuthorization>(new DeveloperSessionRequest(_devKey));
                }
                else
                {
                    return _sessionAuthorization;
                }
            }
        }

        public override T Perform<T>(ApiRequest requestData)
        {
            if (requestData.RequireAuth)
            {
                //set (or update) the auth header
                Authorization = $"Bearer {SessionAuthorization.Token}";
            }

            return base.Perform<T>(requestData);
        }
    }
}
