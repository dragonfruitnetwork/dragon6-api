// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Data;
using DragonFruit.Data.Parameters;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Accounts.Requests
{
    public class UbisoftAccountActivityRequest : UbiApiRequest
    {
        private IEnumerable<string> _appIds;

        public override string Path => $"{Endpoints.IdServer}/applications";

        /// <summary>
        /// Creates a <see cref="UbisoftAccountActivityRequest"/> for a single <see cref="UbisoftAccount"/>
        /// </summary>
        public UbisoftAccountActivityRequest(UbisoftAccount profile)
            : this(profile.Yield())
        {
        }

        /// <summary>
        /// Creates a <see cref="UbisoftAccountActivityRequest"/> for multiple <see cref="UbisoftAccount"/>s
        /// </summary>
        public UbisoftAccountActivityRequest(IEnumerable<UbisoftAccount> profiles)
        {
            Accounts = profiles;
        }

        /// <summary>
        /// The app ids to retrieve activity for. Defaults to the Rainbow Six Siege app ids
        /// </summary>
        [QueryParameter("applicationIds", CollectionConversionMode.Concatenated)]
        public IEnumerable<string> AppIds
        {
            get => _appIds ?? UbisoftIdentifiers.GameIds.Keys;
            set => _appIds = value;
        }

        /// <summary>
        /// A <see cref="IEnumerable{T}"/> of profile ids to use.
        /// </summary>
        /// <remarks>
        /// If set, this will ignore the <see cref="Accounts"/> property
        /// </remarks>
        public IEnumerable<string> Profiles { get; set; }

        /// <summary>
        /// The accounts to check against the activity logs for <see cref="AppIds"/>
        /// </summary>
        public IEnumerable<UbisoftAccount> Accounts { get; set; }

        [QueryParameter("profileIds", CollectionConversionMode.Concatenated)]
        private IEnumerable<string> ProfileIdString => Profiles ?? Accounts.Select(x => x.ProfileId);
    }
}
