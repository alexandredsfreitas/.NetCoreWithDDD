using System;
namespace NCwDDD.Domain.Commands.Validations
{
	public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
		public RemoveProductCommandValidation()
		{
			ValidateId();
		}
	}
}

