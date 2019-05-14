using CrossCutting.Infra.Configuration;
using DistroGuide.Domain.Services.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.Presentation.Api.Configuration
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServicesLayer(this IApplicationBuilder app)
        {
            // TODO Configurations must be loaded by a generic code later on
            var serviceConfiguration = app.ApplicationServices.GetService<ILayerConfiguration>();
            serviceConfiguration.Configure();
        }
    }
}
