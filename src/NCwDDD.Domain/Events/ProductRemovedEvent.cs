using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Events
{
	public class ProductRemovedEvent : Event
	{
		public ProductRemovedEvent(Guid id)
		{
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; private set; }

    }
}

