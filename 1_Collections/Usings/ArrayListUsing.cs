using System.Collections;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    internal class ArrayListUsing : BaseMethods<object>, IBaseCollectionUsing<object>
    {
        public ArrayList BookList { get; set; }

        public void Create()
        {
            BookList = new ArrayList();
        }

        public void Add(object ts)
        {
            BookList.Add(ts);
        }

        public void AddMany(IEnumerable<object> ts)
        {
            BookList.AddRange((ICollection)ts);
        }

        public void Clear()
        {
            BookList.Clear();
        }

        public object Get(int index)
        {
            return BookList[index];
        }

        public IEnumerable<object> GetAll()
        {
            return (IEnumerable<object>)BookList.GetRange(0, -1);
        }
    }
}
