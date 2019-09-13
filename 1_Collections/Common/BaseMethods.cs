using System;
using System.Collections.Generic;

namespace ITEA_Collections.Common
{
    internal class BaseMethods<T>
    {
        public virtual void ShowAll(IEnumerable<T> ts)
        {
            Console.WriteLine("------------- Show all --------------");
            foreach (var item in ts)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------------");
        }
    }
}
