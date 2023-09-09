using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NCwDDD.Infra.Data.Context;

namespace NCwDDD.Services.API.Configurations
{
	public static class DatabaseConfig
	{
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddDbContext<NCwDDDContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<NCwDDDContext>(options =>
            {
                options.UseSqlServer(connectionString); // Use o provedor de banco de dados apropriado aqui
            });
        }
    }
}

