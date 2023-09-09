using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class UpdateProductCommand : ProductCommand
    {
		public UpdateProductCommand(Guid id, string name, string description, Guid categoryId, decimal price, int storedQuantity)
		{
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
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

