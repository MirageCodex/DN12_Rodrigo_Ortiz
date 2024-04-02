using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using WebApi.Shared.Config;
using WebCors.Example.Client.Utils.Config;

namespace WebCors.Example.Client.Utils
{
    public interface IClaimPrincipalManager
    {
        string UserName { get; }

        bool IsAuthenticated { get; }

        ClaimsPrincipal User { get; }

        Task<bool> LoginAsync (string email, string password);

        Task LogoutAsync();

        Task RenewTokenAsync(string jwtToken);

        Task<bool> HasPolicy(string policyName);
    }

    public class ClaimPricipalManager : IClaimPrincipalManager
    {
        private readonly HttpContext httpContext;
        private readonly IAuthorizationService authorizationService;
        private readonly IJwtTokenValidationSettings jwtTokenValidationSettings;
        private readonly IJwtTokenIssuerSettings jwtTokenIssuerSettings;
        private readonly IAuthenticationSettings authenticationSettings;

        public bool IsAuthenticated
        {
            get
            {
                return User.Identities.Any(u => u.IsAuthenticated);
            }
        }

        public string UserName
        {
            get
            {
                return User.Identities.FirstOrDefault(u => u.IsAuthenticated)?.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
            }
        }

        public ClaimsPrincipal User => httpContext?.User;

        public ClaimPricipalManager(
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService,
            IJwtTokenValidationSettings jwtTokenValidationSettings,
            IJwtTokenIssuerSettings jwtTokenIssuerSettings,
            IAuthenticationSettings authenticationSettings)
        {
            httpContext = httpContextAccessor.HttpContext;
            this.authorizationService = authorizationService;
            this.jwtTokenValidationSettings = (IJwtTokenValidationSettings?)jwtTokenValidationSettings;
            this.jwtTokenIssuerSettings = jwtTokenIssuerSettings;
            this.authenticationSettings = authenticationSettings;
        }

        public async Task LogoutAsync()
        {
            await httpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
        }

        private HttpClient CreateClient()
        {
            var url = new Uri(jwtTokenIssuerSettings.BaseAddress);

            var result = new HttpClient() { BaseAddress = url };

            result.DefaultRequestHeaders.Accept.Clear();
            result.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return result;
        }

        private async Task<string> FetchJwtToken(string email, string password)
        {
            var apiUrl = jwtTokenIssuerSettings.Login;

            using (var client = CreateClient())
            {
                var resource = new
                {
                    UserName = email,
                    Password = password
                };
                using (var content = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(apiUrl, content))
                    {
                        var result = response.StatusCode == HttpStatusCode.OK ? await response.Content.ReadAsStringAsync() : null;
                        return result;
                    }
                }
            }
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var jwtToken = await FetchJwtToken(email, password);
            var result = await Login(jwtToken);

            if (result)
            {
                httpContext.Response.Cookies.Append("authname", jwtToken);
            }
            return result;
        }

        private async Task<bool> Login (string jwtToken)
        {
            try
            {
                if (jwtToken.IsNullOrEmpty())
                    return false;

                await LogoutAsync();

                var tokenHandler = new JwtSecurityTokenHandler();

                var settings = jwtTokenValidationSettings.CreateTokenValidationParameters();

                var principal = tokenHandler.ValidateToken(jwtToken, settings, out var valida);

                var identity = principal.Identity as ClaimsIdentity;

                var securityToken = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;

                var extraClaims = securityToken.Claims.Where(c => !identity.Claims.Any(x => x.Type == c.Type)).ToList();

                extraClaims.Add(new Claim("jwt", jwtToken));

                identity.AddClaims(extraClaims);

                var authenticationProperties = new AuthenticationProperties()
                {
                    IssuedUtc = identity.Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat)?.Value.ToInt64().ToUnixEpochDate(),
                    ExpiresUtc = identity.Claims.First(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value.ToInt64().ToUnixEpochDate(),
                    IsPersistent = true
                };

                await httpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, principal, authenticationProperties);

                return identity.IsAuthenticated;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task RenewTokenAsync (string jwtToken)
        {

        }

        public async Task<bool> HasPolicy(string policyName)
        {
            var result = await authorizationService.AuthorizeAsync(User, policyName);
            return result.Succeeded;
        }
    }
}
