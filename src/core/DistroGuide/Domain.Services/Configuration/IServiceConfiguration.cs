using System.Linq;
using AutoMapper;
using CrossCutting.Infra.Configuration;

namespace DistroGuide.Domain.Services.Configuration
{
    public class ServiceConfiguration : ILayerConfiguration
    {
        public void Configure()
        {
            ConfigureMaps();
        }

        private void ConfigureMaps()
        {
            var assembly = this.GetType().Assembly;

            var profilesInAssembly = assembly.GetTypes()
                .Where(t =>
                    t.BaseType != null
                    && t.BaseType == typeof(Profile)
                    && t.IsClass)
                .ToList();

            Mapper.Initialize(cfg => profilesInAssembly.ForEach(cfg.AddProfile));
        }
    }
}
