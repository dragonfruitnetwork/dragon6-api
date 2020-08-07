// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Developer.Requests;

namespace DragonFruit.Six.API.Developer
{
    public class Dragon6DeveloperClient : ApiClient
    {
        private readonly uint _appId;
        private readonly string _appSecret;
        private readonly ApiClient _serviceClient;

        private TokenBase _sessionAuthorization;

        public Dragon6DeveloperClient(uint appId, string appSecret)
            : this(appId, appSecret, new ApiClient())
        {
        }

        public Dragon6DeveloperClient(uint appId, string appSecret, ApiClient serviceClient)
        {
            _appId = appId;
            _appSecret = appSecret;
            _serviceClient = serviceClient;
        }

        private void CheckAuthHeader()
        {
            if ((!_sessionAuthorization?.Expired).GetValueOrDefault(false))
                return;

            _sessionAuthorization = _serviceClient.Perform<Dragon6Token>(new DeveloperSessionRequest(_appId, _appSecret));
            Authorization = $"Bearer {_sessionAuthorization.Token}";
        }

        public T Perform<T>(DeveloperApiRequest requestData) where T : class
        {
            CheckAuthHeader();
            return base.Perform<T>(requestData);
        }
    }
}
