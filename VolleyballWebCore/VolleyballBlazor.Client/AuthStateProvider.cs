using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using System.Security.Principal;
using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;

namespace VolleyballBlazor.Client
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var tokenString = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(tokenString))
                return _anonymous;

            try
            {
                var token = new JwtSecurityToken(tokenString);

                if (token.ValidTo < DateTime.UtcNow)
                {
                    await _localStorage.RemoveItemAsync("authToken");
                    return _anonymous;
                }

                IIdentity identity = new ClaimsIdentity(token.Claims, "jwtAuthType");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenString);
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                await _localStorage.RemoveItemAsync("authToken");
                return _anonymous;
            }
        }

        public void NotifyUserAuthentication(string tokenString)
        {
            var token = new JwtSecurityToken(tokenString);
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }

}