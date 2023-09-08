using System;
using FluentValidation;

namespace NCwDDD.Domain.Commands.Validations
{
	public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("It seems like the system could not generate a valid Product GUID Id");
        }

        protected void ValidateName()
		{
			RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Product Name")
                .Length(2, 150).WithMessage("The Product Name must have between 2 and 150 characters");
        }

		protected void ValidateDescription()
		{
			RuleFor(p => p.Description)
				.NotEmpty().WithMessage("Please ensure you have entered the Product Description")
				.Length(2, 1000).WithMessage("The Product Description must have between 2 and 1000 characters");
        }

		protected void ValidateCategory()
		{
			RuleFor(p => p.Category)
				.NotNull().WithMessage("Please ensure you have entered a valid Product Category");
		}

		protected void ValidatePrice()
		{
			RuleFor(p => p.Price)
				.NotEmpty().WithMessage("Please ensure you have entered the Product Price")
				.GreaterThan(0).WithMessage("Please ensure you have entered a Product Price greater than zero");
        }

        protected void ValidateStoredQuantity()
        {
            RuleFor(p => p.StoredQuantity)
                .NotEmpty().WithMessage("Please ensure you have entered the Product Stored Quantity")
                .GreaterThan(0).WithMessage("Please ensure you have entered a Product Stored Quantity greater than zero");
        }

        protected void ValidateRegistrationDate()
        {
            RuleFor(p => p.RegistrationDate)
                .NotEmpty().WithMessage("Please ensure you have entered the Product Registration Date")
				.GreaterThanOrEqualTo(DateTime.Today).WithMessage("Please ensure you have entered a Product Registration Date equals to or greater than today");
        }
    }
}

