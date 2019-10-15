using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Abstract;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;

namespace IteaLinqToSql.Services
{
    public class UserService : IService<User>
    {
        public BaseRepository<User> Repository { get; set; }
        public GenericAsyncRepository<User> asyncRepository { get; set; }

        public UserService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<User>(dbContext);
        }

        public void Create(User item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(User item)
        {
          await asyncRepository.CreateAsync(item);
        }
        public void Delete(User item)
        {
            Repository.Remove(item);
        }
        public async Task DeleteAsync(User item)
        {
            await asyncRepository.RemoveAsync(item);
        }
        public List<User> GetAll()
        {
            return Repository.GetAll().ToList();
        }
        public List<User> GetAllAsync()
        {
             return asyncRepository.GetAll().ToList(); 
        }
        public User Update(int id, User updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task UpdateAsync(int id, User updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
        public User FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<User> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
        }
        public IQueryable<User> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}