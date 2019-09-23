using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static ITEA_Collections.Common.Extensions;
namespace ITEA_Collections.Generics
{
    public class IteaGenericCollection<T> : IEnumerable<T>, IBaseGenericCollectionUsing<T>
    {
        private T[] collection;
        private IteaGenericEnumerator<T> enumerator;
        private int count = 0;
        #region IBaseGenericCollectionUsing
        public IteaGenericCollection()
        {
            collection = new T[128];
            enumerator = new IteaGenericEnumerator<T>(collection);
        }
        public int Count()
        {
            return count;
        }
        public void Add(T ts)
        {
            collection[count] = ts;
            count++;
        }
        public void AddMany(T[] ts)
        {
            foreach (T item in ts) Add(item);
        }
        public void Clear()
        {
            collection = new T[128];
            count = 0;
        }
        public T[] GetAll()
        {
            if (count == 0)
            {
                T[] ts = new T[0];
                return ts;
            }
            else
            {
                return GetThing();
            }
        }
        private T[] GetThing()
        {
            T[] ts1 = new T[count];
            for (int i = 0; i < count; i++)
            {
                ts1[i] = collection[i];
            }
            return ts1;
        }
        public T GetByID(int index)
        {
            try
            {
                return collection[index];
            }
            catch (IndexOutOfRangeException)
            {
                ToConsole("IteaCollection/GetByID: IndexOutOfRangeException", ConsoleColor.Red);
                return default;
            }
        }
        public IEnumerable<T> Test()
        {
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return collection[i];
                }
            }
        }
        public void RemoveByID(int index)
        {
            int test = count - index;
           // int b = 1;
            for(int i = 0; i < test; i++)
            {
                collection[index] = collection[index + 1];
                index++;
            }
            count--;
        }
        public void ShowAll()
        {
            for (int i = 0; i < count; i++)
            {
                ToConsole(collection[i].ToString());
            }
        }
        #endregion

        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }
        #endregion
    }
}
