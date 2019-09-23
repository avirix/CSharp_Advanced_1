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

        public T Current {
            get
            {
                try
                {
                    return _collection[_currentIndex];
                }
                catch (IndexOutOfRangeException)
                {
                    ToConsole("IteaEnumerator: IndexOutOfRangeException", ConsoleColor.Red);
                    return default(T);
                }
            }
        }
        public IteaGenericEnumerator(T[] collection) {
            _collection = collection;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            this.Dispose();
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Length && _collection[_currentIndex] != null;
        }

        public void Reset()
        {
            _currentIndex =-1;
        }
        #endregion
    }
}
