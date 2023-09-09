using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
//using NCwDDD.Application.EventSourcedNormalizers;
using NCwDDD.Application.Interfaces;
using NCwDDD.Application.ViewModels;
using NCwDDD.Domain.Commands;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace NCwDDD.Application.Services
{
	public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public CategoryAppService(IMapper mapper,
                                  ICategoryRepository categoryRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _mediator = mediator;
            //_eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryViewModel> GetById(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(await _categoryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CategoryViewModel categoryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCategoryCommand>(categoryViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(CategoryViewModel categoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        //public async Task<IList<CategoryHistoryData>> GetAllHistory(Guid id)
        //{
        //    return CategoryHistory.ToJavaScriptCategoryHistory(await _eventStoreRepository.All(id));
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

