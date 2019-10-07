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
        public LoginHistoryService(IteaDbContext dbContext)
        {
            Repository = new BaseRepository<LoginHistory>(dbContext);
        }
        public BaseRepository<LoginHistory> Repository { get; set; }

        public void Create(LoginHistory item)
        {
            Repository.Create(item);
        }

        public void Delete(LoginHistory id)
        {
            Repository.Remove(id);
        }

        public void Delete(int id)
        {
            Delete(Repository.FindById(id));
        }


        public LoginHistory FindById(int id)
        {
            return Repository.FindById(id);
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
    }
}
