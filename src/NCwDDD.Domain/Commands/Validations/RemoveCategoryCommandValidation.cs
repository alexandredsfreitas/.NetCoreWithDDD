using System;
namespace NCwDDD.Domain.Commands.Validations
{
	public class RemoveCategoryCommandValidation : CategoryValidation<RemoveCategoryCommand>
	{
		public RemoveCategoryCommandValidation()
		{
			ValidateId();
		}
	}
}

