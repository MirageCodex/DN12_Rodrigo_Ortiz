using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Shared.Config;
using WebCors.Example.Client.Utils.Config;

namespace WebCors.Example.Client.Utils
{
    public interface IJwtTokenValidationSettings
    {
        String ValidIssuer { get; }

        String ValidAudience { get; }

        String SecretKey { get; }

        TokenValidationParameters CreateTokenValidationParameters();
    }

    public class JwtTokenValidationSettingsFactory : IJwtTokenValidationSettings
    {
        private readonly JwtTokenValidationSettings settings;

        public String ValidIssuer => settings.ValidIssuer;

        public String ValidAudience => settings.ValidAudience;

        public String SecretKey => settings.SecretKey;

        public JwtTokenValidationSettingsFactory(IOptions<JwtTokenValidationSettings> options)
        {
            settings = options.Value;
        }

        public TokenValidationParameters CreateTokenValidationParameters()
        {
            var result = new TokenValidationParameters
            {
                ValidIssuer = ValidIssuer,
                ValidAudience = ValidAudience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            return result;
        }
    }
}
