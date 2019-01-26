using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using NightlyBerry.Common.DependencyInjection;
using NightlyBerry.Common.DependencyInjection.Marking;

namespace NightlyBerry.LinuxTree.Presentation.API
{
    public static class DomainConfiguration
    {
        public static void ConfigureDomain(IServiceCollection services)
        {
            services.AddDomain(new List<BindingMap>{
                new BindingMap(typeof(IService), "NightlyBerry.LinuxTree.Domain.Core", "NightlyBerry.LinuxTree.Impl.Services", ServiceLifetime.Scoped),
                new BindingMap(typeof(IRepository), "NightlyBerry.LinuxTree.Domain.Core", "NightlyBerry.LinuxTree.Impl.Repositories", ServiceLifetime.Scoped)
            });
        }
    }
}
