using System;
using System.Collections.Generic;

using ITEA_Collections.Common;

namespace ITEA_Collections.Usings
{
    internal class GenericListUsing : IBaseCollectionUsing
    {
        public List<string> List { get; set; }

        public GenericListUsing()
        {
            List = new List<string>();
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
