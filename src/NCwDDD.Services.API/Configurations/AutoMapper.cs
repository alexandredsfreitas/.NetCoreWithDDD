using System;
using NCwDDD.Application.AutoMapper;

namespace NCwDDD.Services.API.Configurations
{
	public static class AutoMapper
	{
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}

