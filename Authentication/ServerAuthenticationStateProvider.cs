using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

using LatinoNETOnline.App.Client.Core.Models;

using Microsoft.AspNetCore.Components.Authorization;

namespace LatinoNETOnline.App.Client.Authentication
{
    public class ServerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public ServerAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var uri = new Uri(_httpClient.BaseAddress, "/api/Account/GetState");
            var data = await _httpClient.GetFromJsonAsync<AuthenticationStateData>(uri.AbsoluteUri);

            List<ClaimsIdentity> identities = new List<ClaimsIdentity>();

            if (data.IsAuthenticated)
            {
                var claims = data.Claims.Select(c => new Claim(c.Type, c.Value));
                identities.Add(new ClaimsIdentity(claims, PolicieRoles.AuthentixationType));
            }
            return new AuthenticationState(new ClaimsPrincipal(identities));
        }
    }
}
