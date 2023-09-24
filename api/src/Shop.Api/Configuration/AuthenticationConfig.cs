

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Api.Common;
using Shop.Application.Auth;
using System.Security.Claims;
using System.Text;

namespace Boilerplate.Api.Configurations;

public static class AuthenticationConfig
{
    public static IServiceCollection AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
    {
        #region auth

        var tokenConfig = configuration.GetRequiredSection("TokenConfiguration");
        services.Configure<TokenConfiguration>(tokenConfig);

        // configure jwt authentication
        var appSettings = tokenConfig.Get<TokenConfiguration>();
        var key = Encoding.ASCII.GetBytes(appSettings!.Secret);


        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddGoogle(config =>
            {
                config.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                config.AuthorizationEndpoint += "?prompt=consent"; 
                config.AccessType = "offline";
                config.SaveTokens = true;
                config.CallbackPath = "/signin-google";
                config.ClientId = "643158083356-3jde7ohikoat973j5bbkgq0p9c708jqu.apps.googleusercontent.com";
                config.ClientSecret = "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";
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
                /*
                x.SecurityTokenValidators.Clear();
                x.SecurityTokenValidators.Add(new GoogleTokenValidator());

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
                */
            }).
            AddCookie(o => o.LoginPath = new PathString("/login"));
        #endregion
        return services;
    }
}