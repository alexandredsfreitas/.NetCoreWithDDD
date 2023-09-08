using System;
namespace NCwDDD.Domain.Commands.Validations
{
	public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
		public RegisterNewProductCommandValidation()
		{
			ValidateName();
			ValidateDescription();
			ValidateCategory();
			ValidatePrice();
			ValidateStoredQuantity();
		}
	}
}

