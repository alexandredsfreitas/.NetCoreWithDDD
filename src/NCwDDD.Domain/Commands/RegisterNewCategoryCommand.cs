using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class RegisterNewCategoryCommand : CategoryCommand
	{
		public RegisterNewCategoryCommand(string name, CategoryType categoryType)
		{
			Name = name;
			CategoryType = categoryType;
		}

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

