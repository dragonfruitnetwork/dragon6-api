// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;
using DragonFruit.Six.API.Data.Tokens;
using DragonFruit.Six.API.Developer.Requests;

namespace DragonFruit.Six.API.Developer
{
    public class Dragon6DeveloperClient : ApiClient
    {
        private TokenBase _sessionAuthorization;
        private readonly uint _appId;
        private readonly string _appSecret;
        private readonly ApiClient _serviceClient;

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

        private TokenBase SessionAuthorization
        {
            get
            {
                if ((_sessionAuthorization?.Expired).GetValueOrDefault(true))
                {
                    //dragon6Token is the same for ubisoft logins and dragon6 logins - they both share TokenBase
                    return _sessionAuthorization = _serviceClient.Perform<Dragon6Token>(new DeveloperSessionRequest(_appId, _appSecret));
                }

                return _sessionAuthorization;
            }
        }

        public T Perform<T>(DeveloperApiRequest requestData) where T : class
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
