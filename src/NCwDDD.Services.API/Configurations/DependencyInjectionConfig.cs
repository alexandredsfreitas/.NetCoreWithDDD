using System;
using NCwDDD.Infra.CrossCutting.IOC;

namespace NCwDDD.Services.API.Configurations
{
	public static class DependencyInjectionConfig
	{
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}

