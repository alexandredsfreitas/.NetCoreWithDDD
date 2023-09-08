using System;
using MediatR;

namespace NCwDDD.Domain.Events
{
	public class CategoryEventHandler :
        INotificationHandler<CategoryRegisteredEvent>,
        INotificationHandler<CategoryUpdatedEvent>,
        INotificationHandler<CategoryRemovedEvent>
    {
		public CategoryEventHandler()
		{
		}

        public Task Handle(CategoryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}

