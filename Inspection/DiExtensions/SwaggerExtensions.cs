using Microsoft.OpenApi.Models;

namespace Inspection.API.Main.DiExtensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerServicesExtensions(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inspection API",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization Token. Token Form Is \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
            return services;

        }

        public static IApplicationBuilder AddSwaggerApplicationExtensions(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = "swagger";
                });
            }

            return app;

        }

        //public static IApplicationBuilder AddSwaggerURLExtensions(this WebApplication app)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        if (context.Request.Path == "/index.html" || context.Request.Path == "/")
        //        {
        //            context.Response.Redirect("/swagger/index.html");
        //            return;
        //        }
        //        await next();
        //    });
        //    return app;
        //}

    }
}
