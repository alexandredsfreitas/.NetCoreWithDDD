using System;
using FluentValidation;

namespace NCwDDD.Domain.Commands.Validations
{
	public class CategoryValidation<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("It seems like the system could not generate a valid Category GUID Id");
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Category Name")
                .Length(2, 150).WithMessage("The Category Name must have between 2 and 150 characters");
        }

        protected void ValidateCategoryType()
        {
            RuleFor(c => c.CategoryType)
                .NotEmpty().WithMessage("Please ensure you have entered the Category Type");
        }
    }
}

