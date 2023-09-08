using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Events
{
	public class ProductUpdatedEvent : Event
	{
		public ProductUpdatedEvent(Guid id, string name, string description, Category category, decimal price, int storedQuantity, DateTime registrationDate)
		{
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StoredQuantity = storedQuantity;
            RegistrationDate = registrationDate;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StoredQuantity { get; private set; }

        public DateTime RegistrationDate { get; private set; }
    }
}

