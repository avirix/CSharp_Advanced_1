using System;
using System.Collections;

using static ITEA_Collections.Common.Extensions;

namespace ITEA_Collections.CustomCollections
{
    public class IteaEnumerator : IEnumerator
    {
        private object[] _collection;
        private int _currentIndex = -1;

        public object Current
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

        #region constructors
        protected IteaEnumerator() { }

        public IteaEnumerator(object[] collection)
        {
            _collection = collection;
        }
        #endregion

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Length && _collection[_currentIndex] != null;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
