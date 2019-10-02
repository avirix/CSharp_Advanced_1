using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;
using IteaDelegates.IteaMessanger;

namespace IteaLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
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

            var anon1 = new
            {
                Name = "Anon",
                Age = ""
            };

            ToConsole(anon.Age.GetType().Name);
            ToConsole(anon1.Age.GetType().Name);
            
            List<Person> people = new List<Person>
            {
                new Person("Pol", Gender.Man, 37, "pol@gmail.com"),
                new Person("Ann", Gender.Woman, 25, "ann@yahoo.com"),
                new Person("Alex", Gender.Man, 21, "alex@gmail.com"),
                new Person("Harry", Gender.Man, 58, "harry@yahoo.com"),
                new Person("Germiona", Gender.Woman, 18, "germiona@gmail.com"),
                new Person("Ron", Gender.Man, 24, "ron@yahoo.com"),
                new Person("Etc1", Gender.etc, 42, "etc1@yahoo.com"),
                new Person("Etc2", Gender.etc, 42, "etc2@gmail.com"),
            };

            var men = people.Where(x => x.Gender == Gender.Man);
            //men.ToList().ForEach(x => ToConsole(x.ToString()));
            men.ShowAll()
                .Select(x => new { x.Email, x.Age })
                .Where(x => x.Age > 30)
                .ShowAll();

            var groups = people?
                 .GroupBy(x => x.Gender)
                 .Where(g => g.Key != Gender.etc)
                 .SelectMany(g => g)
                 .Where(x => x.Age <= 25 && x.Email.Contains("yahoo"))
                 .ShowAll();

            var ints = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(ints.Aggregate((x, y) => x * y));

            Console.WriteLine(people.Aggregate((x, y) =>
                new Person(x.Name + y.Name, Gender.etc, x.Age + y.Age, x.Email + y.Email)).ToString());

            var a = Console.ReadLine();
            Console.WriteLine(a);*/
            Account alice = new Account("Alice");
            Account eva = new Account("Eva");
            Account bob = new Account("Bob");
            Account mrmajor = new Account("MrMajor");
            alice.Send(alice.CreateMessage("p=23, g=5, B=19", bob));
            alice.Send(alice.CreateMessage("p=23, g=5, B=19", eva));
            bob.Send(bob.CreateMessage("A=8", alice));
            bob.Send(bob.CreateMessage("A=8", eva));
            eva.Send(eva.CreateMessage("Crypto using detecred p=23, g=5, B=19, A=8", mrmajor));
            mrmajor.Send(mrmajor.CreateMessage("Accepted", eva));
            alice.Send(alice.CreateMessage("asldGHNMASDHASDHjasjdadakawasd", bob));
            alice.Send(alice.CreateMessage("asldGHNMASDHASDHjasjdadakawasd", eva));
            eva.Send(eva.CreateMessage("Eva send to BOB message asldGHNMASDHASDHjasjdadakawasd", mrmajor));
            mrmajor.Send(mrmajor.CreateMessage("I can't decrypt it", eva));
            eva.Send(eva.CreateMessage("Very bad", mrmajor));
            List<Account> allacc = new List<Account> { alice, bob, eva, mrmajor };
            ToConsole("Grouping Alice message", ConsoleColor.DarkYellow);
            alice.Messages.GroupBy(m => m.To).Select(g => new { g.Key.Username, Count = g.Count()}).ShowAll();
            ToConsole("Top message users", ConsoleColor.DarkYellow);
            allacc.Select(x => new { x.Username, Count = x.Messages.Count() }).OrderByDescending(x=>x.Count).Take(3).ShowAll();
            Console.WriteLine("Please enter a username");
            string checkacc = Console.ReadLine();
            allacc.Where(x => x.Username == checkacc)
                .SelectMany(x => x.Messages)
                .OrderBy(i => i.Created)
                .Select(x=>x.ReadMessage(allacc.Where(i=>i.Username==checkacc).First()))
                .ShowAll();
                //.Select(x => new { Messages = x.Messages.OrderBy(i => i.Created).ToArray() }).ShowAll();
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
