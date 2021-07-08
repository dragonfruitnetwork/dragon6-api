// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Requests
{
    public class OperatorStatsRequest : BasicStatsRequest
    {
        public OperatorStatsRequest(AccountInfo account, IEnumerable<OperatorStats> operators)
            : this(account.Yield(), operators)
        {
        }

        public OperatorStatsRequest(IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators)
            : base(accounts)
        {
            OperatorActions = operators.Select(x => x.OperatorActionId).Where(x => !string.IsNullOrWhiteSpace(x));
        }

        private IEnumerable<string> OperatorActions { get; set; }

        public override IEnumerable<string> Stats
        {
            get => (_stats ?? this.GetDefaultStats()).Concat(OperatorActions);
            set => _stats = value;
        }
    }

    public sealed class OperatorTrainingStatsRequest : OperatorStatsRequest
    {
        public OperatorTrainingStatsRequest(AccountInfo account, IEnumerable<OperatorStats> operators)
            : this(account.Yield(), operators)
        {
        }

        public OperatorTrainingStatsRequest(IEnumerable<AccountInfo> accounts, IEnumerable<OperatorStats> operators)
            : base(accounts, operators)
        {
        }
    }
}
