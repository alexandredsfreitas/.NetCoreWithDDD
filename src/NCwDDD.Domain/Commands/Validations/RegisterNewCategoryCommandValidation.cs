using System;
namespace NCwDDD.Domain.Commands.Validations
{
	public class RegisterNewCategoryCommandValidation : CategoryValidation<RegisterNewCategoryCommand>
    {
		public RegisterNewCategoryCommandValidation()
		{
			ValidateName();
			ValidateCategoryType();
		}
	}
}

