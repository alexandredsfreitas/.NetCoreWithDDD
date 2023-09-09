using System;
using NCwDDD.Domain.Models;

namespace NCwDDD.Application.ViewModels
{
	public class ProductViewModel
	{
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StoredQuantity { get; private set; }

        public DateTime RegistrationDate { get; private set; }
    }
}

