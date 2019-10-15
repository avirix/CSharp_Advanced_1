using System.Collections.Generic;
using System.Linq;

using IteaLinqToSql.Models.Abstract;
using IteaLinqToSql.Models.Database;
using IteaLinqToSql.Models.Entities;
using IteaLinqToSql.Models.Interfaces;

namespace IteaLinqToSql.Services
{
    public class UserService : IService<User>
    {
        public BaseRepository<User> Repository { get; set; }

        public UserService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<User>(dbContext);
        }

        public void Create(User item)
        {
            Repository.Create(item);
        }

        public void Delete(User item)
        {
            Repository.Remove(item);
        }

        public List<User> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public User Update(int id, User updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }

        public User FindById(int id)
        {
            return Repository.FindById(id);
        }

        public IQueryable<User> GetQuery()
        {
            return Repository.GetAll();
        }
    }
}
