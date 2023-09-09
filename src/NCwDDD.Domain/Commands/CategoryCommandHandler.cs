using NCwDDD.Domain.Events;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Commands
{
	public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateCategoryCommand, ValidationResult>,
        IRequestHandler<RemoveCategoryCommand, ValidationResult>
    {
        private readonly ICategoryRepository _categoryRepository;

		public CategoryCommandHandler(ICategoryRepository categoryRepository)
		{
            _categoryRepository = categoryRepository;
		}

        public async Task<ValidationResult> Handle(RegisterNewCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var category = new Category(Guid.NewGuid(), request.Name, request.CategoryType);

            category.AddDomainEvent(new CategoryRegisteredEvent(category.Id, category.Name, category.CategoryType));

            _categoryRepository.Add(category);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var category = new Category(request.Id, request.Name, request.CategoryType);

            category.AddDomainEvent(new CategoryUpdatedEvent(category.Id, category.Name, category.CategoryType));

            _categoryRepository.Update(category);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var category = await _categoryRepository.GetById(request.Id);

            if (category is null)
            {
                AddError("The category doesn't exists.");
                return ValidationResult;
            }

            category.AddDomainEvent(new CategoryRemovedEvent(request.Id));

            _categoryRepository.Remove(category);

            return await Commit(_categoryRepository.UnitOfWork);
        }

        public void dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}

