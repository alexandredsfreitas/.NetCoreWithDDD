using System;
using Microsoft.EntityFrameworkCore;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Domain.Models;
using NCwDDD.Infra.Data.Context;
using NetDevPack.Data;

namespace NCwDDD.Infra.Data.Repository
{
	public class ProductRepository : IProductRepository
    {
        protected readonly NCwDDDContext Db;
        protected readonly DbSet<Product> DbSet;

        public ProductRepository(NCwDDDContext context)
        {
            Db = context;
            DbSet = Db.Set<Product>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Product> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public Task<IEnumerable<Product>> GetAllByCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public void Add(Product product)
        {
            DbSet.Add(product);
        }

        public void Update(Product product)
        {
            DbSet.Update(product);
        }

        public void Remove(Product product)
        {
            DbSet.Remove(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}

