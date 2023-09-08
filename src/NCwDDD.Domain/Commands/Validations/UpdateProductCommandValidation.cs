using System;
namespace NCwDDD.Domain.Commands.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    { 
        public UpdateProductCommandValidation()
		{
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateCategory();
            ValidatePrice();
            ValidateStoredQuantity();
        }
	}
}

