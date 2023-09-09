using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Events
{
	public class ProductRegisteredEvent : Event
	{
		public ProductRegisteredEvent(Guid id, string name, string description, Guid categoryId, decimal price, int storedQuantity, DateTime registrationDate)
		{
			Id = id;
			Name = name;
			Description = description;
			CategoryId = categoryId;
			Price = price;
			StoredQuantity = storedQuantity;
			RegistrationDate = registrationDate;
		}

		public Guid Id { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public Guid CategoryId { get; private set; }

		public decimal Price { get; private set; }

		public int StoredQuantity { get; private set; }

		public DateTime RegistrationDate { get; private set; }
	}
}

