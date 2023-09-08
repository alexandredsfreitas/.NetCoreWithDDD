using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Events
{
	public class CategoryRegisteredEvent : Event
	{
        public CategoryRegisteredEvent(Guid id, string name, CategoryType categoryType)
        {
            Id = id;
            Name = name;
            CategoryType = categoryType;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public CategoryType CategoryType { get; private set; }
    }
}

