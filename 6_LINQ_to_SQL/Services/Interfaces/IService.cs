using System.Collections.Generic;
using System.Linq;
using IteaLinqToSql.Models.Abstract;

namespace IteaLinqToSql.Models.Interfaces
{
    public interface IService<T> where T : class, IIteaModel
    {
        BaseRepository<T> Repository { get; set; }
        List<T> GetAll();
        T FindById(int id);
        void Create(T item);
        void Delete(T id);
        T Update(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
