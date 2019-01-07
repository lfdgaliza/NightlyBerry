using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace NightlyBerry.Common.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, List<BindingMap> bindingMaps)
        {
            bindingMaps.ForEach(bindingMap =>
            {
                ProcessBidingMap(services, bindingMap);
            });

            return services;
        }

        private static void ProcessBidingMap(IServiceCollection services, BindingMap bindingMap)
        {
            var implAssembly = Assembly.Load(bindingMap.ImplAssemblyName);

            var interfaces = Assembly.Load(bindingMap.DefinitionAssemblyName)
                .GetTypes()
                .Where(type => bindingMap.ContractBaseType.IsAssignableFrom(type)
                                    && type.IsInterface
                                    && type != bindingMap.ContractBaseType);

            var implementations = implAssembly.GetTypes().Where(impl => interfaces.Any(itfc => itfc.IsAssignableFrom(impl) && impl.IsClass));

            BindServices(services, interfaces, implementations, bindingMap.Lifetime);
        }

        private static void BindServices(IServiceCollection services, IEnumerable<Type> interfaces, IEnumerable<Type> implementations, ServiceLifetime lifetime)
        {
            foreach (var serviceInterface in interfaces)
            {
                var mustBeOneImplementation = implementations
                                .Where(impl => serviceInterface.IsAssignableFrom(impl))
                                .ToList();

                if (mustBeOneImplementation.Count < 1)
                    throw new NotImplementedException($"Interface {serviceInterface.FullName} não implementada.");
                if (mustBeOneImplementation.Count > 1)
                {
                    var implementationsName = string.Join(", ", mustBeOneImplementation.Select(i => i.FullName));
                    throw new NotSupportedException($"Existe mais de uma implementação para a mesma interface: {implementationsName}");
                }

                var implementation = mustBeOneImplementation.Single();

                services.Add(new ServiceDescriptor(serviceInterface, implementation, lifetime));
            }
        }
    }
}
