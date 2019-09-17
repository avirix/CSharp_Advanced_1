using System;
using System.Collections.Generic;
using System.Text;

namespace ITEA_Collections.Base
{
    internal class Person : object
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Age}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
