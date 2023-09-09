using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCwDDD.Application.ViewModels;
using FluentValidation.Results;

namespace NCwDDD.Application.Interfaces
{
	public interface ICategoryAppService
	{
        Task<IEnumerable<CategoryViewModel>> GetAll();

        Task<CategoryViewModel> GetById(Guid id);

        Task<ValidationResult> Register(CategoryViewModel categoryViewModel);

        Task<ValidationResult> Update(CategoryViewModel categoryViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}

