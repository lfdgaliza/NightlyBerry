using System;
using System.Collections.Generic;
using DistroGuide.Infra.DependencyInjection;
using DistroGuide.Infra.Repository;
using DistroGuide.Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DistroGuide.Presentation.Api.App_Start
{
    public static class DomainConfiguration
    {
        public static void ConfigureDomain(IServiceCollection services)
        {
            services.AddDomain(new List<BindingMap>{
                new BindingMap(typeof(IService), "DistroGuide.Domain.Service", "DistroGuide.Service.Impl", ServiceLifetime.Scoped),
                new BindingMap(typeof(IRepository), "DistroGuide.Domain.Repository", "DistroGuide.Repository.Impl", ServiceLifetime.Scoped)
            });
        }
    }
}
