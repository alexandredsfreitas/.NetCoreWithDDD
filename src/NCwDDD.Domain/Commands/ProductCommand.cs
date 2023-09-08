using System;
using NCwDDD.Domain.Models;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Commands
{
	public class ProductCommand : Command
	{
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public Category Category { get; protected set; }

        public decimal Price { get; protected set; }

        public int StoredQuantity { get; protected set; }

        public DateTime RegistrationDate { get; protected set; }
    }
}

