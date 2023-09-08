using System;
using NCwDDD.Domain.Commands.Validations;

namespace NCwDDD.Domain.Commands
{
	public class RemoveProductCommand : ProductCommand
    {
		public RemoveProductCommand(Guid id)
		{
			Id = id;
		}

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

