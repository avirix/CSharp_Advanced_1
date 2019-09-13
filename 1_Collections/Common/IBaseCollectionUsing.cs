using System.Collections.Generic;

namespace ITEA_Collections.Common
{
    public interface IBaseCollectionUsing<T>
    {
        void Create();
        void Add(T ts);
        void AddMany(IEnumerable<T> ts);
        T Get(int index);
        IEnumerable<T> GetAll();
        void Clear();
    }
}
