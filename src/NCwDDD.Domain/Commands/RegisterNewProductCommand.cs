using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class RegisterNewProductCommand : ProductCommand
    {
		public RegisterNewProductCommand(string name, string description, Guid categoryId, decimal price, int storedQuantity)
		{
			Name = name;
			Description = description;
			CategoryId = categoryId;
			Price = price;
			StoredQuantity = storedQuantity;
		}

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

