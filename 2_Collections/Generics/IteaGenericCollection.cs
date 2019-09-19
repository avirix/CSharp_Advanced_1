using System;
using System.Collections;
using System.Collections.Generic;

namespace ITEA_Collections.Generics
{
    public class IteaGenericCollection<T> : IEnumerable<T>, IBaseGenericCollectionUsing<T>
    {
        private T[] collection;

        #region IBaseGenericCollectionUsing
        public void Add(T ts)
        {
            throw new NotImplementedException();
        }

        public void AddMany(T[] ts)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T[] GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveByID(int index)
        {
            throw new NotImplementedException();
        }

        public void ShowAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
