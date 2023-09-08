using System;
namespace NCwDDD.Domain.Commands.Validations
{
	public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand>
    {
		public UpdateCategoryCommandValidation()
		{
			ValidateId();
			ValidateName();
			ValidateCategoryType();
		}
	}
}

