using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Events
{
	public class CategoryUpdatedEvent : Event
	{
		public CategoryUpdatedEvent(Guid id, string name, CategoryType categoryType)
        {
            Id = id;
            Name = name;
            CategoryType = categoryType;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public CategoryType CategoryType { get; private set; }
    }
}

