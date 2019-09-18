using System;
using System.Collections;
using System.Collections.Generic;

namespace ITEA_Collections.Generics
{
    public class IteaGenericEnumerator<T> : IEnumerator<T>
    {
        #region IEnumerator
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
