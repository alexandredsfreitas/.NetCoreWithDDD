using System;
using Microsoft.EntityFrameworkCore;
using NCwDDD.Domain.Interfaces;
using NCwDDD.Domain.Models;
using NCwDDD.Infra.Data.Context;
using NetDevPack.Data;

namespace NCwDDD.Infra.Data.Repository
{
	public class CategoryRepository : ICategoryRepository
    {
        protected readonly NCwDDDContext Db;
        protected readonly DbSet<Category> DbSet;

        public CategoryRepository(NCwDDDContext context)
        {
            Db = context;
            DbSet = Db.Set<Category>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Category> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Add(Category category)
        {
            DbSet.Add(category);
        }

        public void Update(Category category)
        {
            DbSet.Update(category);
        }

        public void Remove(Category category)
        {
            DbSet.Remove(category);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}

