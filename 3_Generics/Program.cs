using System;
using System.Collections.Generic;

using static ITEA_Collections.Common.Extensions;


namespace StrategyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Gunner> gunners = new List<Gunner>();
            for (int i = 0; i < 15; i++)
                gunners.Add(new Gunner());

            List<Pikeman> pikemen = new List<Pikeman>();
            for (int i = 0; i < 16; i++)
                pikemen.Add(new Pikeman());

            List<Bowman> bowmen = new List<Bowman>();
            for (int i = 0; i < 18; i++)
                bowmen.Add(new Bowman());

            var battle1 = new Battle<Gunner, Pikeman>(gunners, pikemen);
            ToConsole(battle1.CountResults(), ConsoleColor.Green);

            var battle2 = new Battle<Pikeman, Bowman>(pikemen, bowmen);
            ToConsole(battle2.CountResults(), ConsoleColor.Green);

            var battle3 = new RangeBattle(gunners, bowmen);
            ToConsole(battle3.CountResults(), ConsoleColor.Green);
            */

            Guid a = new Guid();
            Guid b = Guid.NewGuid();

            ToConsole($"{a}, {b}");

        }
    }

    interface IModel
    {
        Guid Id { get; set; }
    }

    public class Company : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> employes { get; set; }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }

    public class Person : IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid CompanyId { get; set; }

        public Person(string name, int age, Guid companyId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            CompanyId = companyId;
        }
    }
}
