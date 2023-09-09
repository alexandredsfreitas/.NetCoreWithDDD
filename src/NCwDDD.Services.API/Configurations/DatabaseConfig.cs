using System;
using Microsoft.EntityFrameworkCore;
using NCwDDD.Infra.Data.Context;

namespace NCwDDD.Services.API.Configurations
{
	public static class DatabaseConfig
	{
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<NCwDDDContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EventStoreSqlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

