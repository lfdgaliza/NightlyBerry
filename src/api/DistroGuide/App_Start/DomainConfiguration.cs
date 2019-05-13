using DistroGuide.App_Domain.Repository;
using DistroGuide.App_Domain.Services;
using DistroGuide.App_Impl.Repository;
using DistroGuide.App_Impl.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.App_Start
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
            services.AddScoped<ICacheService, InMemoryCacheService>();
            services.AddScoped<IDistroService, DistroService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IQueryDistroRepository, QueryDistroRepository>();
        }
    }
}