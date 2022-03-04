using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DemoABC.Services
{
    public static class JwtService
    {
        private const string _authenticationScheme = "JwtBearer";

        public static void AddJwtRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = _authenticationScheme;
                options.DefaultChallengeScheme = _authenticationScheme;
            }).AddJwtBearer(_authenticationScheme, options =>
            {
                options.Audience = configuration.GetSection("Authentication:JwtBearer:Audience").Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("Authentication:JwtBearer:Issuer").Value,
                    ValidAudience = configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Authentication:JwtBearer:SecurityKey").Value)),
                };
            });
        }
    }
}
