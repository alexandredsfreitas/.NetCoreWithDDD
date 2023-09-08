using System;
using NCwDDD.Domain.Commands.Validations;
using NCwDDD.Domain.Models;

namespace NCwDDD.Domain.Commands
{
	public class UpdateCategoryCommand : CategoryCommand
	{
		public UpdateCategoryCommand(Guid id, string Name, CategoryType categoryType)
		{
			Id = id;
			Name = Name;
			CategoryType = categoryType;
		}

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

