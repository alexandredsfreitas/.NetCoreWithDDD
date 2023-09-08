using System;
using MediatR;

namespace NCwDDD.Domain.Events
{
	public class ProductEventHandler :
        INotificationHandler<ProductRegisteredEvent>,
        INotificationHandler<ProductUpdatedEvent>,
        INotificationHandler<ProductRemovedEvent>
    {
		public ProductEventHandler()
		{
		}

        public Task Handle(ProductRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}

