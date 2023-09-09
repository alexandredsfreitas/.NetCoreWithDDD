using AutoMapper;
using NCwDDD.Application.ViewModels;
using NCwDDD.Domain.Commands;

namespace NCwDDD.Application.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(p => new RegisterNewProductCommand(p.Name, p.Description, p.CategoryId, p.Price, p.StoredQuantity));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(p.Id, p.Name, p.Description, p.CategoryId, p.Price, p.StoredQuantity));

            CreateMap<CategoryViewModel, RegisterNewCategoryCommand>()
                .ConstructUsing(p => new RegisterNewCategoryCommand(p.Name, p.CategoryType));
            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(p => new UpdateCategoryCommand(p.Id, p.Name, p.CategoryType));
        }
	}
}

