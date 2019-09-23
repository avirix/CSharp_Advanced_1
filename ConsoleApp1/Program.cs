using System;
using System.Collections.Generic;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Lst = new List<string>();
            int i = 0;
            while (i < 10)
            {
                Lst.Add(i.ToString());
                i++;
            }
            string all = "";
            string even = "";
            string noteven = "";
            foreach (string element in Lst)
            {
                all += element + ";";
                if (Lst.IndexOf(element) % 2 == 0) even += element + ";";
                if (Lst.IndexOf(element) % 2 == 1) noteven += element + ";";

            }

            Console.WriteLine("List: " + all);
            Console.WriteLine("Even: " + even);
            Console.WriteLine("Not even: " + noteven);
            string[] aa = new string[5];
            aa[0] = "123";
            aa[1] = "234";
            aa[2] = "345";
            foreach (string a in aa)
            {
                Console.WriteLine(a);
            }


        }
    }
}
