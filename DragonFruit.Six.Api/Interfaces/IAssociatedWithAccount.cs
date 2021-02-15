// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Six.Api.Entities;

namespace DragonFruit.Six.Api.Interfaces
{
    public interface IAssociatedWithAccount
    {
        public bool IsAssociatedWithAccount(AccountInfo account);
    }
}
