using StrategyGame.Actions;
using StrategyGame.Warriors.Models.Cavalry;
using StrategyGame.Warriors.Models.Infantry;
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

            List<Knight> knights = new List<Knight>();
            for (int i = 0; i < 15; i++) knights.Add(new Knight());
            
            List<Pikeman> pikemans = new List<Pikeman>();
            for (int i = 0; i < 10; i++) pikemans.Add(new Pikeman());

            List<Gunner> gunners = new List<Gunner>();
            for (int i = 0; i < 30; i++) gunners.Add(new Gunner());

            List<Bowman> bowmans = new List<Bowman>();
            for (int i = 0; i < 50; i++) bowmans.Add(new Bowman());

            // va b1 = new CavalryAttack<Pikeman>(knights,pikemans) # Cannot implement cause Pikemans not range unit
            var b2 = new CavalryAttack<Gunner>(knights, gunners);
            ToConsole(b2.CountResults(), ConsoleColor.Blue);
            var b3 = new CavalryAttack<Bowman>(knights, bowmans);
            ToConsole(b3.CountResults(), ConsoleColor.Blue);

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
