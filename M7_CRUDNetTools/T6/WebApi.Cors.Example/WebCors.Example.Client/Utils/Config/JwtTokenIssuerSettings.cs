using Microsoft.Extensions.Options;

namespace WebCors.Example.Client.Utils.Config
{
    public class JwtTokenIssuerSettings
    {
        public String BaseAddress { get; set; }

        public String Login {  get; set; }

        public String RenewToken { get; set; }
    }

    public interface IJwtTokenIssuerSettings
    {
        String BaseAddress { get; }

        String Login { get; }

        String RenewToken { get; }
    }

    public class JwtTokenIssuerSettingsFactory : IJwtTokenIssuerSettings
    {
        private readonly IJwtTokenIssuerSettings settings;

        public JwtTokenIssuerSettingsFactory(IOptions<JwtTokenIssuerSettings> options)
        {
            settings = (IJwtTokenIssuerSettings)options.Value;
        }

        public String BaseAddress => settings.BaseAddress;

        public String Login => settings.Login;

        public String RenewToken => settings.RenewToken;

        
    }
}
