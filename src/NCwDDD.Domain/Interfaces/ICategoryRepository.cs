using NCwDDD.Domain.Models;
using NetDevPack.Data;

namespace NCwDDD.Domain.Interfaces
{
	public interface ICategoryRepository : IRepository<Product>
    {
        void Add(Category product);
        void Update(Category product);
        void Remove(Category product);

        Task<Category> GetById(Guid id);
        Task<IEnumerable<Category>> GetAll();
    }
}

