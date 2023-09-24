
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Shop.Domain.Entities.Common;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Boilerplate.Api.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Shop.Api",
                    Version = "v1",
                    Description = "Shop Api demo",
                    Contact = new OpenApiContact
                    {
                        Name = "Games Global",
                        Url = new Uri("https://github.com/jamshidmassomy")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/jamshidmassomy/LICENSE")
                    }
                });
            c.DescribeAllParametersInCamelCase();
            c.OrderActionsBy(x => x.RelativePath);

            var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
            if (File.Exists(xmlPath))
            {
                c.IncludeXmlComments(xmlPath);
            }

            //c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            // c.OperationFilter<SecurityRequirementsOperationFilter>();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Bearer Authentication with JWT Token",
                Type = SecuritySchemeType.Http
            });



            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List < string > ()
                }
        });

            // Maps all structured ids to the guid type to show correctly on swagger
            var allGuids = typeof(IGuid).Assembly.GetTypes().Where(type => typeof(IGuid).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();
            foreach (var guid in allGuids)
            {
                c.MapType(guid, () => new OpenApiSchema { Type = "string", Format = "uuid" });
            }
           

        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
    {
        // Configure the HTTP request pipeline.
        /*if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        */
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.List);
                c.DisplayRequestDuration();
            });
        app.UseSwaggerUI();
        return app;
    }
}