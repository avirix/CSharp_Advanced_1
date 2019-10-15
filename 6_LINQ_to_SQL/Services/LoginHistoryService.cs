using IteaLinqToSql.Models.Abstract;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IteaLinqToSql.Services
{
    public class LoginHistoryService : IService<LoginHistory>
    {
        public BaseRepository<LoginHistory> Repository { get; set; }
        public GenericAsyncRepository<LoginHistory> asyncRepository { get; set; }
        public LoginHistoryService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<LoginHistory>(dbContext);
            asyncRepository = new GenericAsyncRepository<LoginHistory>(dbContext);
        }

        public void Create(LoginHistory item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(LoginHistory item)
        {
            await asyncRepository.CreateAsync(item);
        }
        public void Delete(LoginHistory id)
        {
            Repository.Remove(id);
        }
        public async Task DeleteAsync(LoginHistory item)
        {
            await asyncRepository.RemoveAsync(item);
        }
        public LoginHistory FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<LoginHistory> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
        }
        public List<LoginHistory> GetAllAsync()
        {
            return asyncRepository.GetAll().ToList();
        }
        public List<LoginHistory> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<LoginHistory> GetQuery()
        {
            return Repository.GetAll();
        }

        public LoginHistory Update(int id, LoginHistory updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task UpdateAsync(int id, LoginHistory updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
    }
}
