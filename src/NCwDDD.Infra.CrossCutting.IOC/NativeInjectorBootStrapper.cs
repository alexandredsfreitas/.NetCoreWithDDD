using NCwDDD.Application.Interfaces;
using NCwDDD.Application.Services;
using NCwDDD.Domain.Commands;
using NCwDDD.Domain.Core.Events;
using NCwDDD.Domain.Events;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Infra.CrossCutting.Bus;
using NCwDDD.Infra.Data.Context;
using NCwDDD.Infra.Data.EventSourcing;
using NCwDDD.Infra.Data.Repository;
using NCwDDD.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace NCwDDD.Infra.CrossCutting.IOC
{
	public static class NativeInjectorBootStrapper
	{
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            services.AddScoped<INotificationHandler<CategoryRegisteredEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdatedEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryRemovedEvent>, CategoryEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, ValidationResult>, ProductCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, ValidationResult>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand, ValidationResult>, CategoryCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<NCwDDDContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}

