using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class RegisterNewProductCommand : ProductCommand
    {
		public RegisterNewProductCommand(string name, string description, Category category, decimal price, int storedQuantity)
		{
			Name = name;
			Description = description;
			Category = category;
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

