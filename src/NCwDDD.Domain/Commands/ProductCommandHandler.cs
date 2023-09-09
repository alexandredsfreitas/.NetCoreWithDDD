using System.Threading;
using System.Threading.Tasks;
using System;
using NCwDDD.Domain.Events;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;

namespace NCwDDD.Domain.Commands
{
	public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, ValidationResult>,
        IRequestHandler<UpdateProductCommand, ValidationResult>,
        IRequestHandler<RemoveProductCommand, ValidationResult>
    {
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository)
		{
            _productRepository = productRepository;
		}

        public async Task<ValidationResult> Handle(RegisterNewProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var product = new Product(Guid.NewGuid(), request.Name, request.Description, request.Category, request.Price, request.StoredQuantity, DateTime.Now);

            product.AddDomainEvent(new ProductRegisteredEvent(product.Id, product.Name, product.Description, product.Category, product.Price, product.StoredQuantity, product.RegistrationDate));

            _productRepository.Add(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var product = new Product(request.Id, request.Name, request.Description, request.Category, request.Price, request.StoredQuantity, request.RegistrationDate);

            //Command validation example
            //var existingProduct = await _productRepository.GetById(product.Id);
            //if (existingProduct != null && existingProduct.Id != product.Id)
            //{
            //    if (!existingProduct.Name.Equals(product.Name))
            //    {
            //        AddError("The product name has already been used.");
            //        return ValidationResult;
            //    }
            //}

            product.AddDomainEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Description, product.Category, product.Price, product.StoredQuantity, product.RegistrationDate));

            _productRepository.Update(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var product = await _productRepository.GetById(request.Id);

            if (product is null)
            {
                AddError("The product doesn't exists.");
                return ValidationResult;
            }

            product.AddDomainEvent(new ProductRemovedEvent(request.Id));

            _productRepository.Remove(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public void dispose()
        {
            _productRepository.Dispose();
        }
    }
}

