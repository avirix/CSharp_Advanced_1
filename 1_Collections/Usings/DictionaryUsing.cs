using System;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    public class DictionaryUsing : IBaseCollectionUsing
    {
        public Dictionary<int, string> Dictionary { get; set; }

        public DictionaryUsing()
        {
            Dictionary = new Dictionary<int, string>();
        }

        public void Add(object ts)
        {
            throw new NotImplementedException();
        }

        public void AddMany(object[] ts)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public object[] GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetByID(int index)
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
    }
}
