using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Auth;
using System.Text;

namespace Boilerplate.Api.Configurations;

public static class AuthenticationConfig
{
    public static IServiceCollection AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
    {
        #region auth

        var tokenConfig = configuration.GetRequiredSection("TokenConfiguration");
        services.Configure<TokenConfiguration>(tokenConfig);
        var appSettings = tokenConfig.Get<TokenConfiguration>();
        var key = Encoding.ASCII.GetBytes(appSettings!.Secret);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            
        })
            .AddJwtBearer(x =>
            {

                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Issuer,
                    ValidAudience = appSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

            }).
            AddCookie();
        #endregion
        return services;
    }
}