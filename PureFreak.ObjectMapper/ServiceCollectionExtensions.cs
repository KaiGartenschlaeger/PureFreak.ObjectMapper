using Microsoft.Extensions.DependencyInjection.Extensions;
using PureFreak.ObjectMapper;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddObjectMapper(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAdd(ServiceDescriptor.Singleton<IObjectConverter, ObjectConverter>());

            return services;
        }
    }
}
