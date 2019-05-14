﻿using CrossCutting.Infra.Configuration;
using DistroGuide.Domain.Repository;
using DistroGuide.Domain.Repository.Impl;
using DistroGuide.Domain.Services;
using DistroGuide.Domain.Services.Configuration;
using DistroGuide.Domain.Services.Impl;
using DistroGuide.Domain.Services.Impl.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.Presentation.Api.Configuration
{
    public static class DomainConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, InMemoryCacheService>();
            services.AddScoped<IDistroService, DistroService>();

            // TODO This is temporary (I hope so!)
            services.AddSingleton<ILayerConfiguration, ServiceConfiguration>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQueryDistroRepository, QueryDistroRepository>();
        }

        public static void AddSingletonRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<ISingletonRepository>(r => new SingletonRepository(connectionString));
        }
    }
}