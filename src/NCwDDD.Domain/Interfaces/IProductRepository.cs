using NCwDDD.Domain.Models;
using NetDevPack.Data;

namespace NCwDDD.Domain.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);

        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetAllByCategory(Guid categoryId);

    }
}

