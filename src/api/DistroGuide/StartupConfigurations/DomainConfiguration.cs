using DistroGuide.Repository;
using DistroGuide.Repository.Impl;
using DistroGuide.Services;
using DistroGuide.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.StartupConfigurations
{
    public static class DomainConfiguration
    {
        public static void AddDomain(this IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ISearchDistroService, SearchDistroService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IQueryDistroRepository, QueryDistroRepository>();
        }
    }
}