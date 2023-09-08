using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class UpdateProductCommand : ProductCommand
    {
		public UpdateProductCommand(Guid id, string name, string description, Category category, decimal price, int storedQuantity)
		{
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StoredQuantity = storedQuantity;
		}

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

