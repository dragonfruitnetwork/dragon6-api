﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Net.Http;
using System.Text;
using DragonFruit.Common.Data;
using DragonFruit.Common.Data.Extensions;

namespace DragonFruit.Six.Api.Requests
{
    internal sealed class TokenRequest : UbiApiRequest
    {
        public override string Path => Endpoints.IdServer + "/sessions";

        protected override Methods Method => Methods.Post;
        protected override BodyType BodyType => BodyType.Custom;
        protected override bool RequireAuth => true;

        // tokens need an empty request body in UTF8, with app/json type...
        protected override HttpContent BodyContent => new StringContent(string.Empty, Encoding.UTF8, "application/json");

        /// <summary>
        /// Initialises a new <see cref="TokenRequest"/> with a pre-encoded b64 login
        /// </summary>
        public TokenRequest(string b64Login)
        {
            this.WithAuthHeader($"Basic {b64Login}");
        }

        /// <summary>
        /// Initialises a new <see cref="TokenRequest"/> using the provided username/password combo
        /// </summary>
        public TokenRequest(string username, string password)
            : this(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")))
        {
        }
    }
}
