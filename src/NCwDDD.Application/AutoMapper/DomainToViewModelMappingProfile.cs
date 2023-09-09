using AutoMapper;
using NCwDDD.Application.ViewModels;
using NCwDDD.Domain.Models;

namespace NCwDDD.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
    {
		public DomainToViewModelMappingProfile()
		{
            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}

