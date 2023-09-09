using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
//using NCwDDD.Application.EventSourcedNormalizers;
using NCwDDD.Application.Interfaces;
using NCwDDD.Application.ViewModels;
using NCwDDD.Domain.Commands;
using NCwDDD.Domain.Interfaces;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace NCwDDD.Application.Services
{
	public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _mediator = mediator;
            //_eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        //public async Task<IList<ProductHistoryData>> GetAllHistory(Guid id)
        //{
        //    return ProductHistory.ToJavaScriptProductHistory(await _eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

