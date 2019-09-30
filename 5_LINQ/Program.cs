using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace IteaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = GetPeople().ToList();

            foreach (Person x in people)
            {
                ToConsole(x.ToString(), ConsoleColor.Cyan);
            }

            people
                .ForEach(x => ToConsole(x.ToString(), ConsoleColor.Cyan));

            people
                .Where(x => x.Age < 28)
                .ToList()
                .ForEach(x => ToConsole(x.ToString(), ConsoleColor.Cyan));

            foreach (Person x in from i in people where i.Age < 28 select i)
                ToConsole(x.ToString(), ConsoleColor.Cyan);

            IOrderedEnumerable<Person> ordered1 = people
                .Where(x => x.Age > 35)
                .OrderByDescending(x => x.Age);

            var ordered2 = from i in people
                           where i.Age > 35
                           orderby i.Age descending
                           select new { i.Name };


            int min = people.Min(x => x.Age);
            int max = people.Max(x => x.Age);
            double avr = people.Average(x => x.Age);

            var tenten = people.Skip(10).Take(10);

            var anon = new
            {
                Name = "Anon",
                Age = 21
            };


            ToConsole(anon.Name);
        }

        #region Create people list
        public static IEnumerable<Person> GetPeople()
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new Person("Person" + i, 18 + i * 2);
            }
        }
        #endregion

        static void BaseDelegates(int f, int s)
        {
            Action<int, int> action = (a, b) => Console.WriteLine($"{a}{b}");
            Predicate<int> predicate = (a) => a > 0;
            Func<int, int, string> func = delegate (int a, int b)
            {
                return (a * b).ToString();
            };
            action(f, s);
            predicate(f);
            func(f, s);
        }

    }
}
