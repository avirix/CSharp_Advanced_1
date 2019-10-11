using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IteaLinqToSql.Models.Abstract
{
    public class GenericAsyncRepository<T> : IAsyncRepository<T> where T : class, IIteaModel
    {
        private readonly IteaDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public GenericAsyncRepository(IteaDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        // Можно написать void, но я оставлю Task
        // А почему - читайте здесь: https://johnthiriet.com/removing-async-void/#
        // Да, домашку полезно даже просто открывать)
        public async Task CreateAsync(T item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public Task<T> FindById(int id)
        {
            return dbSet.FindAsync(id);
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsParallel().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public async Task RemoveAsync(T item)
        {
            dbSet.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            dbSet.Update(item);
            await dbContext.SaveChangesAsync();
        }
    }
}
