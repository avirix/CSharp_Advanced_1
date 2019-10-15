using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteaLinqToSql.Models.Abstract;

namespace IteaLinqToSql.Models.Interfaces
{
    public interface IService<T> where T : class, IIteaModel
    {
        BaseRepository<T> Repository { get; set; }
        List<T> GetAll();
        T FindById(int id);
        Task<T> FindByIdAsync(int id);
        void Create(T item);
        void CreateAsync(T item);
        void Delete(T id);
        Task DeleteAsync(T id);
        T Update(int id, T updatedItem);
        Task UpdateAsync(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
