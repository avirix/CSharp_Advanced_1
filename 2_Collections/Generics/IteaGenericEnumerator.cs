using System;
using System.Collections;
using System.Collections.Generic;
using static ITEA_Collections.Common.Extensions;
namespace ITEA_Collections.Generics
{
    public class IteaGenericEnumerator<T> : IEnumerator<T>
    {
        #region IEnumerator
        private T[] _collection;
        private int _currentIndex = -1;
        private IteaGenericEnumerator() { }

        public IteaGenericEnumerator(T[] collection)
        {
            _collection = collection;
        }
        public T Current
        {
            get
            {
                try
                {
                    return _collection[_currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    ToConsole("IteaEnumerator: IndexOutOfRangeException", ConsoleColor.Red);
                    return default;
                }
            }
        }
        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return _collection[_currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    ToConsole("IteaEnumerator: IndexOutOfRangeException", ConsoleColor.Red);
                    return null;
                }
            }
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public void Dispose()
        {

        }
        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Length && _collection[_currentIndex] != null;
        }
        public void Reset()
        {
            _currentIndex = -1;
        }
        #endregion
    }
}
