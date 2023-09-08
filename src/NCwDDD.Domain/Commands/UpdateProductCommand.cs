using System;
using NCwDDD.Domain.Commands.Validations;

namespace NCwDDD.Domain.Commands
{
	public class UpdateProductCommand : ProductCommand
    {
		public UpdateProductCommand()
		{
		}

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

