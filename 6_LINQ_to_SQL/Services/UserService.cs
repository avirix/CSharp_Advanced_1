using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Abstract;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IteaLinqToSql.Services
{
    public class UserService : IService<User>
    {
        public BaseRepository<User> Repository { get; set; }
        public GenericAsyncRepository<User> AsyncRepository { get; set; }

        public UserService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<User>(dbContext);
            AsyncRepository = new GenericAsyncRepository<User>(dbContext);
        }

        public void Create(User item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(User item)
        {
            await AsyncRepository.CreateAsync(item);
        }

        public void Delete(User item)
        {
            Repository.Remove(item);
        }
        public async Task DeleteAsync(User id)
        {
            await AsyncRepository.RemoveAsync(id);
        }

        public List<User> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await AsyncRepository.GetAll().ToListAsync();
        }

        public User Update(int id, User updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task<User> UpdateAsync(int id, User updateItem)
        {
           await AsyncRepository.UpdateAsync(updateItem);
           return updateItem;
        }

        public User FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<User> FindByIdAsync(int id)
        {
           return await AsyncRepository.FindById(id);
        }

        public IQueryable<User> GetQuery()
        {
            return Repository.GetAll();
        }


        public  IQueryable<User> GetQueryAsync()
        {
            return AsyncRepository.GetAll();
        }
    }
}
