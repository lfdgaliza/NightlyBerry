﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.Presentation.Api.Configuration
{
    public static class CorsConfiguration
    {
        private const string DevelopmentOrigins = "DevelopmentOrigins";
        private const string ProductionOrigins = "ProductionOrigins";

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DevelopmentOrigins,
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void UseCorsForDevelopment(this IApplicationBuilder app)
        {
            app.UseCors(DevelopmentOrigins);
        }

        public static void UseCorsForProduction(this IApplicationBuilder app)
        {
            app.UseCors(ProductionOrigins);
        }
    }
}
