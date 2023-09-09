using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NCwDDD.Application.ViewModels;
using FluentValidation.Results;

namespace NCwDDD.Application.Interfaces
{
	public interface IProductAppService
	{
        Task<IEnumerable<ProductViewModel>> GetAll();

        Task<ProductViewModel> GetById(Guid id);

        Task<ValidationResult> Register(ProductViewModel productViewModel);

        Task<ValidationResult> Update(ProductViewModel productViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}

